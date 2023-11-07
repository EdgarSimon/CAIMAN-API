using Cnx.Caiman.Core.DTOs.AssignmentTrip;
using Cnx.Caiman.Core.DTOs.Feasibility;
using Cnx.Caiman.Core.DTOs.FeasibilityAgreement;
using Cnx.Caiman.Core.Interfaces.Services;
using Cnx.Caiman.Infrastructure.Filters;
using Cemex.Core.Entities;
using Cemex.Core.Entities.Filters;
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
    [Route("api/AssignmentTrip")]
    [ApiController]
    public class AssignmentTripController : Controller
    {
        private readonly IAssignmentTripService assignmentTripService;

        public AssignmentTripController(IAssignmentTripService assignmentTripService)
        {
            this.assignmentTripService = assignmentTripService;
        }

        [HttpDelete, Route("Delete")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task DeleteAsync([FromQuery] int idTrip,[HiddenParam] string Vc20Usuario)
        {
            await this.assignmentTripService.DeleteAsync(idTrip, Vc20Usuario);
        }

        [HttpGet("getAssigmentPlanList")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<KeyValuePair<int, string>>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> getPlanAssigListAsyc([FromQuery] PaginationQuery filter, int idZone, DateTime date)
        {
            var response = await this.assignmentTripService.getPlanAssigListAsyc(filter, idZone, date);
            return Ok(response);
        }

        [HttpGet("getListAceptTrip")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<AceptTripListDto>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> getAceptTripListAsyc([FromQuery] int result)
        {
            var response = await this.assignmentTripService.getAceptTripListAsyc(result);
            return Ok(response);
        }

        [HttpPost("getCostsBasic")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<TripListCostsDto>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> getCostsAsyc([FromBody] TripListCostsParamsDto model)
        {
            var response = await this.assignmentTripService.getCostsAsyc(model);
            return Ok(response);
        }

        /// <summary>
        /// Asignacion de viajes
        /// </summary>
        /// <param name='filter'></param>
        /// <returns>Lista de asignacion de viajes</returns>
        /// <remarks>
        /// Sample Request:
        ///
        ///     POST /FilterGrid
        ///     {
        ///             "orderBy": { "column": "", "isDesc": 0 },//Folio,IDZONA,ORIGEN,DESTINO,TRANSPORTISTA,PRODUCTO,RESULTADO,IDSUBZONA,ICOSTOPROPIO,ITARIFAPROPIA,TIPOPRODUCTO,HORARIO,VCTRANSPORTISTA,VCORIGEN,VCDESTINO,VCPRODUCTO,VCPRIORIDAD,VCCP,VCCD,VCCI,VCSUBZONA,VCTIPOPRODUCTO,VCDISTANCIA,DTACTUALIZACION,VC20USUARIOACTUALIZACION,
        ///             "paging":   { "pageNumber": 0, "pageSize": 0, "search": "string" },
        ///             "filters":  [
        ///                     {"Key": "dtfecha", "value": "string(10)" , "required": true},
        ///                     {"Key": "idzona", "value": "int" , "required": true},
        ///                     {"Key": "origen", "value": "int" , "required": true},
        ///                     {"Key": "destino", "value": "int" , "required": true},
        ///                     {"Key": "transportista", "value": "int" , "required": true},
        ///                     {"Key": "producto", "value": "int" , "required": true},
        ///                     {"Key": "resultado", "value": "int" , "required": true},
        ///                     {"Key": "idsubzona", "value": "int" , "required": true},
        ///                     {"Key": "iCostoPropio", "value": "int" , "required": true},
        ///                     {"Key": "iTarifaPropia", "value": "int" , "required": true},
        ///                     {"Key": "tipoproducto", "value": "int" , "required": true},
        ///                     {"Key": "horario", "value": "int" , "required": true},
        ///                     {"Key": "vcTransportista", "value": "string" , "required": false},
        ///                     {"Key": "vcOrigen", "value": "string" , "required": false},
        ///                     {"Key": "vcDestino", "value": "string" , "required": false},
        ///                     {"Key": "vcProducto", "value": "string" , "required": false},
        ///                     {"Key": "vcPrioridad", "value": "string" , "required": false},
        ///                     {"Key": "vccp", "value": "string" , "required": false},
        ///                     {"Key": "vccd", "value": "string" , "required": false},
        ///                     {"Key": "vcci", "value": "string" , "required": false},
        ///                     {"Key": "vcsubzona", "value": "string" , "required": false},
        ///                     {"Key": "vctipoproducto", "value": "string" , "required": false},
        ///                     {"Key": "vcdistancia", "value": "string" , "required": false},
        ///                     {"Key": "dtActualizacion", "value": "string" , "required": false},
        ///                     {"Key": "vc20UsuarioActualizacion", "value": "string" , "required": false}
        ///             ],
        ///             "Columns":  [],
        ///     }
        ///
        /// </remarks>
        [HttpPost("getListTrip")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<TripListDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> ListTripAsync([FromBody] FilterGrid model)
        {
            var response = await this.assignmentTripService.ListTripAsync(model);
            return Ok(response);
        }

        /// <summary>
        /// Asignacion de viajes
        /// </summary>
        /// <param name='filter'></param>
        /// <returns>Asignacion de viajes excel</returns>
        /// <remarks>
        /// Sample Request:
        ///
        ///     POST /FilterGrid
        ///     {
        ///             "orderBy": { "column": "", "isDesc": 0 },//IDZONA,ORIGEN,DESTINO,TRANSPORTISTA,PRODUCTO,RESULTADO,IDSUBZONA,ICOSTOPROPIO,ITARIFAPROPIA,TIPOPRODUCTO,HORARIO,VCTRANSPORTISTA,VCORIGEN,VCDESTINO,VCPRODUCTO,VCPRIORIDAD,VCCP,VCCD,VCCI,VCSUBZONA,VCTIPOPRODUCTO,VCDISTANCIA,DTACTUALIZACION,VC20USUARIOACTUALIZACION,
        ///             "paging":   { "pageNumber": 0, "pageSize": 0, "search": "string" },
        ///             "filters":  [
        ///                     {"Key": "idzona", "value": "string" , "required": true},
        ///                     {"Key": "origen", "value": "string" , "required": true},
        ///                     {"Key": "destino", "value": "string" , "required": true},
        ///                     {"Key": "transportista", "value": "string" , "required": true},
        ///                     {"Key": "producto", "value": "string" , "required": true},
        ///                     {"Key": "resultado", "value": "string" , "required": true},
        ///                     {"Key": "idsubzona", "value": "string" , "required": true},
        ///                     {"Key": "iCostoPropio", "value": "string" , "required": true},
        ///                     {"Key": "iTarifaPropia", "value": "string" , "required": true},
        ///                     {"Key": "tipoproducto", "value": "string" , "required": true},
        ///                     {"Key": "horario", "value": "string" , "required": true},
        ///                     {"Key": "vcTransportista", "value": "string" , "required": false},
        ///                     {"Key": "vcOrigen", "value": "string" , "required": false},
        ///                     {"Key": "vcDestino", "value": "string" , "required": false},
        ///                     {"Key": "vcProducto", "value": "string" , "required": false},
        ///                     {"Key": "vcPrioridad", "value": "string" , "required": false},
        ///                     {"Key": "vccp", "value": "string" , "required": false},
        ///                     {"Key": "vccd", "value": "string" , "required": false},
        ///                     {"Key": "vcci", "value": "string" , "required": false},
        ///                     {"Key": "vcsubzona", "value": "string" , "required": false},
        ///                     {"Key": "vctipoproducto", "value": "string" , "required": false},
        ///                     {"Key": "vcdistancia", "value": "string" , "required": false},
        ///                     {"Key": "dtActualizacion", "value": "string" , "required": false},
        ///                     {"Key": "vc20UsuarioActualizacion", "value": "string" , "required": false}
        ///             ],
        ///             "Columns":  [
        ///                     {"Key": "idzona", "value": "string"},
        ///                     {"Key": "origen", "value": "string"},
        ///                     {"Key": "destino", "value": "string"},
        ///                     {"Key": "transportista", "value": "string"},
        ///                     {"Key": "producto", "value": "string"},
        ///                     {"Key": "resultado", "value": "string"},
        ///                     {"Key": "idsubzona", "value": "string"},
        ///                     {"Key": "iCostoPropio", "value": "string"},
        ///                     {"Key": "iTarifaPropia", "value": "string"},
        ///                     {"Key": "tipoproducto", "value": "string"},
        ///                     {"Key": "horario", "value": "string"},
        ///                     {"Key": "vcTransportista", "value": "string"},
        ///                     {"Key": "vcOrigen", "value": "string"},
        ///                     {"Key": "vcDestino", "value": "string"},
        ///                     {"Key": "vcProducto", "value": "string"},
        ///                     {"Key": "vcPrioridad", "value": "string"},
        ///                     {"Key": "vccp", "value": "string"},
        ///                     {"Key": "vccd", "value": "string"},
        ///                     {"Key": "vcci", "value": "string"},
        ///                     {"Key": "vcsubzona", "value": "string"},
        ///                     {"Key": "vctipoproducto", "value": "string"},
        ///                     {"Key": "vcdistancia", "value": "string"},
        ///                     {"Key": "dtActualizacion", "value": "string"},
        ///                     {"Key": "vc20UsuarioActualizacion", "value": "string"}
        ///             ],
        ///     }
        ///
        /// </remarks>
        [HttpPost, Route("Export")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<string>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> ExportAsync([FromBody] FilterGrid filter)
        {
            var response = await this.assignmentTripService.ExportAsync(filter);
            return Ok(response);
        }

        [HttpPost, Route("Accept")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task AceptAssignPlanAsync([FromBody] AceptAssignPlanDto model)
        {
            await this.assignmentTripService.AceptAssignPlanAsync(model);
        }

        //EDICION

        /// <summary>
        /// edicion de viajes
        /// </summary>
        /// <param name='filter'></param>
        /// <returns>edicion de viajes</returns>
        /// <remarks>
        /// Sample Request:
        ///
        ///     POST /FilterGrid
        ///     {
        ///             "orderBy": { "column": "", "isDesc": 0 },//FOLIO,VCTRANSPORTISTA,VCORIGEN,VCDESTINO,VCPRODUCTO,VCPRIORIDAD,VCSUBZONA,VCTIPOPRODUCTO,DTACTUALIZACION,VC20USUARIOACTUALIZACION,
        ///             "paging":   { "pageNumber": 0, "pageSize": 0, "search": "string" },
        ///             "filters":  [
        ///                     {"Key": "dtfecha", "value": "string" , "required": true},
        ///                     {"Key": "idzona", "value": "int" , "required": true},
        ///                     {"Key": "origen", "value": "int" , "required": true},
        ///                     {"Key": "destino", "value": "int" , "required": true},
        ///                     {"Key": "transportista", "value": "int" , "required": true},
        ///                     {"Key": "producto", "value": "int" , "required": true},
        ///                     {"Key": "resultado", "value": "int" , "required": true},
        ///                     {"Key": "idsubzona", "value": "int" , "required": true},
        ///                     {"Key": "tipoproducto", "value": "int" , "required": true},
        ///                     {"Key": "horario", "value": "int" , "required": true},
        ///                     {"Key": "Folio", "value": "int" , "required": false},
        ///                     {"Key": "vcTransportista", "value": "string" , "required": false},
        ///                     {"Key": "vcOrigen", "value": "string" , "required": false},
        ///                     {"Key": "vcDestino", "value": "string" , "required": false},
        ///                     {"Key": "vcProducto", "value": "string" , "required": false},
        ///                     {"Key": "vcPrioridad", "value": "string" , "required": false},
        ///                     {"Key": "vcSubzona", "value": "string" , "required": false},
        ///                     {"Key": "vcTipoproducto", "value": "string" , "required": false},
        ///                     {"Key": "dtActualizacion", "value": "string" , "required": false},
        ///                     {"Key": "vc20UsuarioActualizacion", "value": "string" , "required": false}
        ///             ],
        ///             "Columns":  [],
        ///     }
        ///
        /// </remarks>
        [HttpPost("getEditListTrip")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<ListEditTripDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> TripEditListAsync([FromBody] FilterGrid filter)
        {
            var response = await this.assignmentTripService.TripEditListAsync(filter);
            return Ok(response);
        }

        /// <summary>
        /// edicion de viajes
        /// </summary>
        /// <param name='filter'></param>
        /// <returns>edicion de viajes excel</returns>
        /// <remarks>
        /// Sample Request:
        ///
        ///     POST /FilterGrid
        ///     {
        ///             "orderBy": { "column": "", "isDesc": 0 },//FOLIO,VCTRANSPORTISTA,VCORIGEN,VCDESTINO,VCPRODUCTO,VCPRIORIDAD,VCSUBZONA,VCTIPOPRODUCTO,DTACTUALIZACION,VC20USUARIOACTUALIZACION,
        ///             "paging":   { "pageNumber": 0, "pageSize": 0, "search": "string" },
        ///             "filters":  [
        ///                     {"Key": "dtfecha", "value": "string" , "required": true},
        ///                     {"Key": "idzona", "value": "int" , "required": true},
        ///                     {"Key": "origen", "value": "int" , "required": true},
        ///                     {"Key": "destino", "value": "int" , "required": true},
        ///                     {"Key": "transportista", "value": "int" , "required": true},
        ///                     {"Key": "producto", "value": "int" , "required": true},
        ///                     {"Key": "resultado", "value": "int" , "required": true},
        ///                     {"Key": "idsubzona", "value": "int" , "required": true},
        ///                     {"Key": "iCostoPropio", "value": "int" , "required": true},
        ///                     {"Key": "horario", "value": "int" , "required": true},
        ///                     {"Key": "Folio", "value": "int" , "required": false},
        ///                     {"Key": "vcTransportista", "value": "string" , "required": false},
        ///                     {"Key": "vcOrigen", "value": "string" , "required": false},
        ///                     {"Key": "vcDestino", "value": "string" , "required": false},
        ///                     {"Key": "vcProducto", "value": "string" , "required": false},
        ///                     {"Key": "vcPrioridad", "value": "string" , "required": false},
        ///                     {"Key": "vcSubzona", "value": "string" , "required": false},
        ///                     {"Key": "vcTipoproducto", "value": "string" , "required": false},
        ///                     {"Key": "dtActualizacion", "value": "string" , "required": false},
        ///                     {"Key": "vc20UsuarioActualizacion", "value": "string" , "required": false}
        ///             ],
        ///             "Columns":  [
        ///                     {"Key": "Folio", "value": "string"},
        ///                     {"Key": "vcTransportista", "value": "string"},
        ///                     {"Key": "vcOrigen", "value": "string"},
        ///                     {"Key": "vcDestino", "value": "string"},
        ///                     {"Key": "vcProducto", "value": "string"},
        ///                     {"Key": "vcPrioridad", "value": "string"},
        ///                     {"Key": "vcSubzona", "value": "string"},
        ///                     {"Key": "vcTipoproducto", "value": "string"},
        ///                     {"Key": "dtActualizacion", "value": "string"},
        ///                     {"Key": "vc20UsuarioActualizacion", "value": "string"}
        ///             ],
        ///     }
        ///
        /// </remarks>
        [HttpPost, Route("ExportEdit")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<string>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> TripEditListExportAsync([FromBody] FilterGrid filter)
        {
            var response = await this.assignmentTripService.TripEditListExportAsync(filter);
            return Ok(response);
        }

        [HttpGet("getTripCarrierList")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<KeyValuePair<int, string>>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> getTripCarrierListAsync([FromQuery] int idresult)
        {
            var response = await this.assignmentTripService.getTripCarrierListAsync(idresult);
            return Ok(response);
        }

        [HttpGet("getTripOriginList")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<KeyValuePair<int, string>>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> getTripOriginListAsync([FromQuery] int idresult)
        {
            var response = await this.assignmentTripService.getTripOriginListAsync(idresult);
            return Ok(response);
        }

        [HttpPost, Route("UpdateTrip")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task UpdateTripAsync([FromBody] UpdateTripDto model)
        {
            await this.assignmentTripService.UpdateTripAsync(model);
        }

        //FACTIBILIDAD
        [HttpGet("getFeasibility")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<FeasibilityDto>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> getFeasibilityAsync([FromQuery] int idzone, string date, int idresult)
        {
            var response = await this.assignmentTripService.getFeasibilityAsync(idzone, date, idresult);
            return Ok(response);
        }

        //FACTIBILIDAD convenios
        [HttpGet("getFeasibilityAgreement")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<FeasibilityAgreementDto>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> getFeasibilityAgreementAsync([FromQuery] int idzone, string date, int idresult)
        {
            var response = await this.assignmentTripService.getFeasibilityAgreementAsync(idzone, date, idresult);
            return Ok(response);
        }

        /// <summary>
        /// Lista de Restriccion Incumplido
        /// </summary>
        /// <param name='filter'></param>
        /// <returns>Lista de Restriccion Incumplido</returns>
        /// <remarks>
        /// Sample Request:
        ///
        ///     POST /FilterGrid
        ///     {
        ///             "orderBy": { "column": "", "isDesc": 0 },//Clave,convenio,VC20USUARIOACTUALIZACION,DTACTUALIZACION
        ///             "paging":   { "pageNumber": 0, "pageSize": 0, "search": "string" },
        ///             "filters":  [
        ///                     {"Key": "idresultado", "value": "string" , "required": true},
        ///                     {"Key": "Clave", "value": "string" , "required": false},
        ///                     {"Key": "Convenio", "value": "string" , "required": false},
        ///             ],
        ///             "Columns":  [],
        ///     }
        ///
        /// </remarks>
        [HttpPost("getListFeasibilityAgreemen")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<RestrictionListUnfulfilledDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> ListFeasibilityAgreementAsync([FromBody] FilterGrid filter)
        {
            var response = await this.assignmentTripService.ListFeasibilityAgreementAsync(filter);
            return Ok(response);
        }

        /// <summary>
        /// Lista de Restriccion Incumplido
        /// </summary>
        /// <param name='filter'></param>
        /// <returns>Lista de Restriccion Incumplido</returns>
        /// <remarks>
        /// Sample Request:
        ///
        ///     POST /FilterGrid
        ///     {
        ///             "orderBy": { "column": "", "isDesc": 0 },//Clave,convenio,VC20USUARIOACTUALIZACION,DTACTUALIZACION
        ///             "paging":   { "pageNumber": 0, "pageSize": 0, "search": "string" },
        ///             "filters":  [
        ///                     {"Key": "idresultado", "value": "string" , "required": true},
        ///                     {"Key": "Clave", "value": "string" , "required": false},
        ///                     {"Key": "Convenio", "value": "string" , "required": false},
        ///             ],
        ///             "Columns":  [],
        ///     }
        ///
        /// </remarks>
        [HttpPost, Route("FeasibilityAgreementExport")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<string>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> FeasibilityAgreementExportAsync([FromBody] FilterGrid filter)
        {
            var response = await this.assignmentTripService.FeasibilityAgreementExportAsync(filter);
            return Ok(response);
        }

        //REEVALUAR
        [HttpPost, Route("ReevaluateTrip")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task ReevaluateTripAsync([FromBody] ReevaluateDto model )
        {
            await this.assignmentTripService.ReevaluateTripAsync(model);
        }

        //NUEVOS VIAJES
        /// <summary>
        /// element = 't' transportista, 'o' origen, 'd' destino, 'p' producto
        /// </summary> 
        [HttpGet("getFilterListElements")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<KeyValuePair<int, string>>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> getTripCarrierListAsync([FromQuery] FilterListElementDto filter)
        {
            var response = await this.assignmentTripService.getFilterListElementAsync(filter);
            return Ok(response);
        }
        [HttpPut, Route("InsertTrip")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<int>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> InsertPlanTripAsync([FromBody] InsertPlanTripDto model)
        {
            var result = await this.assignmentTripService.InsertPlanTripAsync(model);
            return Ok(result);
        }
    }
}
