using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Cnx.Caiman.Core.DTOs.CostOverrun;
using Cnx.Caiman.Core.Interfaces.Services;
using Cemex.Core.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cnx.Caiman.Api.Controllers
{
    [Route("api/CostOverrun")]
    [ApiController]
    public class CostOverrunController : ControllerBase
    {
        private readonly ICostOverrunService costOverrunService;

        public CostOverrunController(ICostOverrunService costOverrunService)
        {
            this.costOverrunService = costOverrunService;
        }

        [HttpGet("GetTypesOverrun")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<TypesCostOverrunDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAsync()
        {
            var response = await this.costOverrunService.GetTypesOverrunAsync();
            return Ok(response);
        }
    }
}
