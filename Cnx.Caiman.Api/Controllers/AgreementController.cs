using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Cnx.Caiman.Core.DTOs.Agreement;
using Cnx.Caiman.Core.DTOs.Hour;
using Cnx.Caiman.Core.Interfaces.Services;
using Cemex.Core.Entities;
using Cemex.Core.Entities.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cnx.Caiman.Api.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/agreement")]
    [ApiController]
    public class AgreementController : ControllerBase
    {
        private readonly IAgreementService agreementService;

        public AgreementController(IAgreementService agreementService)
        {
            this.agreementService = agreementService;
        }

        [HttpGet, Route("Info/{idzone}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<bool>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> Get(int idzone)
        {
            var response = await this.agreementService.InfoAsync(idzone);
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
        ///                 "orderBy": { "column": "", "isDesc": 0 },//clave,vc20UsuarioActualizacion,vc20PivotePronunciacion,vc100Predicado, vc255Descripcion, dtPlanMensual, FechaModificado, bActiva,nMax,nMin  
        ///                 "paging":   { "pageNumber": 0, "pageSize": 0, "search": "string" },
        ///                 "filters":  [
        ///                         {"Key": "idZona", "value": "string"},
        ///                         {"Key": "clave", "value": "string"},
        ///                         {"Key": "vc20UsuarioActualizacion", "value": "string"},
        ///                         {"Key": "dtActualizacion", "value": "string"},
        ///                         {"Key": "dtPlanMensual", "value": "string"},
        ///                         {"Key": "vc20PivotePronunciacion", "value": "string"},
        ///                         {"Key": "vc100Predicado", "value": "string"},
        ///                         {"Key": "bActiva", "value": "string"},
        ///                         {"Key": "nMax", "value": "string"},
        ///                         {"Key": "nMin", "value": "string"},
        ///                         {"Key": "vc255Descripcion", "value": "string"}
        ///
        ///                 ]
        ///         }
        ///
        /// </remarks>
        [HttpPost, Route("List")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<AgreementDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> Get([FromBody] FilterGrid filter)
        {
            var response = await this.agreementService.ListSearchAsync(filter);
            return Ok(response);
        }

        /// <summary>
        /// Product excel
        /// </summary>
        /// <param name='filter'></param>
        /// <returns>Product excel stream</returns>
        /// <remarks>
        /// Sample Request:
        ///
        ///     POST /FilterGrid
        ///     {
        ///             "orderBy": { "column": "", "isDesc": 0 },//IDZONA,IDPRODUCTO,VC50NOMBRE,VC10CLAVESICLO,ICLAVESIT,DTACTUALIZACION,VC20USUARIOACTUALIZACION,DTCREACION,VC20USUARIOCREACION,IDPROD55,VC25NOMBRECORTO,TIPOPRODUCTOVC20TIPOPRODUCTO,
        ///             "paging":   { "pageNumber": 0, "pageSize": 0, "search": "string" },
        ///             "filters":  [
        ///                     {"Key": "idZona", "value": "string"},
        ///                         {"Key": "clave", "value": "string"},
        ///                         {"Key": "vc20UsuarioActualizacion", "value": "string"},
        ///                         {"Key": "dtActualizacion", "value": "string"},
        ///                         {"Key": "dtPlanMensual", "value": "string"},
        ///                         {"Key": "vc20PivotePronunciacion", "value": "string"},
        ///                         {"Key": "vc100Predicado", "value": "string"},
        ///                         {"Key": "bActiva", "value": "string"},
        ///                         {"Key": "nMax", "value": "string"},
        ///                         {"Key": "nMin", "value": "string"},
        ///                         {"Key": "vc255Descripcion", "value": "string"}
        ///             ],
        ///             "Columns":  [
        ///                     {"Key": "idZona", "value": "string"},
        ///                         {"Key": "clave", "value": "string"},
        ///                         {"Key": "vc20UsuarioActualizacion", "value": "string"},
        ///                         {"Key": "dtActualizacion", "value": "string"},
        ///                         {"Key": "dtPlanMensual", "value": "string"},
        ///                         {"Key": "vc20PivotePronunciacion", "value": "string"},
        ///                         {"Key": "vc100Predicado", "value": "string"},
        ///                         {"Key": "bActiva", "value": "string"},
        ///                         {"Key": "nMax", "value": "string"},
        ///                         {"Key": "nMin", "value": "string"},
        ///                         {"Key": "vc255Descripcion", "value": "string"}
        ///             ],
        ///     }
        ///
        /// </remarks>
        [HttpPost, Route("Export")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<string>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> ExportAsync([FromBody] FilterGrid filter)
        {
            var response = await this.agreementService.ExportAsync(filter);
            return Ok(response);
        }

        //[HttpGet, Route("ListSearch")]
        //[ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<AgreementDto>>))]
        //[ProducesResponseType((int)HttpStatusCode.BadRequest)]
        //public async Task<ActionResult> Get([FromQuery] PaginationQuery filter, int idzone, string keyvalue)
        //{
        //    var response = await this.agreementService.ListSearchAsync(filter, idzone, keyvalue);
        //    return Ok(response);
        //}

        [HttpGet, Route("GetTID")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<int>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> Get([FromQuery] string description)
        {
            var response = await this.agreementService.GetTIDAsync(description);
            return Ok(response);
        }

        [HttpGet, Route("TypeList")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<RestrictionTypeDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> Get()
        {
            var response = await this.agreementService.ByTypeAsync();
            return Ok(response);
        }

        [HttpGet, Route("ProfileList")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<ProfileAgreementDTO>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> GetPrifile()
        {
            var response = await this.agreementService.ProfileListAsync();
            return Ok(response);
        }

        [HttpGet, Route("FrequencyList")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<FrequencyAgreementDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> GetFrequency()
        {
            var response = await this.agreementService.FrequencyAsync();
            return Ok(response);
        }

        [HttpGet, Route("RestrictionInfo/{idrestriction}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<AgreementDto>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> GetRestriction(int idrestriction)
        {
            var response = await this.agreementService.RestrictionInfoAsync(idrestriction);
            return Ok(response);
        }

        [HttpPost, Route("FindInfoList")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<EsqPivPronDto>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> FindInfo([FromBody] FindInfoDto model)
        {
            var response = await this.agreementService.FindInfoAsync(model);
            return Ok(response);
        }

        [HttpPost, Route("ListDailyPlan")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<AgreementDto>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> DailyPlanAsync([FromBody] FilterGrid filter)
        {
            var response = await this.agreementService.GetByDailyPlanAsync(filter);
            return Ok(response);
        }

        [HttpPost, Route("ExportDailyPlan")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<string>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> ExportDailyPlanAsync([FromBody] FilterGrid filter)
        {
            var response = await this.agreementService.ExportDailyPlanAsync(filter);
            return Ok(response);
        }

        [HttpGet("HourRestrictionAvailable")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<HourDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetRestrictionAsync([FromQuery] PaginationQuery filter, int idzone, long tid)
        {
            var response = await this.agreementService.GetRestrictionAsync(filter, idzone, tid);
            return Ok(response);
        }

        [HttpGet("HourRestrictionAvailableOneToOne")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<HourDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetRestrictionOnetoOneAsync([FromQuery] PaginationQuery filter, int idzone, long tid)
        {
            var response = await this.agreementService.GetRestrictionOneToOneAsync(filter, idzone, tid);
            return Ok(response);
        }

        [HttpDelete, Route("DeleteBasic/{TID}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task DeleteAsync(long TID)
        {
            await this.agreementService.DeleteTransacAsync(TID);
        }

        [HttpDelete, Route("Delete/{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task DeleteAsync(int id)
        {
            await this.agreementService.DeleteAsync(id);
        }

        [HttpPut, Route("Insert")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task PutAsync([FromBody] AgreementSaveDto model)
        {
            await this.agreementService.InsertAsync(model);
        }

        [HttpPost, Route("Update")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task PostAsync([FromBody] AgreementSaveDto model)
        {
            await this.agreementService.UpdateAsync(model);
        }

        [HttpPost, Route("UpdateDailyPlan")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task PostAsync([FromBody] AgreementDailyPlanDto model)
        {
            await this.agreementService.UpdateDailyPlanAsync(model);
        }

        [HttpPut, Route("RestrictionHour")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task PutRestrictionAsync([FromBody] HourRestrictionDto data)
        {
            await this.agreementService.InsertRestrictionAsync(data);
        }
    }
}
