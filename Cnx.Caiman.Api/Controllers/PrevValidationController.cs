using Cnx.Caiman.Core.DTOs.AssigPlan;
using Cnx.Caiman.Core.DTOs.PrevValidation;
using Cnx.Caiman.Core.Interfaces.Services;
using Cemex.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Cnx.Caiman.Api.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/PrevValidation")]
    [ApiController]
    public class PrevValidationController : Controller
    {
        private readonly IPrevValidationsService PrevValidation;

        public PrevValidationController(IPrevValidationsService PrevValidation)
        {
            this.PrevValidation = PrevValidation;
        }


        /// <summary>
        /// Prevention Validation collection
        /// </summary>
        /// <param name="IdPlanAssig">* value requeried </param>
        /// <param name="element">* 
        /// o, e, d, t, a
        /// </param>
        /// <response code="200">
        /// o = OfertaMaxima, vcProducto, DemandaTotal, vcOferentes (Verificar este ultimo por que regresa un href)
        /// e = vcDestino, vcProducto
        /// d = vcDestino, DemandaTotal, CapacidadRecepcion
        /// t = vcTransportista, Oferta, CapacidadDespacho
        /// a = vcOrigen, Oferta, CapacidadDespacho
        /// </response>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET 
        ///
        /// </remarks>
        [HttpGet("List")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<ValidacionesPreviasListDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAsync([FromQuery] int IdPlanAssig, string element)
        {
            var response = await this.PrevValidation.GetAsync(IdPlanAssig, element);
            return Ok(response);
        }

        /// <summary>
        /// Prevention Validation collection
        /// </summary>
        /// <param name="IdPlanAssig">* value requeried </param>
        /// <response code="200">
        /// [Key] = Nombre Destino - [Value] = Enlaces
        /// </response>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET 
        ///
        /// </remarks>
        [HttpGet("ListDvSEA")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<List<KeyValuePair<string, int>>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetDvSEAsync([FromQuery] int IdPlanAssig)
        {
            var response = await this.PrevValidation.GetDvSEAsync(IdPlanAssig);
            return Ok(response);
        }

        /// <summary>
        /// Prevention Validation collection
        /// </summary>
        /// <param name="IdPlanAssig">* value requeried </param>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET 
        ///
        /// </remarks>
        [HttpGet("ListOTvsD")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<List<AssigPlanDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetOTvsDAsync([FromQuery] int IdPlanAssig)
        {
            var response = await this.PrevValidation.GetOTvsDAsync(IdPlanAssig);
            return Ok(response);
        }

        //GetOTvsDsync

    }
}
