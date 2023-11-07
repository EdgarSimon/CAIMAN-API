using Cnx.Caiman.Core.DTOs;
using Cnx.Caiman.Core.DTOs.SubZone;
using Cnx.Caiman.Core.Entities.Filters;
using Cnx.Caiman.Core.Interfaces.Services;
using Cnx.Caiman.Infrastructure.Filters;
using Cemex.Core.Entities;
using Cemex.Core.Entities.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Cnx.Caiman.Api.Controllers
{
    //[Authorize]
    [Produces("application/json")]
    [Route("api/subzone")]
    [ApiController]
    public class SubZoneController : Controller
    {
        private readonly ISubZoneService subZoneService;

        public SubZoneController(ISubZoneService subZoneService)
        {
            this.subZoneService = subZoneService;
        }

        [HttpGet, Route("List")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<SubZoneDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> Get([FromQuery] PaginationQuery filter, int idzone)
        {
            var response = await this.subZoneService.GetAsync(filter, idzone);

            return Ok(response);
        }

        [HttpGet, Route("GetAllByZona")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<SubZoneDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> GetAllByZonaAsync([FromQuery] ZoneIntFilter filter)
        {
            var response = await this.subZoneService.GetAllByZonaAsync(filter);

            return Ok(response);
        }

        [HttpGet("by-Zone-everyone")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<SubZoneDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetByZoneOptionAllAsync([FromQuery] ZoneIntFilter filter)
        {
            var response = await this.subZoneService.GetByZoneOptionAllAsync(filter);
            return Ok(response);
        }

        [HttpPut, Route("Insert")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task Put([FromBody] SubZoneInsertDto model)
        {
            await this.subZoneService.PutAsync(model);
        }

        [HttpPost, Route("Update")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task Post([FromBody] SubZoneUpdateDto model)
        {
            await this.subZoneService.PostAsync(model);
        }

        [HttpDelete, Route("Delete")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task Delete(int idsubzone, [HiddenParam] string Vc20Usuario)
        {
            await this.subZoneService.DeleteAsync(idsubzone, Vc20Usuario);
        }
    }
}
