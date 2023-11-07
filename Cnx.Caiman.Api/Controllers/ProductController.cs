using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Cnx.Caiman.Core.DTOs.Product;
using Cnx.Caiman.Core.Entities.Filters;
using Cnx.Caiman.Core.Interfaces.Services;
using Cnx.Caiman.Infrastructure.Filters;
using Cemex.Core.Entities;
using Cemex.Core.Entities.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cnx.Caiman.Api.Controllers
{
    [Authorize]
    [Route("api/product")]
    [Produces("application/json")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet("by-Zone-everyone")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<ProductDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> Get([FromQuery] FilterZone filter, bool isagreement, string idFiltrados)
        {
            var response = await productService.GetByZoneAllAsync(filter, isagreement, idFiltrados);
            return Ok(response);
        }

        [HttpGet("RestrictionAvailable")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<ProductDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetRestrictionAsync([FromQuery] PaginationQuery filter, int idzone, long tid)
        {
            var response = await this.productService.GetRestrictionAsync(filter, idzone, tid);
            return Ok(response);
        }

        [HttpGet("RestrictionAvailableOneToOne")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<ProductDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetRestrictionOneToOneAsync([FromQuery] PaginationQuery filter, int idzone, long tid)
        {
            var response = await this.productService.GetRestrictionOneToOneAsync(filter, idzone, tid);
            return Ok(response);
        }

        [HttpGet("RestrictionInvolved")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<ProductDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetRestrictionInvolvedAsync([FromQuery] PaginationQuery filter, int idzone, long tid)
        {
            var response = await this.productService.GetRestrictionInvolvedAsync(filter, idzone, tid);
            return Ok(response);
        }

        [HttpGet("RestrictionInvolvedOneToOne")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<ProductDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetRestrictionInvolvedOneToOneAsync([FromQuery] PaginationQuery filter, int idzone, long tid)
        {
            var response = await this.productService.GetRestrictionInvolvedOneToOneAsync(filter, idzone, tid);
            return Ok(response);
        }

        [HttpPut, Route("Restriction")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task PutRestrictionAsync([FromBody] ProductRestrictionDto data)
        {
            await this.productService.InsertRestrictionAsync(data);
        }

        [HttpPut, Route("RestrictionOneToOne")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task PutRestrictionOneToOneAsync([FromBody] ProductRestrictionDto data)
        {
            await this.productService.InsertRestrictionOneToOneAsync(data);
        }

        /// <summary>
        /// Product
        /// </summary>
        /// <param name='filter'></param>
        /// <returns>Product Collection</returns>
        /// <remarks>
        /// Sample Request:
        ///
        ///     POST /FilterGrid
        ///     {
        ///             "orderBy": { "column": "", "isDesc": 0 },//IDZONA,IDPRODUCTO,VC50NOMBRE,VC10CLAVESICLO,ICLAVESIT,DTACTUALIZACION,VC20USUARIOACTUALIZACION,DTCREACION,VC20USUARIOCREACION,IDPROD55,VC25NOMBRECORTO,TIPOPRODUCTOVC20TIPOPRODUCTO,
        ///             "paging":   { "pageNumber": 0, "pageSize": 0, "search": "string" },
        ///             "filters":  [
        ///                     {"Key": "idZona", "value": "string" , "required": true},
        ///                     {"Key": "idproducto", "value": "string" , "required": false},
        ///                     {"Key": "vc50nombre", "value": "string" , "required": false},
        ///                     {"Key": "vc10clavesiclo", "value": "string" , "required": false},
        ///                     {"Key": "iclavesit", "value": "string" , "required": false},
        ///                     {"Key": "dtactualizacion", "value": "string" , "required": false},
        ///                     {"Key": "vc20usuarioactualizacion", "value": "string" , "required": false},
        ///                     {"Key": "dtCreacion", "value": "string" , "required": false},
        ///                     {"Key": "vc20UsuarioCreacion", "value": "string" , "required": false},
        ///                     {"Key": "IdProd55", "value": "string" , "required": false},
        ///                     {"Key": "vc25NombreCorto", "value": "string" , "required": false},
        ///                     {"Key": "TipoProductoVc20tipoproducto", "value": "string" , "required": false}
        ///             ]
        ///     }
        ///
        /// </remarks>

        [HttpPost, Route("List")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<ProductDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> GetAsync([FromBody] FilterGrid filter)
        {
            var response = await productService.GetAsync(filter);
            return Ok(response);
        }
        /// <summary>
        /// Product excel
        /// </summary>
        /// <param name='filter'></param>
        /// <returns>Product excel stream</returns>
        /// <remarks>
        /// Sample Request:
        ///
        ///     POST /FilterGrid
        ///     {
        ///             "orderBy": { "column": "", "isDesc": 0 },//IDZONA,IDPRODUCTO,VC50NOMBRE,VC10CLAVESICLO,ICLAVESIT,DTACTUALIZACION,VC20USUARIOACTUALIZACION,DTCREACION,VC20USUARIOCREACION,IDPROD55,VC25NOMBRECORTO,TIPOPRODUCTOVC20TIPOPRODUCTO,
        ///             "paging":   { "pageNumber": 0, "pageSize": 0, "search": "string" },
        ///             "filters":  [
        ///                     {"Key": "idZona", "value": "string" , "required": true},
        ///                     {"Key": "idproducto", "value": "string" , "required": false},
        ///                     {"Key": "vc50nombre", "value": "string" , "required": false},
        ///                     {"Key": "vc10clavesiclo", "value": "string" , "required": false},
        ///                     {"Key": "iclavesit", "value": "string" , "required": false},
        ///                     {"Key": "dtactualizacion", "value": "string" , "required": false},
        ///                     {"Key": "vc20usuarioactualizacion", "value": "string" , "required": false},
        ///                     {"Key": "dtCreacion", "value": "string" , "required": false},
        ///                     {"Key": "vc20UsuarioCreacion", "value": "string" , "required": false},
        ///                     {"Key": "IdProd55", "value": "string" , "required": false},
        ///                     {"Key": "vc25NombreCorto", "value": "string" , "required": false},
        ///                     {"Key": "TipoProductoVc20tipoproducto", "value": "string" , "required": false}
        ///             ],
        ///             "Columns":  [
        ///                     {"Key": "idZona", "value": "string"},
        ///                     {"Key": "idproducto", "value": "string"},
        ///                     {"Key": "vc50nombre", "value": "string"},
        ///                     {"Key": "vc10clavesiclo", "value": "string"},
        ///                     {"Key": "iclavesit", "value": "string"},
        ///                     {"Key": "dtactualizacion", "value": "string"},
        ///                     {"Key": "vc20usuarioactualizacion", "value": "string"},
        ///                     {"Key": "dtCreacion", "value": "string"},
        ///                     {"Key": "vc20UsuarioCreacion", "value": "string"},
        ///                     {"Key": "IdProd55", "value": "string"},
        ///                     {"Key": "vc25NombreCorto", "value": "string"},
        ///                     {"Key": "TipoProductoVc20tipoproducto", "value": "string"}
        ///             ],
        ///     }
        ///
        /// </remarks>

        [HttpPost, Route("Export")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<string>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> ExportAsync([FromBody] FilterGrid filter)
        {
            var response = await productService.ExportAsync(filter);
            return Ok(response);
        }

        [HttpGet("GetProductsByOrigin")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<ProductDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> GetProductsByOriginAsync([FromQuery] PaginationQuery filter, int idOrigin)
        {
            var response = await productService.GetProductsByOriginAsync(idOrigin, filter);
            return Ok(response);
        }

        [HttpGet("GetProductDestinationById")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<ProductDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> GetProductDestinationByIdAsync([FromQuery] PaginationQuery filter, int idDestination)
        {
            var response = await productService.GetProductDestinationByIdAsync(idDestination, filter);
            return Ok(response);
        }

        [HttpGet("GetTypesProducts")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<TypeProductDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> GetTypesProductsAsync([FromQuery] int IdZone, bool? aplyAll)
        {
            var response = await productService.GetTypesProductsAsync(IdZone, aplyAll);
            return Ok(response);
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> InsertAsync([FromBody] ProductInsertDto data)
        {
            await productService.InsertAsync(data);
            return Ok();
        }
        
        [HttpPut("InsertShort")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> InsertShortAsync([FromBody] ProductShortInsertDto data)
        {
            await productService.InsertShortAsync(data);
            return Ok();
        }

        [HttpPut("InsertMonthly")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> InsertMonthlyAsync([FromBody] ProductInsertDto data)
        {
            await productService.InsertMonthlyAsync(data);
            return Ok();
        }

        [HttpPost("{IdProduct}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> UpdateAsync(int IdProduct,[FromBody] ProductInsertDto data)
        {
            await productService.UpdateAsync(IdProduct, data);
            return Ok();
        }

        [HttpDelete("{IdProduct}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> DeleteAsync(string IdProduct, [FromQuery, HiddenParam] string vc20Usuario)
        {
            await productService.DeleteAsync(IdProduct, vc20Usuario);
            return Ok();
        }

        [HttpGet("GetProductDistance")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<ProductDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> GetProductDistanceByIdAsync([FromQuery] PaginationQuery filter, int idDestination)
        {
            var response = await productService.GetProductDistanceByIdAsync(idDestination, filter);
            return Ok(response);
        }
    }
}
