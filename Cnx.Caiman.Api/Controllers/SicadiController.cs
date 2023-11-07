using Cnx.Caiman.Core.DTOs.Concret;
using Cnx.Caiman.Core.DTOs.Destination;
using Cnx.Caiman.Core.Interfaces.Services;
using Cemex.Core.Entities;
using Cemex.Core.Entities.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Cnx.Caiman.Api.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/Sicadi")]
    [ApiController]
    public class SicadiController : Controller
    {
        private readonly ISicadiService sicadiService;

        public SicadiController(ISicadiService sicadiService)
        {
            this.sicadiService = sicadiService;
        }

        [HttpGet, Authorize, Route("ListInfo")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<List<KeyValuePair<string, int>>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAsync([FromQuery] int idZone)
        {
            var response = await this.sicadiService.GetSicadiAsync(idZone);
            return Ok(response);
        }

        [HttpGet("ListSinEnlace")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<DestinationDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> ListDetinacionAsync([FromQuery] PaginationQuery filter, int idzone)
        {
            var response = await this.sicadiService.ListDetinacionAsync(filter, idzone);
            return Ok(response);
        }

        [HttpPost("Update"), Authorize]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateAsync([FromBody] SicadiDemandDto model)
        {
            await this.sicadiService.UpdateAsync(model.IdZone);
            return Ok();
        }
    }
}
