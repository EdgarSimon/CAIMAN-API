using Cnx.Caiman.Core.DTOs;
using Cnx.Caiman.Core.DTOs.User;
using Cnx.Caiman.Core.Interfaces.Services;
using Cnx.Caiman.Infrastructure.Filters;
using Cemex.Core.Entities;
using Cemex.Core.Entities.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Cnx.Caiman.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;        

        public UserController(IUserService userService)
        {
            this.userService = userService;            
        }

        [HttpPut, Authorize]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> InsertAsync([FromBody] UserDto model)
        {            
            await this.userService.InsertAsync(model);
            return Ok();
        }

        [HttpPost, Authorize]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateAsync([FromBody] UserDto model)
        {
            await this.userService.UpdateAsync(model);
            return Ok();
        }

        [HttpPost, Authorize, Route("UpdateInfo")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateInfoAsync([FromBody] UserDto model)
        {
            await this.userService.UpdateInfoAsync(model);
            return Ok();
        }

        [HttpDelete("{idUser}"), Authorize]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DeleteAsync(int idUser)
        {
            await this.userService.DeleteAsync(idUser);
            return Ok();
        }

        [HttpPost, Route("Login")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<UserLoginResponseDto>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> LoginAsync([FromBody] UserLoginDto access)
        {
            var response = await this.userService.LoginAsync(access.CemexId, access.Psw, access.email);
            return Ok(response);
        }

        /// <summary>
        /// Lista de convenio
        /// </summary>
        /// <param name='filter'></param>
        /// <returns>retorna lista de convenios</returns>
        /// <remarks>
        /// Sample Request:
        /// 
        ///         POST /FilterGrid
        ///         {
        ///                 "orderBy": { "column": "", "isDesc": 0 },  vc20ClaveUsuario, vc80NombreUsuario, bAdministrador, vc50correo, bMensual
        ///                 "paging":   { "pageNumber": 0, "pageSize": 0, "search": "string" },
        ///                 "filters":  [
        ///                         {"Key": "idzona", "value": "string"},
        ///                         {"Key": "vc20ClaveUsuario", "value": "string"},
        ///                         {"Key": "vc80NombreUsuario", "value": "string"},
        ///                         {"Key": "bAdministrador", "value": "string"},
        ///                         {"Key": "vc50correo", "value": "string"},
        ///                         {"Key": "bMensual", "value": "string"}
        ///
        ///                 ]
        ///         }
        ///
        /// </remarks>
        [Authorize, HttpPost, Route("ListFindByZone")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<UserDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> FindByZoneAsync([FromBody] FilterGrid filter)
        {
            var response = await this.userService.FindByZoneAsync(filter);
            return Ok(response);
        }

        [Authorize, HttpGet, Route("getFindByZone")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<UserDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> getFindByZone([FromQuery] PaginationQuery filter, Nullable<int> idZone)
        {
            var response = await this.userService.getFindByZoneAsync(filter, idZone);
            return Ok(response);
        }

        /// <summary>
        /// Lista de convenio
        /// </summary>
        /// <param name='filter'></param>
        /// <returns>retorna lista de convenios</returns>
        /// <remarks>
        /// Sample Request:
        /// 
        ///         POST /FilterGrid
        ///         {
        ///                 "orderBy": { "column": "", "isDesc": 0 },  vc20ClaveUsuario, vc80NombreUsuario, bAdministrador, vc50correo, bMensual
        ///                 "paging":   { "pageNumber": 0, "pageSize": 0, "search": "string" },
        ///                 "filters":  [
        ///                         {"Key": "idzona", "value": "string"},
        ///                         {"Key": "vc20ClaveUsuario", "value": "string"},
        ///                         {"Key": "vc80NombreUsuario", "value": "string"},
        ///                         {"Key": "bAdministrador", "value": "string"},
        ///                         {"Key": "vc50correo", "value": "string"},
        ///                         {"Key": "bMensual", "value": "string"}
        ///
        ///                 ]
        ///         }
        ///
        /// </remarks>
        [Authorize, HttpPost, Route("Export")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<string>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> ExportAsync([FromBody] FilterGrid filter)
        {
            var response = await this.userService.ExportAsync(filter);
            return Ok(response);
        }


        [HttpGet, Authorize, Route("GetInfo/{idUser}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<UserDto>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetInfoAsync(int idUser)
        {
            var response = await this.userService.GetInfoAsync(idUser);
            return Ok(response);
        }

        [HttpGet, Authorize, Route("GetProfile")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<ProfileDto>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetProfileAsync([FromQuery] int idZone, int idUser)
        {
            var response = await this.userService.GetProfileAsync(idZone, idUser);
            return Ok(response);
        }

        
        [HttpGet, Authorize, Route("GetUserZone")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<List<UserZoneDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetUserZoneAsync([FromQuery] int idUser, [HiddenParam] int IdUsuario)
        {
            var response = await this.userService.GetUserZoneAsync(idUser, IdUsuario);
            return Ok(response);
        }

        [HttpPost, Authorize, Route("UpdateByZoneInfo")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateByZoneAsync([FromBody] UserZoneUpdateDto model)
        {
            await this.userService.UpdateUserZoneAsync(model);
            return Ok();
        }

        [HttpGet, Authorize, Route("GetUserProfile")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<List<UserZoneDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetByProfileAsync([FromQuery] int idZone, int idUser)
        {
            var response = await this.userService.GetByProfileAsync(idZone, idUser);
            return Ok(response);
        }

        [HttpPost, Authorize, Route("UpdateByProfile")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateUserProfileAsync([FromBody] UserProfileUpdateDto model)
        {
            await this.userService.UpdateUserProfileAsync(model);
            return Ok();
        }

        [HttpGet, Route("GetPagePermit")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<List<UserZoneDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetPagePermitAsync([FromQuery] int idZone, int idUser, int option)
        {
            var response = await this.userService.GetPagePermitAsync(idZone, idUser, option);
            return Ok(response);
        }

        [HttpPost, Authorize, Route("UpdatePermitPage")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateUserPermitAsync([FromBody] UserPermitUpdateDto model)
        {
            await this.userService.UpdateUserPermitAsync(model);
            return Ok();
        }

        [HttpGet, Authorize, Route("GetPlanDaily")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<List<KeyValuePair<string, int>>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetByPlanDailyAsync([FromQuery] int idZone, int idUser)
        {
            var response = await this.userService.GetByPlanDailyAsync(idZone, idUser);
            return Ok(response);
        }

        [HttpPost, Authorize, Route("UpdatePlanDaily")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdatePlanDailyAsync([FromBody] UserPlanDailyUpdateDto model)
        {
            await this.userService.UpdatePlanDailyAsync(model);
            return Ok();
        }

        [HttpGet, Authorize, Route("GetPDMonitorAgreggent")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<List<UserDailyPlanPermisionDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetPlanDailyAgreggentAsync([FromQuery] int idZone, int idUser, int module)
        {
            var response = await this.userService.GetPermisionAgreggentAsync(idZone, idUser, module);
            return Ok(response);
        }

        [HttpPost, Authorize, Route("UpdateAgreggentPDMonitor")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateAgreggentAsync([FromBody] UserPermisionPlanDailyDto model)
        {
            await this.userService.UpdateAgreggentAsync(model);
            return Ok();
        }

        [HttpPost, Authorize, Route("UpdateAgreggentPDMonitor-All")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateAgreggentAllAsync([FromBody] UserPermisionPlanDailyAllDto model)
        {
            await this.userService.UpdateAgreggentAllAsync(model);
            return Ok();
        }

        [HttpGet, Authorize, Route("GetPDMonitorConcret")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<List<UserDailyPlanPermisionDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetPlanDailyConcretAsync([FromQuery] int idZone, int idUser, int module)
        {
            var response = await this.userService.GetPlanDailyConcretAsync(idZone, idUser, module);
            return Ok(response);
        }

        [HttpPost, Authorize, Route("UpdateConcretPDMonitor")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateConcretAsync([FromBody] UserPermisionPlanDailyDto model)
        {
            await this.userService.UpdateConcretAsync(model);
            return Ok();
        }

        [HttpPost, Authorize, Route("UpdateConcretPDMonitor-All")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateConcretAllAsync([FromBody] UserPermisionPlanDailyAllDto model)
        {
            await this.userService.UpdateConcretAllAsync(model);
            return Ok();
        }

        [HttpGet, Route("GetPDMonitorShipper")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<List<UserDailyPlanPermisionDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetPlanDailyShipperAsync([FromQuery] int idZone, int idUser, int module)
        {
            var response = await this.userService.GetPlanDailyShipperAsync(idZone, idUser, module);
            return Ok(response);
        }

        [HttpPost, Authorize, Route("UpdateShipperPDMonitor")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateShipperAsync([FromBody] UserPermisionPlanDailyDto model)
        {
            await this.userService.UpdateShipperAsync(model);
            return Ok();
        }

        [HttpPost, Authorize, Route("UpdateShipperPDMonitor-All")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateShipperAllAsync([FromBody] UserPermisionPlanDailyAllDto model)
        {
            await this.userService.UpdateShipperAllAsync(model);
            return Ok();
        }

        [HttpGet, Authorize, Route("GetByMonitor")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<List<KeyValuePair<string, int>>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetByMonitorAsync([FromQuery] int idZone, int idUser)
        {
            var response = await this.userService.GetByMonitorAsync(idZone, idUser);
            return Ok(response);
        }

        [HttpPost, Authorize, Route("UpdateMonitor")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateMonitorAsync([FromBody] UserSecurityManagementDto model)
        {
            await this.userService.UpdateMonitorAsync(model);
            return Ok();
        }

        [HttpPost, Authorize, Route("Clone")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UserClonAsync([FromBody] UserClonDto model)
        {
            await this.userService.UserClonAsync(model);
            return Ok();
        }

        [HttpGet, Route("GetPagePermisionOffer")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<RelUserPermissionsDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetPagePermissionsAsync([FromQuery] int idZone,[HiddenParam] int IdUsuario, int page)
        {
            var response = await this.userService.PagePermissionsAsync(idZone, IdUsuario, page);
            return Ok(response);
        }

        [HttpGet("LoginMail")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<UserDto>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetUserMailAsync()
        {

            var response = await this.userService.getUserMailAsync();
            return Ok(response);
        }

        [HttpGet("Logout")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> LogoutAsync()
        {
            return Ok();
        }
    }
}
