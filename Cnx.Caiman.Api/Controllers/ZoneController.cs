using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Cnx.Caiman.Core.DTOs;
using Cnx.Caiman.Core.DTOs.Zone;
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
    [Route("api/zone")]
    [ApiController]
    public class ZoneController : ControllerBase
    {
        private readonly IZoneService zoneService;
        public ZoneController(IZoneService zoneService)
        {
            this.zoneService = zoneService;
        }

        /// <summary>
        /// Zona
        /// </summary>
        /// <param name='filter'></param>
        /// <returns>Zona Collection</returns>
        /// <remarks>
        /// Sample Request:
        ///
        ///     POST /FilterGrid
        ///     {
        ///             "orderBy": { "column": "", "isDesc": 0 },//IDUSUARIO,VC50NOMBRE,NUNIDADESPORVIAJE,BMANEJATIEMPOS,BTARIFAUNICA,BGRANEL,BSIT,BOPTIMIZADORFULL,BOFERTA2,DTCREACION,DTACTUALIZACION,VC20USUARIOCREACION,VC20USUARIOACTUALIZACION,MEDICIONVC50NOMBRE,
        ///             "paging":   { "pageNumber": 0, "pageSize": 0, "search": "string" },
        ///             "filters":  [
        ///                     {"Key": "idusuario", "value": "string"},
        ///                     {"Key": "vc50Nombre", "value": "string"},
        ///                     {"Key": "nunidadesporviaje", "value": "string"},
        ///                     {"Key": "bManejaTiempos", "value": "string"},
        ///                     {"Key": "bTarifaUnica", "value": "string"},
        ///                     {"Key": "bGranel", "value": "string"},
        ///                     {"Key": "bSit", "value": "string"},
        ///                     {"Key": "bOptimizadorFull", "value": "string"},
        ///                     {"Key": "bOferta2", "value": "string"},
        ///                     {"Key": "dtCreacion", "value": "string"},
        ///                     {"Key": "dtActualizacion", "value": "string"},
        ///                     {"Key": "vc20UsuarioCreacion", "value": "string"},
        ///                     {"Key": "vc20UsuarioActualizacion", "value": "string"},
        ///                     {"Key": "MedicionVc50nombre", "value": "string"}
        ///             ],
        ///     }
        ///
        /// </remarks>

        [HttpPost, Route("List")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<ZoneDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> GetAsync([FromBody] FilterGrid filter)
        {
            var response = await zoneService.ListAsync(filter);
            return Ok(response);
        }

        /// <summary>
        /// Zona excel
        /// </summary>
        /// <param name='filter'></param>
        /// <returns>Zona excel stream</returns>
        /// <remarks>
        /// Sample Request:
        ///
        ///     POST /FilterGrid
        ///     {
        ///             "orderBy": { "column": "", "isDesc": 0 },//IDUSUARIO,VC50NOMBRE,NUNIDADESPORVIAJE,BMANEJATIEMPOS,BTARIFAUNICA,BGRANEL,BSIT,BOPTIMIZADORFULL,BOFERTA2,DTCREACION,DTACTUALIZACION,VC20USUARIOCREACION,VC20USUARIOACTUALIZACION,MEDICIONVC50NOMBRE,
        ///             "paging":   { "pageNumber": 0, "pageSize": 0, "search": "string" },
        ///             "filters":  [
        ///                     {"Key": "idusuario", "value": "string"},
        ///                     {"Key": "vc50Nombre", "value": "string"},
        ///                     {"Key": "nunidadesporviaje", "value": "string"},
        ///                     {"Key": "bManejaTiempos", "value": "string"},
        ///                     {"Key": "bTarifaUnica", "value": "string"},
        ///                     {"Key": "bGranel", "value": "string"},
        ///                     {"Key": "bSit", "value": "string"},
        ///                     {"Key": "bOptimizadorFull", "value": "string"},
        ///                     {"Key": "bOferta2", "value": "string"},
        ///                     {"Key": "dtCreacion", "value": "string"},
        ///                     {"Key": "dtActualizacion", "value": "string"},
        ///                     {"Key": "vc20UsuarioCreacion", "value": "string"},
        ///                     {"Key": "vc20UsuarioActualizacion", "value": "string"},
        ///                     {"Key": "MedicionVc50nombre", "value": "string"}
        ///             ],
        ///             "Columns":  [
        ///                     {"Key": "idusuario", "value": "string"},
        ///                     {"Key": "vc50Nombre", "value": "string"},
        ///                     {"Key": "nunidadesporviaje", "value": "string"},
        ///                     {"Key": "bManejaTiempos", "value": "string"},
        ///                     {"Key": "bTarifaUnica", "value": "string"},
        ///                     {"Key": "bGranel", "value": "string"},
        ///                     {"Key": "bSit", "value": "string"},
        ///                     {"Key": "bOptimizadorFull", "value": "string"},
        ///                     {"Key": "bOferta2", "value": "string"},
        ///                     {"Key": "dtCreacion", "value": "string"},
        ///                     {"Key": "dtActualizacion", "value": "string"},
        ///                     {"Key": "vc20UsuarioCreacion", "value": "string"},
        ///                     {"Key": "vc20UsuarioActualizacion", "value": "string"},
        ///                     {"Key": "MedicionVc50nombre", "value": "string"}
        ///             ],
        ///     }
        ///
        /// </remarks>

        [HttpPost, Route("Export")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<string>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> ExportAsync([FromBody] FilterGrid filter)
        {
            var response = await zoneService.ExportAsync(filter);
            return Ok(response);
        }


        [HttpGet, Route("ListProfile")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<ZoneDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> Get([FromQuery] int iduser, int idzone)
        {
            var response = await zoneService.ListProfileZoneAsync(iduser, idzone);
            return Ok(response);
        }

        [HttpGet, Route("ProfileName")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<ZoneDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> Get([FromQuery] PaginationQuery filter, int idzone)
        {
            var response = await zoneService.ProfileNameAsync(filter, idzone);
            return Ok(response);
        }

        [HttpGet, Route("MeasuringList")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<MeasurementDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> Get()
        {
            var response = await zoneService.MeasuringListAsync();
            return Ok(response);
        }

        [HttpPut, Route("Insert")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task Put([FromBody] ZoneInsertDto model)
        {
            await this.zoneService.InsertAsync(model);
        }

        [HttpPost, Route("{idzone}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task Post(int idzone, [FromBody] ZoneInsertDto model)
        {
            await this.zoneService.UpdateAsync(idzone, model);
        }


        [HttpDelete, Route("Delete")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task Delete(int idzone)
        {
            await this.zoneService.DeleteAsync(idzone);
        }

        [HttpGet, Route("ListByUser/{iduser}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<ZoneDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> GetByUserAsync(int iduser)
        {
            var response = await zoneService.ListByUserAsync(iduser);
            return Ok(response);
        }

    }
}
