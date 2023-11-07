using Cnx.Caiman.Core.DTOs.Catalog;
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
    [Route("api/Catalog")]
    [ApiController]
    public class CatalogController : Controller
    {

        private readonly ICatalogService CatalogService;

        public CatalogController(ICatalogService CatalogService)
        {
            this.CatalogService = CatalogService;
        }

        [HttpPost, Route("ListProductZone")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<CatalogDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> GetProductZone([FromBody] FilterGrid filter)
        {
            var response = await this.CatalogService.GetCatalogProductAsync(filter);
            return Ok(response);
        }
    }
}
