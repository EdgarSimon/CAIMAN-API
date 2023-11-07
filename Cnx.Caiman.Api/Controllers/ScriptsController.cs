using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Cnx.Caiman.Core.DTOs.Scripts;
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
    [Route("api/Script")]
    [ApiController]
    public class ScriptsController : ControllerBase
    {
        private readonly IScriptService scriptService;

        public ScriptsController(IScriptService scriptService)
        {
            this.scriptService = scriptService;
        }

        /// <summary>
        /// Scripts excel
        /// </summary>
        /// <param name='filter'></param>
        /// <returns>Scripts excel stream</returns>
        /// <remarks>
        /// Sample Request:
        ///
        ///     POST /FilterGrid
        ///     {
        ///             "orderBy": { "column": "", "isDesc": 0 },//NOMBRE,VCDESCRIPCION,BACTIVO,VCUSUARIOCREO,DTCREACION,VCUSUARIOMODIFICO,DTMODIFICADO,BSTATUS,STATUSMESSAGE,RETURNTYPE,
        ///             "paging":   { "pageNumber": 0, "pageSize": 0, "search": "string" },
        ///             "filters":  [
        ///                     {"Key": "Nombre", "value": "string" , "required": false},
        ///                     {"Key": "VcDescripcion", "value": "string" , "required": false},
        ///                     {"Key": "BActivo", "value": "string" , "required": false},
        ///                     {"Key": "vcUsuarioCreo", "value": "string" , "required": false},
        ///                     {"Key": "DtCreacion", "value": "string" , "required": false},
        ///                     {"Key": "VcUsuarioModifico", "value": "string" , "required": false},
        ///                     {"Key": "DtModificado", "value": "string" , "required": false},
        ///                     {"Key": "BStatus", "value": "string" , "required": false},
        ///                     {"Key": "StatusMessage", "value": "string" , "required": false},
        ///                     {"Key": "ReturnType", "value": "string" , "required": false}
        ///             ]
        ///     }
        ///
        /// </remarks>

        // GET api/<ValuesController>/5
        [HttpPost("List")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<ScriptDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAsync([FromBody] FilterGrid filter)
        {
            var response = await this.scriptService.GetAsync(filter);
            return Ok(response);
        }

        /// <summary>
        /// Scripts excel
        /// </summary>
        /// <param name='filter'></param>
        /// <returns>Scripts excel stream</returns>
        /// <remarks>
        /// Sample Request:
        ///
        ///     POST /FilterGrid
        ///     {
        ///             "orderBy": { "column": "", "isDesc": 0 },//NOMBRE,VCDESCRIPCION,BACTIVO,VCUSUARIOCREO,DTCREACION,VCUSUARIOMODIFICO,DTMODIFICADO,BSTATUS,STATUSMESSAGE,RETURNTYPE,
        ///             "paging":   { "pageNumber": 0, "pageSize": 0, "search": "string" },
        ///             "filters":  [
        ///                     {"Key": "Nombre", "value": "string" , "required": false},
        ///                     {"Key": "VcDescripcion", "value": "string" , "required": false},
        ///                     {"Key": "BActivo", "value": "string" , "required": false},
        ///                     {"Key": "vcUsuarioCreo", "value": "string" , "required": false},
        ///                     {"Key": "DtCreacion", "value": "string" , "required": false},
        ///                     {"Key": "VcUsuarioModifico", "value": "string" , "required": false},
        ///                     {"Key": "DtModificado", "value": "string" , "required": false},
        ///                     {"Key": "BStatus", "value": "string" , "required": false},
        ///                     {"Key": "StatusMessage", "value": "string" , "required": false},
        ///                     {"Key": "ReturnType", "value": "string" , "required": false}
        ///             ],
        ///             "Columns":  [
        ///                     {"Key": "Nombre", "value": "string"},
        ///                     {"Key": "VcDescripcion", "value": "string"},
        ///                     {"Key": "BActivo", "value": "string"},
        ///                     {"Key": "vcUsuarioCreo", "value": "string"},
        ///                     {"Key": "DtCreacion", "value": "string"},
        ///                     {"Key": "VcUsuarioModifico", "value": "string"},
        ///                     {"Key": "DtModificado", "value": "string"},
        ///                     {"Key": "BStatus", "value": "string"},
        ///                     {"Key": "StatusMessage", "value": "string"},
        ///                     {"Key": "ReturnType", "value": "string"}
        ///             ],
        ///     }
        ///
        /// </remarks>

        [HttpPost("Export")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<string>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> ExportAsync([FromBody] FilterGrid filter)
        {
            var response = await this.scriptService.ExportAsync(filter);
            return Ok(response);
        }

        
        [HttpPost("ExuecuteScript")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<string>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> ExecuteScriptAsync([FromBody] ScriptBody body)
        {
            var response = await this.scriptService.ExecuteScriptAsync(body);
            return Ok(response);
        }
    }
}
