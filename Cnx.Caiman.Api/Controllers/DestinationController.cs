using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Cnx.Caiman.Core.DTOs.Destination;
using Cnx.Caiman.Core.DTOs.Product;
using Cnx.Caiman.Core.Entities.Filters;
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
    [Route("api/destination")]
    [ApiController]
    public class DestinationController : ControllerBase
    {
        private readonly IDestinationService destinationService;

        public DestinationController(IDestinationService destinationService)
        {
            this.destinationService = destinationService;
        }

        
        /// <summary>
        /// Request Destination
        /// </summary>
        /// <param name="filter"></param>
        /// <returns>Destination excel</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /FilterGrid
        ///     {
        ///         "orderBy":  { "column": "", "isDesc": 0 },
        ///             VC50NOMBRE, IMANIANA, ITARDE, INOCHE, ICLAVESICADI, LAT, LON, BDESTINORELBANDERA, ICANTREG, VCDESTINOREL
        ///             ICLAVESIT, DTACTUALIZACION, DTCREACION, VC20USUARIOACTUALIZACION, VC20USUARIOCREACION, VC12CLAVESAP, VC25NOMBRECORTO, CEDISVCDESCRIPCION, SUBZONAVC50NOMBRE,
        ///         "paging":   { "pageNumber": 0, "pageSize": 0, "search": "string" },
        ///         "filters":  [
        ///                         { "key": "zona", "value": "string" },
        ///                         { "Key": "vc50Nombre", "value": "string" },
        ///                         { "Key": "iManiana", "value": "string" },
        ///                         { "Key": "iTarde", "value": "string" },
        ///                         { "Key": "iNoche", "value": "string" },
        ///                         { "Key": "bAutoAbasto", "value": "string" },
        ///                         { "Key": "iclavesicadi", "value": "string" },
        ///                         { "Key": "iclavesit", "value": "string" },
        ///                         { "Key": "dtactualizacion", "value": "string" }
        ///                         { "Key": "vc20usuarioactualizacion", "value": "string" },
        ///                         { "Key": "dtCreacion", "value": "string" },
        ///                         { "Key": "vc20UsuarioCreacion", "value": "string" },
        ///                         { "Key": "UsuarioCreacion", "value": "string" },
        ///                         { "Key": "vc12clavesap", "value": "string" }
        ///                         { "Key": "vczonasap", "value": "string" },
        ///                         { "Key": "vc25NombreCorto", "value": "string" },
        ///                         { "Key": "Subzona.Vc50Nombre", "value": "string" },
        ///                         { "Key": "Cedi.vcdescripcion", "value": "string" },
        ///                         { "Key": "DestinoUbicacion.Lat", "value": "string" },
        ///                         { "Key": "DestinoUbicacion.Lon", "value": "string" },
        ///                         { "Key": "ICantReg", "value": "string" },
        ///                         { "Key": "BDestinoRelBandera", "value": "string" }
        ///                     ],
        ///     }
        ///
        /// </remarks>

        [HttpPost("List")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<DestinationDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAsync([FromBody] FilterGrid filter)
        {
            var response = await destinationService.GetAsync(filter);
            return Ok(response);
        }

        /// <summary>
        /// Request Destination export
        /// </summary>
        /// <param name="filter"></param>
        /// <returns>Destination excel</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /FilterGrid
        ///     {
        ///         "orderBy":  { "column": "", "isDesc": 0 }, //VC50NOMBRE, IMANIANA, ITARDE, INOCHE, ICLAVESICADI, LAT, LON, BDESTINORELBANDERA, ICANTREG, VCDESTINOREL
        ///             ICLAVESIT, DTACTUALIZACION, DTCREACION, VC20USUARIOACTUALIZACION, VC20USUARIOCREACION, VC12CLAVESAP, VC25NOMBRECORTO, CEDISVCDESCRIPCION, SUBZONAVC50NOMBRE,
        ///         "paging":   { "pageNumber": 0, "pageSize": 0, "search": "string" },
        ///         "filters":  [
        ///                         { "key": "zona", "value": "string" },
        ///                         { "Key": "vc50Nombre", "value": "string" },
        ///                         { "Key": "iManiana", "value": "string" },
        ///                         { "Key": "iTarde", "value": "string" },
        ///                         { "Key": "iNoche", "value": "string" },
        ///                         { "Key": "bAutoAbasto", "value": "string" },
        ///                         { "Key": "iclavesicadi", "value": "string" },
        ///                         { "Key": "iclavesit", "value": "string" },
        ///                         { "Key": "dtactualizacion", "value": "string" }
        ///                         { "Key": "vc20usuarioactualizacion", "value": "string" },
        ///                         { "Key": "dtCreacion", "value": "string" },
        ///                         { "Key": "vc20UsuarioCreacion", "value": "string" },
        ///                         { "Key": "UsuarioCreacion", "value": "string" },
        ///                         { "Key": "vc12clavesap", "value": "string" }
        ///                         { "Key": "vczonasap", "value": "string" },
        ///                         { "Key": "vc25NombreCorto", "value": "string" },
        ///                         { "Key": "Subzona.Vc50Nombre", "value": "string" },
        ///                         { "Key": "Cedi.vcdescripcion", "value": "string" },
        ///                         { "Key": "DestinoUbicacion.Lat", "value": "string" },
        ///                         { "Key": "DestinoUbicacion.Lon", "value": "string" },
        ///                         { "Key": "ICantReg", "value": "string" },
        ///                         { "Key": "BDestinoRelBandera", "value": "string" }
        ///                     ],
        ///         "Columns":  [
        ///                         { "key": "idDestino", "value": "string" },
        ///                         { "Key": "vc50Nombre", "value": "string" },
        ///                         { "Key": "iManiana", "value": "string" },
        ///                         { "Key": "iTarde", "value": "string" },
        ///                         { "Key": "iNoche", "value": "string" },
        ///                         { "Key": "bAutoAbasto", "value": "string" },
        ///                         { "Key": "iclavesicadi", "value": "string" },
        ///                         { "Key": "iclavesit", "value": "string" },
        ///                         { "Key": "dtactualizacion", "value": "string" }
        ///                         { "Key": "vc20usuarioactualizacion", "value": "string" },
        ///                         { "Key": "dtCreacion", "value": "string" },
        ///                         { "Key": "vc20UsuarioCreacion", "value": "string" },
        ///                         { "Key": "vc12clavesap", "value": "string" },
        ///                         { "Key": "vczonasap", "value": "string" }
        ///                         { "Key": "vc25NombreCorto", "value": "string" },
        ///                         { "Key": "Subzona.Vc50Nombre", "value": "string" },
        ///                         { "Key": "Cedi.vcdescripcion", "value": "string" },
        ///                         { "Key": "DestinoUbicacion.Lat", "value": "string" },
        ///                         { "Key": "DestinoUbicacion.Lon", "value": "string" },
        ///                         { "Key": "VcDestinoRel.", "value": "string" },
        ///                         { "Key": "ICantReg", "value": "string" },
        ///                         { "Key": "BDestinoRelBandera", "value": "string" }
        ///                     ]
        ///     }
        ///
        /// </remarks>

        [HttpPost("Export")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<DestinationDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> ExportAsync([FromBody] FilterGrid filter)
        {
            var response = await destinationService.ExportAsync(filter);
            return Ok(response);
        }

        [HttpGet("GetWithoutDistance")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<DestinationWithoutDistanceDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetWithoutDistanceAsync([FromQuery] ZoneIntFilter filter)
        {
            var response = await destinationService.GetWithoutDistanceAsync(filter);
            return Ok(response);
        }

        [HttpGet("GetDestinationProductsList")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<RelUsoDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetDestinationProductsListAsync([FromQuery] PaginationQuery filter, int idDestination)
        {
            var response = await destinationService.GetDestinationProductsListAsync(filter, idDestination);
            return Ok(response);
        }

        [HttpGet("GetProductsByZone")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<ProductDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetProductsByZoneAsync([FromQuery] PaginationQuery filter,int idZone, int idDestination)
        {
            var response = await destinationService.GetProductsByZoneAsync(filter, idZone, idDestination);
            return Ok(response);
        }

        [HttpGet("getDestinationDistanceList")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<DestinationDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> getDestinationDistanceListAsync([FromQuery] PaginationQuery filter, int idzone)
        {
            var response = await destinationService.getDestinationDistanceListAsync(filter, idzone);
            return Ok(response);
        }

        [HttpPut("StoreRelationProduct")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> StoreRelationProductAsync([FromBody] RelDestinationProductInsertDto data)
        {
            await destinationService.StoreRelationProductAsync(data);
            return Ok();
        }

        [HttpPost("UpdateRelationProduct/{idUso}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateRelationProductAsync(int idUso, [FromBody] RelDestinationProductInsertDto data)
        {
            await destinationService.UpdateRelationProductAsync(data, idUso);
            return Ok();
        }

        [HttpDelete("DeleteRelationProduct/{idUso}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DeleteRelationProductAsync(int idUso)
        {
            await destinationService.DeleteRelationProductAsync(idUso);
            return Ok();
        }

        [HttpGet("GetRelationDestinationInventory")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<RelDestinoInventarioDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetRelationDestinationInventoryAsync([FromQuery] PaginationQuery filter, int idDestination)
        {
            var response = await destinationService.GetRelationDestinationInventoryAsync(filter, idDestination);
            return Ok(response);
        }

        [HttpPut("InsertInventoryProduct/{idDestination}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> InsertInventoryProductAsync(int idDestination, [FromBody] RelInventoryInsertProductDto data)
        {
            await destinationService.InsertInventoryProductAsync(data, idDestination);
            return Ok();
        }

        [HttpDelete("DeleteRelationInventory/{idDestination}/{idRelation}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DeleteRelationInventoryAsync(int idDestination, int idRelation)
        {
            await destinationService.DeleteRelationInventoryAsync(idDestination, idRelation);
            return Ok();
        }

        [HttpPost("UpdateInventoryProduct/{idDestination}/{idRelation}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateInventoryProductAsync(int idDestination, int idRelation, [FromBody] RelInventoryInsertProductDto data)
        {
            await destinationService.UpdateInventoryProductAsync(data, idDestination, idRelation);
            return Ok();
        }

        [HttpGet("by-Zone-everyone")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<DestinationDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetByZoneOptionAllAsync([FromQuery] FilterZone filter, bool isagreement, string idFiltrados)
        {
            var response = await this.destinationService.GetByZoneAllAsync(filter, isagreement, idFiltrados);
            return Ok(response);
        }

        [HttpGet("RestrictionAvailable")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<DestinationDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetRestrictionAsync([FromQuery] PaginationQuery filter, int idzone, long tid)
        {
            var response = await this.destinationService.GetRestrictionAsync(filter, idzone, tid);
            return Ok(response);
        }

        [HttpGet("RestrictionAvailableOneToOne")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<DestinationDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetRestrictionOneToOneAsync([FromQuery] PaginationQuery filter, int idzone, long tid)
        {
            var response = await this.destinationService.GetRestrictionOneToOneAsync(filter, idzone, tid);
            return Ok(response);
        }

        [HttpGet("RestrictionInvolved")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<DestinationDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetRestrictionInvolvedAsync([FromQuery] PaginationQuery filter, int idzone, long tid)
        {
            var response = await this.destinationService.GetRestrictionInvolvedAsync(filter, idzone, tid);
            return Ok(response);
        }

        [HttpGet("RestrictionInvolvedOneToOne")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<DestinationDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetRestrictionInvolvedOneToOneAsync([FromQuery] PaginationQuery filter, int idzone, long tid)
        {
            var response = await this.destinationService.GetRestrictionInvolvedOneToOneAsync(filter, idzone, tid);
            return Ok(response);
        }

        [HttpGet("DestinationClientList")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<DestinationDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetDestinationClientListAsync([FromQuery] PaginationQuery filter, int idzone)
        {
            var response = await this.destinationService.GetDestinationClientListAsync(filter, idzone);
            return Ok(response);
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> PutAsync([FromBody] DestinationInsertDto data)
        {
            await destinationService.InsertAsync(data);
            return Ok();
        }

        [HttpPost("{idDestination}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> PostAsync(int idDestination, [FromBody] DestinationInsertDto data)
        {
            await destinationService.UpdateAsync(idDestination,data);
            return Ok();
        }

        [HttpPut, Route("Restriction")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task PutRestrictionAsync([FromBody] DestinationRestrictionDto data)
        {
            await this.destinationService.InsertRestrictionAsync(data);
        }

        [HttpPut, Route("RestrictionOneToOne")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task PutRestrictionOneToOneAsync([FromBody] DestinationRestrictionDto data)
        {
            await this.destinationService.InsertRestrictionOneToOneAsync(data);
        }

        [HttpDelete("{idDestination}/{user}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DeleteAsync(int idDestination, string user)
        {
            await destinationService.DeleteAsync(idDestination, user);
            return Ok();
        }
    }
}
