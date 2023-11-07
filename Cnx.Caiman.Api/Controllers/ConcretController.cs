using Cnx.Caiman.Core.DTOs.Concret;
using Cnx.Caiman.Core.DTOs.Offer;
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
    [Route("api/Concret")]
    [ApiController]
    public class ConcretController : Controller
    {
        private readonly IConcretService concretService;

        public ConcretController(IConcretService concretService)
        {
            this.concretService = concretService;
        }

        /// <summary>
        /// Request Concret collection
        /// </summary>
        /// <param name="filter">* value requeried</param>
        /// <returns>concret collection</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /FilterGrid
        ///     {
        ///         "orderBy":  { "column": "", "isDesc": 0 }, //vcNombreDestino, vcNombreProducto, vcObservaciones
        ///         "paging":   { "pageNumber": 0, "pageSize": 0, "search": "string" },
        ///         "filters":  [
        ///                        * { "key": "dtFecha", "value": "string" }, 
        ///                        * { "key": "idZona", "value": "int" }, 
        ///                          { "key": "DestinoVc50Nombre", "value": "string" },
        ///                          { "key": "ProductoVc50Nombre", "value": "string" },
        ///                          { "key": "vcObservaciones", "value": "string" }
        ///                          { "key": "dtModificado", "value": "DateTime" }
        ///                          { "key": "VcUsuarioModifico", "value": "string" }
        ///                     ]
        ///     }
        ///
        /// </remarks>
        [HttpPost("List")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<DemandDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAsync([FromBody] FilterGrid filter)
        {
            var response = await this.concretService.GetConcretAsync(filter);
            return Ok(response);
        }

        /// <summary>
        /// Request Concret collection
        /// </summary>
        /// <param name="filter">* value requeried</param>
        /// <returns>concret collection</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /FilterGrid
        ///     {
        ///         "orderBy":  { "column": "", "isDesc": 0 }, //vcNombreDestino, vcNombreProducto, vcObservaciones
        ///         "paging":   { "pageNumber": 0, "pageSize": 0, "search": "string" },
        ///         "filters":  [
        ///                        * { "key": "dtFecha", "value": "string" }, 
        ///                        * { "key": "idZona", "value": "int" }, 
        ///                          { "key": "DestinoVc50Nombre", "value": "string" },
        ///                          { "key": "ProductoVc50Nombre", "value": "string" },
        ///                          { "key": "vcObservaciones", "value": "string" }
        ///                          { "key": "dtModificado", "value": "DateTime" }
        ///                          { "key": "VcUsuarioModifico", "value": "string" }
        ///                     ]
        ///     }
        ///
        /// </remarks>
        [HttpPost, Route("Export")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<string>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> ExportAsync([FromBody] FilterGrid filter)
        {
            var response = await this.concretService.ExportAsync(filter);
            return Ok(response);
        }

        [HttpGet, Route("ValidateOrden")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<ValidationDto>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> ValidateOrdenAsync([FromQuery] int idzone, DateTime date)
        {
            var response = await this.concretService.ShowPhotoAsync(idzone, date);

            return Ok(response);
        }

        [HttpGet, Route("InfoCapacity")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<InfoCapacityDto>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> InfoCapacityAsync([FromQuery] OfferDto model)
        {
            var response = await this.concretService.InfoCapacityAsync(model);

            return Ok(response);
        }

        [HttpPost, Route("Update")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task Post([FromBody] DemandUpdateDto model)
        {
            await this.concretService.UpdateAsync(model);
        }

        [HttpPut, Route("InsertPhoto")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task Put([FromBody] OfferInsertDto model)
        {
            await this.concretService.InsertPhotoAsync(model);
        }

        [HttpPost, Route("UpdateSicadi")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task UpdateSicadiAsync([FromBody] SicadiDemandDto model)
        {
            await this.concretService.UpdateSicadiAsync(model);
        }
    }
}
