using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Cnx.Caiman.Core.DTOs.Origin;
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
    //[Authorize]
    [Produces("application/json")]
    [Route("api/origin")]
    [ApiController]
    public class OriginController : ControllerBase
    {
        private readonly IOriginService originService;
        
        public OriginController(IOriginService originService)
        {
            this.originService = originService;
        }

        /// <summary>
        /// Origin
        /// </summary>
        /// <param name='filter'></param>
        /// <returns>Origin Collection</returns>
        /// <remarks>
        /// Sample Request:
        ///
        ///     POST /FilterGrid
        ///     {
        ///             "orderBy": { "column": "", "isDesc": 0 },//IDZONA,VC50NOMBRE,BPROPIO,BMENSUAL,BSERVIRPRIORIDAD,IMANIANA,ITARDE,INOCHE,VC10CLAVESICADI,ICLAVESIT,BCARGAAUT,BACTIVO,DTACTUALIZACION,VC20USUARIOACTUALIZACION,DTCREACION,VC20USUARIOCREACION,VCSAP,CEDIS,VC25NOMBRECORTO,CEDISVCDESCRIPCION,ORIGENUBICACIONLAT,ORIGENUBICACIONLON,
        ///             "paging":   { "pageNumber": 0, "pageSize": 0, "search": "string" },
        ///             "filters":  [
        ///                     {"Key": "IdZona", "value": "string" , "required": true},
        ///                     {"Key": "Vc50Nombre", "value": "string" , "required": false},
        ///                     {"Key": "bPropio", "value": "string" , "required": false},
        ///                     {"Key": "bMensual", "value": "string" , "required": false},
        ///                     {"Key": "bServirPrioridad", "value": "string" , "required": false},
        ///                     {"Key": "iManiana", "value": "string" , "required": false},
        ///                     {"Key": "iTarde", "value": "string" , "required": false},
        ///                     {"Key": "iNoche", "value": "string" , "required": false},
        ///                     {"Key": "vc10ClaveSicadi", "value": "string" , "required": false},
        ///                     {"Key": "iClaveSit", "value": "string" , "required": false},
        ///                     {"Key": "bCargaAut", "value": "string" , "required": false},
        ///                     {"Key": "bActivo", "value": "string" , "required": false},
        ///                     {"Key": "dtactualizacion", "value": "string" , "required": false},
        ///                     {"Key": "vc20usuarioactualizacion", "value": "string" , "required": false},
        ///                     {"Key": "dtCreacion", "value": "string" , "required": false},
        ///                     {"Key": "vc20UsuarioCreacion", "value": "string" , "required": false},
        ///                     {"Key": "vcSAP", "value": "string" , "required": false},
        ///                     {"Key": "CEDIS", "value": "string" , "required": false},
        ///                     {"Key": "vc25NombreCorto", "value": "string" , "required": false},
        ///                     {"Key": "CedisVcDescripcion", "value": "string" , "required": false},
        ///                     {"Key": "OrigenUbicacionLat", "value": "string" , "required": false},
        ///                     {"Key": "OrigenUbicacionLon", "value": "string" , "required": false}
        ///             ]
        ///     }
        ///
        /// </remarks>

        [HttpPost("List")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<OriginQueryDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAsync([FromBody] FilterGrid filter)
        {
            var response = await originService.GetAsync(filter);
            return Ok(response);
        }

        /// <summary>
        /// Origin excel
        /// </summary>
        /// <param name='filter'></param>
        /// <returns>Origin excel stream</returns>
        /// <remarks>
        /// Sample Request:
        ///
        ///     POST /FilterGrid
        ///     {
        ///             "orderBy": { "column": "", "isDesc": 0 },//IDZONA,VC50NOMBRE,BPROPIO,BMENSUAL,BSERVIRPRIORIDAD,IMANIANA,ITARDE,INOCHE,VC10CLAVESICADI,ICLAVESIT,BCARGAAUT,BACTIVO,DTACTUALIZACION,VC20USUARIOACTUALIZACION,DTCREACION,VC20USUARIOCREACION,VCSAP,CEDIS,VC25NOMBRECORTO,CEDISVCDESCRIPCION,ORIGENUBICACIONLAT,ORIGENUBICACIONLON,
        ///             "paging":   { "pageNumber": 0, "pageSize": 0, "search": "string" },
        ///             "filters":  [
        ///                     {"Key": "IdZona", "value": "string" , "required": true},
        ///                     {"Key": "Vc50Nombre", "value": "string" , "required": false},
        ///                     {"Key": "bPropio", "value": "string" , "required": false},
        ///                     {"Key": "bMensual", "value": "string" , "required": false},
        ///                     {"Key": "bServirPrioridad", "value": "string" , "required": false},
        ///                     {"Key": "iManiana", "value": "string" , "required": false},
        ///                     {"Key": "iTarde", "value": "string" , "required": false},
        ///                     {"Key": "iNoche", "value": "string" , "required": false},
        ///                     {"Key": "vc10ClaveSicadi", "value": "string" , "required": false},
        ///                     {"Key": "iClaveSit", "value": "string" , "required": false},
        ///                     {"Key": "bCargaAut", "value": "string" , "required": false},
        ///                     {"Key": "bActivo", "value": "string" , "required": false},
        ///                     {"Key": "dtactualizacion", "value": "string" , "required": false},
        ///                     {"Key": "vc20usuarioactualizacion", "value": "string" , "required": false},
        ///                     {"Key": "dtCreacion", "value": "string" , "required": false},
        ///                     {"Key": "vc20UsuarioCreacion", "value": "string" , "required": false},
        ///                     {"Key": "vcSAP", "value": "string" , "required": false},
        ///                     {"Key": "CEDIS", "value": "string" , "required": false},
        ///                     {"Key": "vc25NombreCorto", "value": "string" , "required": false},
        ///                     {"Key": "CedisVcDescripcion", "value": "string" , "required": false},
        ///                     {"Key": "OrigenUbicacionLat", "value": "string" , "required": false},
        ///                     {"Key": "OrigenUbicacionLon", "value": "string" , "required": false}
        ///             ],
        ///             "Columns":  [
        ///                     {"Key": "IdZona", "value": "string"},
        ///                     {"Key": "Vc50Nombre", "value": "string"},
        ///                     {"Key": "bPropio", "value": "string"},
        ///                     {"Key": "bMensual", "value": "string"},
        ///                     {"Key": "bServirPrioridad", "value": "string"},
        ///                     {"Key": "iManiana", "value": "string"},
        ///                     {"Key": "iTarde", "value": "string"},
        ///                     {"Key": "iNoche", "value": "string"},
        ///                     {"Key": "vc10ClaveSicadi", "value": "string"},
        ///                     {"Key": "iClaveSit", "value": "string"},
        ///                     {"Key": "bCargaAut", "value": "string"},
        ///                     {"Key": "bActivo", "value": "string"},
        ///                     {"Key": "dtactualizacion", "value": "string"},
        ///                     {"Key": "vc20usuarioactualizacion", "value": "string"},
        ///                     {"Key": "dtCreacion", "value": "string"},
        ///                     {"Key": "vc20UsuarioCreacion", "value": "string"},
        ///                     {"Key": "vcSAP", "value": "string"},
        ///                     {"Key": "CEDIS", "value": "string"},
        ///                     {"Key": "vc25NombreCorto", "value": "string"},
        ///                     {"Key": "CedisVcDescripcion", "value": "string"},
        ///                     {"Key": "OrigenUbicacionLat", "value": "string"},
        ///                     {"Key": "OrigenUbicacionLon", "value": "string"}
        ///             ],
        ///     }
        ///
        /// </remarks>

        [HttpPost("Export")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<string>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> ExportAsync([FromBody] FilterGrid filter)
        {
            var response = await originService.ExportAsync(filter);
            return Ok(response);
        }

        [HttpGet("by-Zone-everyone")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<OriginDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetByZoneOptionAllAsync([FromQuery] FilterZone filter, bool isagreement, string idFiltrados)
        {
            var response = await this.originService.GetByZoneAllAsync(filter, isagreement, idFiltrados);
            return Ok(response);
        }

        [HttpGet("RestrictionAvailable")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<OriginDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetRestrictionAsync([FromQuery] PaginationQuery filter, int idzone, long tid)
        {
            var response = await this.originService.GetRestrictionAsync(filter, idzone, tid);
            return Ok(response);
        }

        [HttpGet("RestrictionAvailableOneToOne")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<OriginDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetRestrictionOneToOneAsync([FromQuery] PaginationQuery filter, int idzone, long tid)
        {
            var response = await this.originService.GetRestrictionOneToOneAsync(filter, idzone, tid);
            return Ok(response);
        }

        [HttpGet("RestrictionInvolved")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<OriginDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetRestrictionInvolvedAsync([FromQuery] PaginationQuery filter, int idzone, long tid)
        {
            var response = await this.originService.GetRestrictionInvolvedAsync(filter, idzone, tid);
            return Ok(response);
        }

        [HttpGet("RestrictionInvolvedOneToOne")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<OriginDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetRestrictionInvolvedOneToOneAsync([FromQuery] PaginationQuery filter, int idzone, long tid)
        {
            var response = await this.originService.GetRestrictionInvolvedOneToOneAsync(filter, idzone, tid);
            return Ok(response);
        }

        [HttpGet("OriginNewDistance")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<OriginDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetOriginNewDistanceAsync([FromQuery] PaginationQuery filter, int idorigin)
        {
            var response = await this.originService.GetOriginNewDistanceAsync(filter,idorigin);
            return Ok(response);
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> PutAsync([FromBody] OriginInsertDto data)
        {
            var response = await this.originService.InsertAsync(data);
            return Ok(response);
        }

        [HttpPost("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> PostAsync(int id, [FromBody] OriginInsertDto data)
        {
            var response = await this.originService.UpdateAsync(id, data);
            return Ok(response);
        }

        [HttpPut, Route("Restriction")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task PutRestrictionAsync([FromBody] OriginRestrictionDto data)
        {
            await this.originService.InsertRestrictionAsync(data);
        }

        [HttpPut, Route("RestrictionOneToOne")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task PutRestrictionOneToOneAsync([FromBody] OriginRestrictionDto data)
        {
            await this.originService.InsertRestrictionOneToOneAsync(data);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DeleteAsync(string id,  [FromQuery, HiddenParam] string vc20Usuario)
        {
            var response = await this.originService.DeleteAsync(id, vc20Usuario);
            return Ok(response);
        }
    }
}
