using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Cnx.Caiman.Core.DTOs;
using Cnx.Caiman.Core.Interfaces.Services;
using Cemex.Core.Entities.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cnx.Caiman.Api.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/procFile")]
    [ApiController]
    public class ProcFileController : ControllerBase
    {
        private readonly IProcFileService procExcelService;
        public ProcFileController(IProcFileService procExcelService)
        {
            this.procExcelService = procExcelService;
        }

        // PUT api/<ProcExcelController>/5
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Put([FromForm] ProcFileDto excelfile)
        {
            //Se deja el if debug para pruebas con el AD de CIBI por temas con el AD de CAIMAN
#if DEBUG
            excelfile.Vc20usuario = User.FindFirst("preferred_username")?.Value;
#else
            excelfile.Vc20usuario = User.Identity.Name;
#endif
            var response = await procExcelService.ReadAndImportedFileToSql(excelfile);
            return Ok();
        }

        // PUT api/<ProcExcelController>/5
        [HttpPost("List")]
        public async Task<IActionResult> GetAsync([FromBody] FilterGrid filter)
        {
            var response = await procExcelService.GetAsync(filter);
            return Ok(response);
        }

           // PUT api/<ProcExcelController>/5
        [HttpPost("Export")]
        public async Task<IActionResult> ExportAsync([FromBody] FilterGrid filter)
        {
            var response = await procExcelService.ExportAsync(filter);
            return Ok(response);
        }
    }
}
