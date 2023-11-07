using Cnx.Caiman.Core.Interfaces.Services;
using Cemex.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Cnx.Caiman.Core.DTOs;

namespace Cnx.Caiman.Infrastructure.Middleware
{
    public class ParamsMiddleware: IMiddleware
    {
        private readonly IUserCacheService cache;
        private readonly IUserService user;
        public ParamsMiddleware(IUserCacheService cache, IUserService user)
        {
            this.cache = cache;
            this.user = user;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {

            string requestPayload = "";
            string path = context.Request.Path.Value.ToLower();

            if (path.Equals("/api/user/login") || path.Equals("/api/user/loginmail") || path.Equals("/api/user/logout"))
            {
                //Se deja el if debug para pruebas con el AD de CIBI por temas con el AD de CAIMAN
#if DEBUG
                this.cache.Remove(context.User.FindFirst("preferred_username")?.Value);
#else
                this.cache.Remove(context.User.Identity.Name);
                
#endif

                await next(context);
                return;
            }

            if (!context.User.Identity.IsAuthenticated)
            {
                context.Response.StatusCode = 401;
                return;
            }


            context.Request.EnableBuffering();
            using (var reader = new StreamReader(context.Request.Body, encoding: Encoding.UTF8, detectEncodingFromByteOrderMarks: false, bufferSize: 1024, leaveOpen: true))
            {
                requestPayload = await reader.ReadToEndAsync();
                context.Request.Body.Position = 0;
            }

            if (requestPayload != "" && context.Request.ContentType.Contains("application/json"))
            {
                if (!requestPayload.Contains("form-data"))
                {
                    var PayLoadOrginal = JObject.Parse(requestPayload);

                    var objeto = await this.getUserJWT(context, PayLoadOrginal);

                    var requestBytes = Encoding.UTF8.GetBytes(objeto.ToString());
                    var streamNew = new MemoryStream(requestBytes);
                    context.Request.Body = streamNew;
                }
            }

            if (context.Request.Method == "GET")
            {
                context.Request.QueryString = context.Request.QueryString.Add("IdUsuario", await this.getUserJWT(context));
            }

            if (context.Request.Method == "DELETE")
            {
                context.Request.QueryString = context.Request.QueryString.Add("Vc20Usuario", await this.getUserJWT(context));
            }

            await next(context);

        }

        
        private async Task<string> getUserJWT(HttpContext context, JObject PayLoadOrginal = null)
        {
            var TokenClamim = await getClaims(context);

            var claimId = TokenClamim.Key.ToString();
            var claimUser = TokenClamim.Value;

            if(context.Request.Method == "GET")
            {
                return claimId;
            }

            if (context.Request.Method == "DELETE")
            {
                return claimUser;
            }

            if (PayLoadOrginal.ContainsKey("filters"))
            {
                var arrayOldFiltes = PayLoadOrginal.Value<JArray>("filters");

                var iduserElement = new KeyValuePair<string, string>("IdUsuario", claimId);

                var arrayFilter = arrayOldFiltes.ToObject<List<KeyValuePair<string, string>>>();
                arrayFilter.Add(iduserElement);

                var arrayNewFilters = JToken.Parse(JsonConvert.SerializeObject(arrayFilter));


                PayLoadOrginal["filters"] = arrayNewFilters;
            }
            else
            {
                PayLoadOrginal["Vc20Usuario"] = claimUser;
                PayLoadOrginal["IdUsuario"] = claimId;
            }


            return JsonConvert.SerializeObject(PayLoadOrginal);
        }

        private async Task<KeyValuePair<int, string>> getClaims(HttpContext context)
        {
            //Se deja el if debug para pruebas con el AD de CIBI por temas con el AD de CAIMAN
#if DEBUG
            var mail = context.User.FindFirst("preferred_username")?.Value;
#else
            var mail = context.User.Identity.Name;
#endif
            var user = this.cache.Get(mail);
            if(user == null)
            {
                var objUser = await this.user.getUserMailAsync();
                if (objUser != null)
                {
                    this.cache.Set(mail, objUser.Data.User);
                    user = objUser.Data.User;
                }
            }

            KeyValuePair<int, string> claims = new KeyValuePair<int, string>(user.IdUsuario, user.Vc20ClaveUsuario);

            return claims;

        }
    }
}
