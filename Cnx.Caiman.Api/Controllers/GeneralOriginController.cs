using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Cnx.Caiman.Core.DTOs.Origin;
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
    [Route("api/GeneralOriginController")]
    [ApiController]
    public class GeneralOriginController : ControllerBase
    {
        private readonly IGeneralOriginService generalOriginService;

        public GeneralOriginController(IGeneralOriginService generalOriginService)
        {
            this.generalOriginService = generalOriginService;
        }

        /// <summary>
        /// General origin
        /// </summary>
        /// <param name='filter'></param>
        /// <returns>General origin collactio </returns>
        /// <remarks>
        /// Sample Request:
        ///
        ///     POST /FilterGrid
        ///     {
        ///             "orderBy": { "column": "", "isDesc": 0 },//VCSAP,VC50NOMBRE,BPROPIO,BESLAB,CREADO,MODIFICADO,USUARIOMODIFICO,USUARIOCREO,MEDICIONVC50NOMBRE,
        ///             "paging":   { "pageNumber": 0, "pageSize": 0, "search": "string" },
        ///             "filters":  [
        ///                     {"Key": "vcSap", "value": "string"},
        ///                     {"Key": "vc50Nombre", "value": "string"},
        ///                     {"Key": "bPropio", "value": "string"},
        ///                     {"Key": "bEsLAB", "value": "string"},
        ///                     {"Key": "Creado", "value": "string"},
        ///                     {"Key": "Modificado", "value": "string"},
        ///                     {"Key": "UsuarioModifico", "value": "string"},
        ///                     {"Key": "UsuarioCreo", "value": "string"},
        ///                     {"Key": "MedicionVc50Nombre", "value": "string"}
        ///             ],
        ///     }
        ///
        /// </remarks>

        [HttpPost("List")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<GeneralOriginDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAsync([FromBody] FilterGrid filter)
        {
            var response = await this.generalOriginService.GetAsync(filter);
            return Ok(response);
        }

        /// <summary>
        /// General origin excel
        /// </summary>
        /// <param name='filter'></param>
        /// <returns>General origin excel stream</returns>
        /// <remarks>
        /// Sample Request:
        ///
        ///     POST /FilterGrid
        ///     {
        ///             "orderBy": { "column": "", "isDesc": 0 },//VCSAP,VC50NOMBRE,BPROPIO,BESLAB,CREADO,MODIFICADO,USUARIOMODIFICO,USUARIOCREO,MEDICIONVC50NOMBRE,
        ///             "paging":   { "pageNumber": 0, "pageSize": 0, "search": "string" },
        ///             "filters":  [
        ///                     {"Key": "vcSap", "value": "string"},
        ///                     {"Key": "vc50Nombre", "value": "string"},
        ///                     {"Key": "bPropio", "value": "string"},
        ///                     {"Key": "bEsLAB", "value": "string"},
        ///                     {"Key": "Creado", "value": "string"},
        ///                     {"Key": "Modificado", "value": "string"},
        ///                     {"Key": "UsuarioModifico", "value": "string"},
        ///                     {"Key": "UsuarioCreo", "value": "string"},
        ///                     {"Key": "MedicionVc50Nombre", "value": "string"}
        ///             ],
        ///             "Columns":  [
        ///                     {"Key": "vcSap", "value": "string"},
        ///                     {"Key": "vc50Nombre", "value": "string"},
        ///                     {"Key": "bPropio", "value": "string"},
        ///                     {"Key": "bEsLAB", "value": "string"},
        ///                     {"Key": "Creado", "value": "string"},
        ///                     {"Key": "Modificado", "value": "string"},
        ///                     {"Key": "UsuarioModifico", "value": "string"},
        ///                     {"Key": "UsuarioCreo", "value": "string"},
        ///                     {"Key": "MedicionVc50Nombre", "value": "string"}
        ///             ],
        ///     }
        ///
        /// </remarks>
        
        [HttpPost("Export")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<GeneralOriginDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> ExportAsync([FromBody] FilterGrid filter)
        {
            var response = await this.generalOriginService.ExportAsync(filter);
            return Ok(response);
        }

        [HttpGet("{ZoneId}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<GeneralOriginDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAvailableAsync(int ZoneId, [FromQuery] PaginationQuery filter)
        {
            var response = await this.generalOriginService.GetAvailableAsync(ZoneId,filter);
            return Ok(response);
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> PutAsync([FromBody] GeneralOriginInsertDto data)
        {
            var response = await this.generalOriginService.InsertAsync(data);
            return Ok(response);
        }

        [HttpPost("{originId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> PostAsync(int originId, [FromBody] GeneralOriginInsertDto data)
        {
            var response = await this.generalOriginService.UpdateAsync(originId, data);
            return Ok(response);
        }

        [HttpDelete("{PrmIdOrigen}/{PrmUsuario}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DeleteAsync(string PrmIdOrigen, string PrmUsuario)
        {
            var response = await this.generalOriginService.DeleteAsync(PrmIdOrigen, PrmUsuario);
            return Ok(response);
        }
    }
}
