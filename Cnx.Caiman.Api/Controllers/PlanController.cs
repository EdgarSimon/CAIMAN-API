using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Cnx.Caiman.Core.DTOs.ManualPlan;
using Cnx.Caiman.Core.Interfaces.Services;
using Cemex.Core.Entities;
using Cemex.Core.Entities.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cnx.Caiman.Api.Controllers
{
    [Authorize]
    [Route("api/plan")]
    [ApiController]
    public class PlanController : ControllerBase
    {
        private readonly IManualPlanService manualPlanService;

        public PlanController(IManualPlanService ManualPlanService)
        {
            this.manualPlanService = ManualPlanService;
        }

        [HttpGet("GetList")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<ManualPlanDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetByZoneOptionAllAsync([FromQuery] PaginationQuery filter, int idzone, DateTime date)
        {
            var response = await this.manualPlanService.GetPlanAsync(filter, idzone, date);
            return Ok(response);
        }

        /// <summary>
        /// Distancia por destinos
        /// </summary>
        /// <param name='filter'></param>
        /// <returns>Distancia por destinos excel</returns>
        /// <remarks>
        /// Sample Request:
        ///
        ///     POST /FilterGrid
        ///     {
        ///             "orderBy": { "column": "", "isDesc": 0 },//FOLIO,IDPLANMANUAL,IDZONA,IDORIGEN,ORIGEN,IDDESTINO,DESTINO,IDPRODUCTO,PRODUCTO,IDTRANSPORTISTA,TRANSPORTISTA,IDSUBZONA,SUBZONA,IDTIPOPRODUCTO,PRIORIDAD,NVOLUMEN,NVIAJES,DTFECHA,IDVIAJE,VC20USUARIOACTUALIZACION,DTACTUALIZACION,
        ///             "paging":   { "pageNumber": 0, "pageSize": 0, "search": "string" },
        ///             "filters":  [
        ///                     {"Key": "Folio", "value": "string" , "required": true},
        ///                     {"Key": "Origen", "value": "string" , "required": false},
        ///                     {"Key": "Destino", "value": "string" , "required": false},
        ///                     {"Key": "Producto", "value": "string" , "required": false},
        ///                     {"Key": "Transportista", "value": "string" , "required": false},
        ///                     {"Key": "SubZona", "value": "string" , "required": false},
        ///                     {"Key": "Prioridad", "value": "string" , "required": false},
        ///                     {"Key": "nVolumen", "value": "string" , "required": false},
        ///                     {"Key": "nViajes", "value": "string" , "required": false},
        ///                     {"Key": "dtFecha", "value": "string" , "required": false},
        ///                     {"Key": "vc20UsuarioActualizacion", "value": "string" , "required": false},
        ///                     {"Key": "dtActualizacion", "value": "string" , "required": false}
        ///             ]
        ///     }
        ///
        /// </remarks>
        [HttpPost("GetInfoList")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<ManualPlanInfoDto>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetPlanInfoAsync([FromBody] FilterGrid filter)
        {
            var response = await this.manualPlanService.GetPlanInfoAsync(filter);
            return Ok(response);
        }

        /// <summary>
        /// Distancia por destinos
        /// </summary>
        /// <param name='filter'></param>
        /// <returns>Distancia por destinos excel</returns>
        /// <remarks>
        /// Sample Request:
        ///
        ///     POST /FilterGrid
        ///     {
        ///             "orderBy": { "column": "", "isDesc": 0 },//FOLIO,IDPLANMANUAL,IDZONA,IDORIGEN,ORIGEN,IDDESTINO,DESTINO,IDPRODUCTO,PRODUCTO,IDTRANSPORTISTA,TRANSPORTISTA,IDSUBZONA,SUBZONA,IDTIPOPRODUCTO,PRIORIDAD,NVOLUMEN,NVIAJES,DTFECHA,IDVIAJE,VC20USUARIOACTUALIZACION,DTACTUALIZACION,
        ///             "paging":   { "pageNumber": 0, "pageSize": 0, "search": "string" },
        ///             "filters":  [
        ///                     {"Key": "Folio", "value": "string" , "required": true},
        ///                     {"Key": "Origen", "value": "string" , "required": false},
        ///                     {"Key": "Destino", "value": "string" , "required": false},
        ///                     {"Key": "Producto", "value": "string" , "required": false},
        ///                     {"Key": "Transportista", "value": "string" , "required": false},
        ///                     {"Key": "SubZona", "value": "string" , "required": false},
        ///                     {"Key": "Prioridad", "value": "string" , "required": false},
        ///                     {"Key": "nVolumen", "value": "string" , "required": false},
        ///                     {"Key": "nViajes", "value": "string" , "required": false},
        ///                     {"Key": "dtFecha", "value": "string" , "required": false},
        ///                     {"Key": "vc20UsuarioActualizacion", "value": "string" , "required": false},
        ///                     {"Key": "dtActualizacion", "value": "string" , "required": false}
        ///             ],
        ///             "Columns":  [
        ///                     {"Key": "Folio", "value": "string"}
        ///                     {"Key": "IdZona", "value": "string"},
        ///                     {"Key": "IdOrigen", "value": "string"},
        ///                     {"Key": "Origen", "value": "string"},
        ///                     {"Key": "IdDestino", "value": "string"},
        ///                     {"Key": "Destino", "value": "string"},
        ///                     {"Key": "IdProducto", "value": "string"},
        ///                     {"Key": "Producto", "value": "string"},
        ///                     {"Key": "IdTransportista", "value": "string"},
        ///                     {"Key": "Transportista", "value": "string"},
        ///                     {"Key": "IdSubZona", "value": "string"},
        ///                     {"Key": "SubZona", "value": "string"},
        ///                     {"Key": "IdTipoProducto", "value": "string"},
        ///                     {"Key": "Prioridad", "value": "string"},
        ///                     {"Key": "nVolumen", "value": "string"},
        ///                     {"Key": "nViajes", "value": "string"},
        ///                     {"Key": "dtFecha", "value": "string"},
        ///                     {"Key": "IdViaje", "value": "string"},
        ///                     {"Key": "vc20UsuarioActualizacion", "value": "string"},
        ///                     {"Key": "dtActualizacion", "value": "string"}
        ///             ],
        ///     }
        ///
        /// </remarks>
        [HttpPost("GetInfoListExport")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<ManualPlanInfoDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetInfoListExportAsync([FromBody] FilterGrid filter)
        {
            var response = await this.manualPlanService.GetInfoListExportAsync(filter);
            return Ok(response);
        }

        [HttpGet("GetFilterTree")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<CubeDailyAggDto>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CubeDailyAsync([FromQuery] PaginationQuery filter, int idzone, int? iddestination)
        {
            var response = await this.manualPlanService.CubeDailyAsync(filter, idzone, iddestination);
            return Ok(response);
        }

        [HttpPut("Insert")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> PutAsync([FromBody] ManualPlanInsertDTO model)
        {
            var response = await this.manualPlanService.InsertAsync(model.idzone, model.date, model.Vc20Usuario);
            return Ok(response);
        }

        [HttpPost("Authorize")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task PostAsync([FromBody] ManualPlanUpdateDto model)
        {
            await this.manualPlanService.AuthorizeAsync(model);
        }

        [HttpPost("Accept")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<ManualPlanTripDto>))]
        public async Task<IActionResult> PostAccepAsync([FromBody] ManualPlanUpdateDto model)
        {
            var response = await this.manualPlanService.AcceptAsync(model);

            return Ok(response);
        }

        [HttpPut("InsertManualTrip")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task PutManualTripAsync([FromBody] ManualTripDto model)
        {
            await this.manualPlanService.InsertTripManualAsync(model);
        }

        [HttpDelete("DeleteTrip/{id}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            await this.manualPlanService.DeleteAsync(id);

            return Ok();
        }
    }
}
