using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Cnx.Caiman.Core.DTOs;
using Cnx.Caiman.Core.DTOs.Shipper;
using Cnx.Caiman.Core.Entities.Filters;
using Cnx.Caiman.Core.Interfaces.Services;
using Cnx.Caiman.Infrastructure.Filters;
using Cemex.Core.Entities;
using Cemex.Core.Entities.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cnx.Caiman.Api.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/Shipper")]
    [ApiController]
    public class ShipperController : ControllerBase
    {
        private readonly IShipperService shipperService;

        public ShipperController(IShipperService shipperService)
        {
            this.shipperService = shipperService;
        }
        /// <summary>
        /// Transportista excel
        /// </summary>
        /// <param name='filter'></param>
        /// <returns>Transportista excel stream</returns>
        /// <remarks>
        /// Sample Request:
        /// 
        ///         POST /FilterGrid
        ///         {
        ///                 "orderBy": { "column": "", "isDesc": 0 },//IDZONA,VC50NOMBRE,NTARIFA,ICANTSENCILLOS,NCANTIDADPORVIAJE,IMANEJA,BTARIFAPROPIA,BSERVIRPRIORIDAD,ICLAVESIT,BPROPIO,IMANIANA,ITARDE,INOCHE,DTACTUALIZACION,VC20USUARIOACTUALIZACION,DTCREACION,VC20USUARIOCREACION,VCSAP,IDTIPOLOTE,IDTRANSPGENERAL,VC25NOMBRECORTO
        ///                 "paging":   { "pageNumber": 0, "pageSize": 0, "search": "string" },
        ///                 "filters":  [
        ///                         {"Key": "idzona", "value": "string"},
        ///                         {"Key": "Vc50nombre", "value": "string"},
        ///                         {"Key": "ntarifa", "value": "string"},
        ///                         {"Key": "icantsencillos", "value": "string"},
        ///                         {"Key": "ncantidadporviaje", "value": "string"},
        ///                         {"Key": "imaneja", "value": "string"},
        ///                         {"Key": "btarifapropia", "value": "string"},
        ///                         {"Key": "bservirprioridad", "value": "string"},
        ///                         {"Key": "iclavesit", "value": "string"},
        ///                         {"Key": "bpropio", "value": "string"},
        ///                         {"Key": "imaniana", "value": "string"},
        ///                         {"Key": "itarde", "value": "string"},
        ///                         {"Key": "inoche", "value": "string"},
        ///                         {"Key": "dtActualizacion", "value": "string"},
        ///                         {"Key": "vc20usuarioactualizacion", "value": "string"},
        ///                         {"Key": "dtCreacion", "value": "string"},
        ///                         {"Key": "vc20UsuarioCreacion", "value": "string"},
        ///                         {"Key": "vcSAP", "value": "string"},
        ///                         {"Key": "IdTipoLote", "value": "string"},
        ///                         {"Key": "IdTranspGeneral", "value": "string"},
        ///                         {"Key": "vc25NombreCorto", "value": "string"}
        ///
        ///                 ]
        ///         }
        ///
        /// </remarks>
                
        [HttpPost("List")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<ShipperDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAsync([FromBody] FilterGrid filter)
        {
            var response = await this.shipperService.GetAsync(filter);
            return Ok(response);
        }
        /// <summary>
        /// Transportista excel
        /// </summary>
        /// <param name='filter'></param>
        /// <returns>Transportista excel stream</returns>
        /// <remarks>
        /// Sample Request:
        ///
        ///     POST /FilterGrid
        ///     {
        ///             "orderBy": { "column": "", "isDesc": 0 },//IDZONA,VC50NOMBRE,NTARIFA,ICANTSENCILLOS,NCANTIDADPORVIAJE,IMANEJA,BTARIFAPROPIA,BSERVIRPRIORIDAD,ICLAVESIT,BPROPIO,IMANIANA,ITARDE,INOCHE,DTACTUALIZACION,VC20USUARIOACTUALIZACION,DTCREACION,VC20USUARIOCREACION,VCSAP,IDTIPOLOTE,IDTRANSPGENERAL,VC25NOMBRECORTO,
        ///             "paging":   { "pageNumber": 0, "pageSize": 0, "search": "string" },
        ///             "filters":  [
        ///                     {"Key": "idzona", "value": "string"},
        ///                     {"Key": "Vc50nombre", "value": "string"},
        ///                     {"Key": "ntarifa", "value": "string"},
        ///                     {"Key": "icantsencillos", "value": "string"},
        ///                     {"Key": "ncantidadporviaje", "value": "string"},
        ///                     {"Key": "imaneja", "value": "string"},
        ///                     {"Key": "btarifapropia", "value": "string"},
        ///                     {"Key": "bservirprioridad", "value": "string"},
        ///                     {"Key": "iclavesit", "value": "string"},
        ///                     {"Key": "bpropio", "value": "string"},
        ///                     {"Key": "imaniana", "value": "string"},
        ///                     {"Key": "itarde", "value": "string"},
        ///                     {"Key": "inoche", "value": "string"},
        ///                     {"Key": "dtActualizacion", "value": "string"},
        ///                     {"Key": "vc20usuarioactualizacion", "value": "string"},
        ///                     {"Key": "dtCreacion", "value": "string"},
        ///                     {"Key": "vc20UsuarioCreacion", "value": "string"},
        ///                     {"Key": "vcSAP", "value": "string"},
        ///                     {"Key": "IdTipoLote", "value": "string"},
        ///                     {"Key": "IdTranspGeneral", "value": "string"},
        ///                     {"Key": "vc25NombreCorto", "value": "string"}
        ///             ],
        ///             "Columns":  [
        ///                     {"Key": "idzona", "value": "string"},
        ///                     {"Key": "Vc50nombre", "value": "string"},
        ///                     {"Key": "ntarifa", "value": "string"},
        ///                     {"Key": "icantsencillos", "value": "string"},
        ///                     {"Key": "ncantidadporviaje", "value": "string"},
        ///                     {"Key": "imaneja", "value": "string"},
        ///                     {"Key": "btarifapropia", "value": "string"},
        ///                     {"Key": "bservirprioridad", "value": "string"},
        ///                     {"Key": "iclavesit", "value": "string"},
        ///                     {"Key": "bpropio", "value": "string"},
        ///                     {"Key": "imaniana", "value": "string"},
        ///                     {"Key": "itarde", "value": "string"},
        ///                     {"Key": "inoche", "value": "string"},
        ///                     {"Key": "dtActualizacion", "value": "string"},
        ///                     {"Key": "vc20usuarioactualizacion", "value": "string"},
        ///                     {"Key": "dtCreacion", "value": "string"},
        ///                     {"Key": "vc20UsuarioCreacion", "value": "string"},
        ///                     {"Key": "vcSAP", "value": "string"},
        ///                     {"Key": "IdTipoLote", "value": "string"},
        ///                     {"Key": "IdTranspGeneral", "value": "string"},
        ///                     {"Key": "vc25NombreCorto", "value": "string"}
        ///             ],
        ///     }
        ///
        /// </remarks>

        [HttpPost("Export")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<ShipperDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> ExportAsync([FromBody] FilterGrid filter)
        {
            var response = await this.shipperService.ExportAsync(filter);
            return Ok(response);
        }

        [HttpGet("by-month")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<ShipperDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetByMonthAsync([FromQuery] ZoneIntFilterDto filter)
        {
            var response = await this.shipperService.GetMonthAsync(filter);
            return Ok(response);
        }

		[HttpGet("by-Zone-everyone")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<ShipperDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetByZoneOptionAllAsync([FromQuery] ZoneIntFilter filter, bool isagreement)
        {
            var response = await this.shipperService.GetByZoneAllAsync(filter, isagreement);
            return Ok(response);
        }

        [HttpGet("RestrictionAvailable")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<ShipperDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetRestrictionAsync([FromQuery] PaginationQuery filter, int idzone, long tid)
        {
            var response = await this.shipperService.GetRestrictionAsync(filter, idzone, tid);
            return Ok(response);
        }

        [HttpGet("RestrictionAvailableOneToOne")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<ShipperDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetRestrictionOneToOneAsync([FromQuery] PaginationQuery filter, int idzone, long tid)
        {
            var response = await this.shipperService.GetRestrictionOneToOneAsync(filter, idzone, tid);
            return Ok(response);
        }

        [HttpGet("RestrictionInvolved")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<ShipperDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetRestrictionInvolvedAsync([FromQuery] PaginationQuery filter, int idzone, long tid)
        {
            var response = await this.shipperService.GetRestrictionInvolvedAsync(filter, idzone, tid);
            return Ok(response);
        }

        [HttpGet("RestrictionInvolvedOneToOne")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<ShipperDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetRestrictionInvolvedOneToOneAsync([FromQuery] PaginationQuery filter, int idzone, long tid)
        {
            var response = await this.shipperService.GetRestrictionInvolvedOneToOneAsync(filter, idzone, tid);
            return Ok(response);
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> PutAsync([FromBody] ShipperInsertDto data)
        {
            await this.shipperService.InsertAsync(data);
            return Ok();
        }

        [HttpPut("InsertMonthlyAsync")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<Object>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> InsertMonthlyAsync([FromBody] ShipperInsertMonthlyDto data)
        {
            var response = await this.shipperService.InsertMonthlyAsync(data);
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<Object>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> PostAsync([FromBody] ShipperUpdateDto data)
        {
            var response = await this.shipperService.UpdateAsync(data);
            return Ok(response);
        }

        [HttpPut, Route("Restriction")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task PutRestrictionAsync([FromBody] ShipperRestrictionDto data)
        {
            await this.shipperService.InsertRestrictionAsync(data);
        }

        [HttpPut, Route("RestrictionOneToOne")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task PutRestrictionOneToOneAsync([FromBody] ShipperRestrictionDto data)
        {
            await this.shipperService.InsertRestrictionOneToOneAsync(data);
        }

        [HttpDelete("{ShipperId}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<Object>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DeleteAsync(string ShipperId, [FromQuery, HiddenParam] string vc20Usuario)
        {
            var response = await this.shipperService.DeleteAsync(ShipperId, vc20Usuario);
            return Ok(response);
        }
    }
}
