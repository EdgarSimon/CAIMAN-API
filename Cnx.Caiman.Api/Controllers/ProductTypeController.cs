using Cnx.Caiman.Core.DTOs.ProductType;
using Cnx.Caiman.Core.Interfaces.Services;
using Cnx.Caiman.Infrastructure.Filters;
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
    [Route("api/productType")]
    [Produces("application/json")]
    [ApiController]
    public class ProductTypeController : Controller
    {
        private readonly IProductTypeService productTypeService;

        public ProductTypeController(IProductTypeService productTypeService)
        {
            this.productTypeService = productTypeService;
        }

        /// <summary>
        /// Product Type collection
        /// </summary>
        /// <param name="filter">* value requeried</param>
        /// <param name="IdZone">* value requeried</param>
        /// <returns>Product type collection</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET
        ///
        /// </remarks>
        [HttpGet("List")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<ProductTypeDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> GetAsync([FromQuery] PaginationQuery filter, int IdZone)
        {
            var response = await this.productTypeService.GetAsync(IdZone, filter);
            return Ok(response);
        }

        /// <summary>
        /// Product Type collection
        /// </summary>
        /// <param name="model">* value requeried</param>
        /// <returns>Product type collection</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT
        ///     {
        ///       "idZona": 0,
        ///       "vcTipoProducto": "string"
        ///     }
        ///
        /// </remarks>
        [HttpPut, Route("Insert")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task InsertAsync([FromBody] ProductTypeInsertDto model)
        {
            await this.productTypeService.InsertAsync(model);
        }

        /// <summary>
        /// Product Type collection
        /// </summary>
        /// <param name="data">* value requeried</param>
        /// <returns>Product type collection</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST
        ///     {
        ///       * "idTipoProducto": 0,
        ///       * "vcTipoProducto": "string"
        ///     }
        ///
        /// </remarks>
        [HttpPost("Update")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task PostAsync([FromBody] ProductTypeUpdateDto data)
        {
            await this.productTypeService.UpdateAsync(data);
        }

        /// <summary>
        /// Product Type collection
        /// </summary>
        /// <param name="idTipoProducto">* value requeried</param>
        /// <param name="Vc20Usuario">Hidden</param>
        /// <returns>Product type collection</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     DELETE
        ///
        /// </remarks>
        [HttpDelete, Route("Delete")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task Delete(int idTipoProducto, [HiddenParam] string Vc20Usuario)
        {
            await this.productTypeService.DeleteAsync(idTipoProducto, Vc20Usuario);
        }
    }
}
