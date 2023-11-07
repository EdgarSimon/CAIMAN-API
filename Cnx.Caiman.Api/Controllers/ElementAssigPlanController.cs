using Cnx.Caiman.Core.DTOs.ElementAssigPlan;
using Cnx.Caiman.Core.Interfaces.Services;
using Cemex.Core.Entities;
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
    [Route("api/ElementAssigPlan")]
    [ApiController]
    public class ElementAssigPlanController : Controller
    {

        private readonly IElementAssigPlanService elementAssigPlanService;

        public ElementAssigPlanController(IElementAssigPlanService elementAssigPlanService)
        {
            this.elementAssigPlanService = elementAssigPlanService;
        }

        /// <summary>
        /// List Stock collection
        /// </summary>
        /// <param name="idzone"></param>
        /// <param name="pivote"></param>
        /// <param name="idphoto"></param>
        /// <returns>List Stock collection</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET
        ///
        /// </remarks>
        [HttpGet("ListStock")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<List<ElementPlanStockDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> ListStockAsync([FromQuery] int idzone, int pivote, int idphoto)
        {
            var response = await this.elementAssigPlanService.ListStockAsync(idzone, pivote, idphoto);
            return Ok(response);
        }
        /// <summary>
        /// List Offer collection
        /// </summary>
        /// <param name="idzone"></param>
        /// <param name="pivote"></param>
        /// <param name="idphoto"></param>
        /// <returns>List offer collection</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET
        ///
        /// </remarks>
        [HttpGet("ListOffer")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<List<ElementPlanOfferDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> ListOfferAsync([FromQuery] int idzone, int pivote, int idphoto)
        {
            var response = await this.elementAssigPlanService.ListOfferAsync( idzone, pivote, idphoto);
            return Ok(response);
        }

        /// <summary>
        /// List shipper collection
        /// </summary>
        /// <param name="idzone"></param>
        /// <param name="pivote"></param>
        /// <param name="idphoto"></param>
        /// <returns>List shipper collection</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET
        ///
        /// </remarks>
        [HttpGet("ListShipper")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<List<ElementPlanTransportDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> ListTransportAsync([FromQuery] int idzone, int pivote, int idphoto)
        {
            var response = await this.elementAssigPlanService.ListTransportAsync(idzone, pivote, idphoto);
            return Ok(response);
        }

        /// <summary>
        /// List demand collection
        /// </summary>
        /// <param name="idzone"></param>
        /// <param name="pivote"></param>
        /// <param name="idphoto"></param>
        /// <returns>List demand collection</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET
        ///
        /// </remarks>
        [HttpGet("ListDeamnd")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<List<ElementPlanDemandDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> ListDemandAsync([FromQuery] int idzone, int pivote, int idphoto)
        {
            var response = await this.elementAssigPlanService.ListDemandAsync(idzone, pivote, idphoto);
            return Ok(response);
        }

        /// <summary>
        /// List demand collection
        /// </summary>
        /// <param name="Element">
        /// 0 - INVENTARIO
        /// 1 - OFERTA
        /// 2 - TRANSPORTE
        /// 3 - DEMANDA
        /// </param>
        /// <param name="IdZone">REQUERIED</param>
        /// <param name="IdPlanAssig">REQUERIED</param>
        /// <response code="200">Key: IdFoto, Value: Foto Descripcion</response>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET
        ///
        /// </remarks>
        [HttpGet, Route("ListPhoto")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<List<KeyValuePair<string, int>>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> ListPhotoAsync([FromQuery] int Element, int IdZone, int IdPlanAssig)
        {
            var response = await this.elementAssigPlanService.ListPhotoAsync(Element, IdZone, IdPlanAssig);
            return Ok(response);
        }

        /// <summary>
        /// List demand collection
        /// </summary>
        /// <param name="Element">
        /// 0 - INVENTARIO
        /// 1 - OFERTA
        /// 2 - TRANSPORTE
        /// 3 - DEMANDA
        /// </param>
        /// <param name="IdZone">REQUERIED</param>
        /// <param name="date">REQUERIED</param>
        /// <response code="200">Key: IdFoto, Value: Foto Descripcion</response>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET
        ///
        /// </remarks>
        [HttpGet, Route("DayPhotoList")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<List<KeyValuePair<string, int>>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DayPhotoListAsync([FromQuery] int Element, int IdZone, DateTime date)
        {
            var response = await this.elementAssigPlanService.DayPhotoListAsync(Element, IdZone, date);
            return Ok(response);
        }

        /// <summary>
        /// List photo collection
        /// </summary>
        /// <param name="Element">
        /// 0 - INVENTARIO
        /// 1 - OFERTA
        /// 2 - TRANSPORTE
        /// 3 - DEMANDA
        /// </param>
        /// <param name="IdZone">REQUERIED</param>
        /// <param name="IdPlanAssig">REQUERIED</param>
        /// <response code="200">Key: IdFoto, Value: IdEstatus</response>
        /// <response code="400">
        ///    
        /// </response>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET
        ///
        /// </remarks>
        [HttpGet, Route("SearchPhoto")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<KeyValuePair<int, int>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> SearchPhotoAsync([FromQuery] int Element, int IdZone, int IdPlanAssig)
        {
            var response = await this.elementAssigPlanService.SearchPhotoAsync(Element, IdZone, IdPlanAssig);
            return Ok(response);
        }

        /// <summary>
        ///  Update Element plan photo
        /// </summary>
        /// <param name="model">
        /// IMPORTANT Elemento --> VALUES
        /// 0 - INVENTARIO
        /// 1 - OFERTA
        /// 2 - TRANSPORTE
        /// 3 - DEMANDA
        /// </param>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST
        ///
        /// </remarks>
        [HttpPost, Route("Update")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateAsync([FromBody] ElementPlanUpdateDto model)
        {
            await this.elementAssigPlanService.UpdateAsync(model);

            return Ok();
        }
    }
}
