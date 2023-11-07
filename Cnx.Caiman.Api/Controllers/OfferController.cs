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
    [Route("api/offer")]
    [ApiController]
    public class OfferController : Controller
    {
        private readonly IOfferService offerService;

        public OfferController(IOfferService offerService)
        {
            this.offerService = offerService;
        }

        [HttpGet, Route("Search/{idzone}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<bool>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> Get(int idzone)
        {
            var response = await this.offerService.GetOfferAsync(idzone);

            return Ok(response);
        }

        /// <summary>
        /// Lista de oferta 
        /// </summary>
        /// <param name="filter">* value requeried</param>
        /// <returns>retorna lista de oferta</returns>
        /// <remarks>
        /// Sample Request:
        /// 
        ///         POST /FilterGrid
        ///         {
        ///                 "orderBy": { "column": "", "isDesc": 0 },  dtFecha, Origen, Producto, Oferta, Asignado, Disponible, Precio, Observaciones, vcComentarioAct
        ///                 "paging":   { "pageNumber": 0, "pageSize": 0, "search": "string" },
        ///                 "filters":  [
        ///                       * {"Key": "dtFecha", "value": "string"},
        ///                       * {"Key": "idZona", "value": "string"},
        ///                       * {"Key": "idUsuario", "value": "string"},
        ///                         {"Key": "Origen", "value": "string"},
        ///                         {"Key": "Oferta", "value": "string"},
        ///                         {"Key": "Asignado", "value": "string"}
        ///                         {"Key": "Disponible", "value": "string"}
        ///                         {"Key": "Precio", "value": "string"}
        ///                         {"Key": "Observaciones", "value": "string"}
        ///                         {"Key": "vcComentarioAct", "value": "string"}
        ///
        ///                 ]
        ///         }
        ///
        /// </remarks>
        [HttpPost, Route("ListAll")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<ListOfferDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> Get([FromBody] FilterGrid filter)
        {
            var response = await this.offerService.ListSearchAsync(filter);

            return Ok(response);
        }

        /// <summary>
        /// Lista de oferta 
        /// </summary>
        /// <param name="filter">* value requeried</param>
        /// <returns>retorna lista de oferta</returns>
        /// <remarks>
        /// Sample Request:
        /// 
        ///         POST /FilterGrid
        ///         {
        ///                 "orderBy": { "column": "", "isDesc": 0 },  dtFecha, Origen, Producto, Oferta, Asignado, Disponible, Precio, Observaciones, vcComentarioAct
        ///                 "paging":   { "pageNumber": 0, "pageSize": 0, "search": "string" },
        ///                 "filters":  [
        ///                       * {"Key": "dtFecha", "value": "string"},
        ///                       * {"Key": "idZona", "value": "string"},
        ///                       * {"Key": "idUsuario", "value": "string"},
        ///                         {"Key": "Origen", "value": "string"},
        ///                         {"Key": "Oferta", "value": "string"},
        ///                         {"Key": "Asignado", "value": "string"}
        ///                         {"Key": "Disponible", "value": "string"}
        ///                         {"Key": "Precio", "value": "string"}
        ///                         {"Key": "Observaciones", "value": "string"}
        ///                         {"Key": "vcComentarioAct", "value": "string"}
        ///
        ///                 ]
        ///         }
        ///
        /// </remarks>
        [HttpPost, Route("Export")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<string>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> ExportAsync([FromBody] FilterGrid filter)
        {
            var response = await this.offerService.ExportAsync(filter);
            return Ok(response);
        }

        /// <summary>
        /// Lista de oferta 
        /// </summary>
        /// <param name="filter">* value requeried</param>
        /// <returns>retorna lista de oferta</returns>
        /// <remarks>
        /// Sample Request:
        /// 
        ///         POST /FilterGrid
        ///         {
        ///                 "orderBy": { "column": "", "isDesc": 0 },  dtFecha, Origen, Producto, Oferta,OfertaPantalla,ORec,ECli,EConc,  Asignado, Disponible, Precio, Observaciones, vcComentarioAct
        ///                 "paging":   { "pageNumber": 0, "pageSize": 0, "search": "string" },
        ///                 "filters":  [
        ///                       * {"Key": "dtFecha", "value": "string"},
        ///                       * {"Key": "idZona", "value": "string"},
        ///                       * {"Key": "idUsuario", "value": "string"},
        ///                         {"Key": "Origen", "value": "string"},
        ///                         {"Key": "producto", "value": "string"},
        ///                         {"Key": "Oferta", "value": "string"},
        ///                         {"Key": "OfertaPantalla", "value": "string"},
        ///                         {"Key": "ORec", "value": "string"},
        ///                         {"Key": "ECli", "value": "string"},
        ///                         {"Key": "EConc", "value": "string"},
        ///                         {"Key": "Asignado", "value": "string"}
        ///                         {"Key": "Disponible", "value": "string"}
        ///                         {"Key": "Precio", "value": "string"}
        ///                         {"Key": "Observaciones", "value": "string"}
        ///                         {"Key": "vcComentarioAct", "value": "string"}
        ///
        ///                 ]
        ///         }
        ///
        /// </remarks>
        [HttpPost, Route("ListAll2")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<ListOfferDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> GetList2([FromBody] FilterGrid filter)
        {
            var response = await this.offerService.ListSearch2Async(filter);

            return Ok(response);
        }

        /// <summary>
        /// Lista de oferta 
        /// </summary>
        /// <param name="filter">* value requeried</param>
        /// <returns>retorna lista de oferta</returns>
        /// <remarks>
        /// Sample Request:
        /// 
        ///         POST /FilterGrid
        ///         {
        ///                 "orderBy": { "column": "", "isDesc": 0 },  dtFecha, Origen, Producto, Oferta,OfertaPantalla,ORec,ECli,EConc,  Asignado, Disponible, Precio, Observaciones, vcComentarioAct
        ///                 "paging":   { "pageNumber": 0, "pageSize": 0, "search": "string" },
        ///                 "filters":  [
        ///                       * {"Key": "dtFecha", "value": "string"},
        ///                       * {"Key": "idZona", "value": "string"},
        ///                       * {"Key": "idUsuario", "value": "string"},
        ///                         {"Key": "Origen", "value": "string"},
        ///                         {"Key": "producto", "value": "string"},
        ///                         {"Key": "Oferta", "value": "string"},
        ///                         {"Key": "OfertaPantalla", "value": "string"},
        ///                         {"Key": "ORec", "value": "string"},
        ///                         {"Key": "ECli", "value": "string"},
        ///                         {"Key": "EConc", "value": "string"},
        ///                         {"Key": "Asignado", "value": "string"}
        ///                         {"Key": "Disponible", "value": "string"}
        ///                         {"Key": "Precio", "value": "string"}
        ///                         {"Key": "Observaciones", "value": "string"}
        ///                         {"Key": "vcComentarioAct", "value": "string"}
        ///
        ///                 ]
        ///         }
        ///
        /// </remarks>
        [HttpPost, Route("Export2")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<string>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Export2Async([FromBody] FilterGrid filter)
        {
            var response = await this.offerService.Export2Async(filter);
            return Ok(response);
        }

        [HttpGet, Route("ValidateOrden")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<ValidationDto>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> ValidateOrdenAsync([FromQuery] int idzone, DateTime date)
        {
            var response = await this.offerService.ShowPhotoAsync(idzone, date);

            return Ok(response);
        }


        [HttpGet, Route("InfoCapacity")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<InfoCapacityDto>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> InfoCapacityAsync([FromQuery] OfferDto model)
        {
            var response = await this.offerService.InfoCapacityAsync(model);

            return Ok(response);
        }

        [HttpPost, Route("Update")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task Post([FromBody] OfferUpdateDto model)
        {
            await this.offerService.UpdateOfferAsync(model);
        }

        [HttpPut, Route("InsertPhoto")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task Put([FromBody] OfferInsertDto model)
        {
            await this.offerService.InsertOfferAsync(model);
        }

        [HttpPost, Route("UpdateTwo")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task PostTwo([FromBody] OfferUpdateTwoDto model)
        {
            await this.offerService.UpdateOfferTwoAsync(model);
        }
    }
}
