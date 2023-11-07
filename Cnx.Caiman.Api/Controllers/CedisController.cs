using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Cnx.Caiman.Core.DTOs;
using Cnx.Caiman.Core.Entities.Filters;
using Cnx.Caiman.Core.Interfaces.Services;
using Cnx.Caiman.Infrastructure.Filters;
using Cemex.Core.Entities;
using Cemex.Core.Entities.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cnx.Caiman.Api.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/Cedis")]
    [ApiController]
    public class CedisController : ControllerBase
    {
        private readonly ICediService cedisService;
        
        public CedisController(ICediService cedisService)
        {
            this.cedisService = cedisService;
        }

        /// <summary>
        /// Request Cedi collection
        /// </summary>
        /// <param name="filter"></param>
        /// <returns>Cedi collection</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /FilterGrid
        ///     {
        ///         "orderBy":  { "column": "", "isDesc": 0 }, //VCSAP, VCDESCRIPCION, DTCREACION, DTMODIFICADO, VCUSUARIOMODIFICO
        ///         "paging":   { "pageNumber": 0, "pageSize": 0, "search": "string" },
        ///         "filters":  [
        ///                         { "key": "vcSap", "value": "string" },
        ///                         { "key": "vcDescripcion", "value": "string" },
        ///                         { "key": "dtCreacion", "value": "string" },
        ///                         { "key": "dtModificado", "value": "string" },
        ///                         { "key": "VcUsuarioModifico", "value": "string" }
        ///                     ]
        ///     }
        ///
        /// </remarks>
        [HttpPost("list")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<CediDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAsync([FromBody] FilterGrid filter)
        {
            var response = await this.cedisService.GetAsync(filter);
            return Ok(response);
        }

        /// <summary>
        /// Request Cedi collection
        /// </summary>
        /// <param name="filter"></param>
        /// <returns>Cedi collection</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /FilterGrid
        ///     {
        ///         "orderBy":  { "column": "", "isDesc": 0 }, //VCSAP, VCDESCRIPCION, DTCREACION, DTMODIFICADO, VCUSUARIOMODIFICO
        ///         "paging":   { "pageNumber": 0, "pageSize": 0, "search": "string" },
        ///         "filters":  [
        ///                         { "key": "vcSap", "value": "string" },
        ///                         { "key": "vcDescripcion", "value": "string" },
        ///                         { "key": "dtCreacion", "value": "string" },
        ///                         { "key": "dtModificado", "value": "string" },
        ///                         { "key": "VcUsuarioModifico", "value": "string" }
        ///                     ],
        ///         "columns":  [
        ///                         { "key": "vcSap", "value": "Sap" },
        ///                         { "key": "vcDescripcion", "value": "Description" },
        ///                     ]
        ///     }
        ///
        /// </remarks>
        [HttpPost("Export")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<string>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> ExportAsync([FromBody] FilterGrid filter)
        {
            var response = await this.cedisService.ExportAsync(filter);
            return Ok(response);
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> InsertAsync([FromBody] UpdateCedisDto data)
        {
            var response = await this.cedisService.InsertAsync(data);
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> PostAsync([FromBody] UpdateCedisDto data)
        {
            var response = await this.cedisService.UpdateAsync(data);
            return Ok(response);
        }

        [HttpDelete("{PrmVcSAP}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DeleteAsync(string PrmVcSAP,  [FromQuery, HiddenParam] string vc20Usuario)
        {
            await this.cedisService.DeleteAsync(PrmVcSAP, vc20Usuario);
            return Ok();
        }
    }
}
