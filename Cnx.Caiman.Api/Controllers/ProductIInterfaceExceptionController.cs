using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Cnx.Caiman.Core.DTOs.ProductInterface;
using Cnx.Caiman.Core.Interfaces.Services;
using Cemex.Core.Entities;
using Cemex.Core.Entities.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cnx.Caiman.Api.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/productInterfaceException")]
    [ApiController]
    public class ProductIInterfaceExceptionController : ControllerBase
    {
        
        private readonly IProductInterfaceExceptionService productInterfaceExceptionService;
        public ProductIInterfaceExceptionController(IProductInterfaceExceptionService productInterfaceExceptionService)
        {
            this.productInterfaceExceptionService = productInterfaceExceptionService;
        }

        /// <summary>
        /// Producto interfaz excepciones controller
        /// </summary>
        /// <param name='filter'></param>
        /// <returns>Producto interfaz excepciones stream</returns>
        /// <remarks>
        /// Sample Request:
        ///
        ///     POST /FilterGrid
        ///     {
        ///             "orderBy": { "column": "", "isDesc": 0 },//VCSAP,IDPROD55,VCNOMBRE55,NPESOVOLUMETRICO,DTCREACION,DTACTUALIZACION,VC20USUARIOCREACION,VC20USUARIOACTUALIZACION,
        ///             "paging":   { "pageNumber": 0, "pageSize": 0, "search": "string" },
        ///             "filters":  [
        ///                     {"Key": "vcSAP", "value": "string" , "required": false},
        ///                     {"Key": "IdProd55", "value": "string" , "required": false},
        ///                     {"Key": "vcNombre55", "value": "string" , "required": false},
        ///                     {"Key": "nPesoVolumetrico", "value": "string" , "required": false},
        ///                     {"Key": "dtCreacion", "value": "string" , "required": false},
        ///                     {"Key": "dtActualizacion", "value": "string" , "required": false},
        ///                     {"Key": "vc20UsuarioCreacion", "value": "string" , "required": false},
        ///                     {"Key": "vc20UsuarioActualizacion", "value": "string" , "required": false}
        ///             ],
        ///     }
        ///
        /// </remarks>
        [HttpPost("List")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<ProductInterfaceExceptionDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAsync([FromBody] FilterGrid filter)
        {
            var response = await this.productInterfaceExceptionService.GetAsync(filter);
            return Ok(response);
        }

        /// <summary>
        /// Producto interfaz excepciones controller
        /// </summary>
        /// <param name='filter'></param>
        /// <returns>Producto interfaz excepciones stream</returns>
        /// <remarks>
        /// Sample Request:
        ///
        ///     POST /FilterGrid
        ///     {
        ///             "orderBy": { "column": "", "isDesc": 0 },//VCSAP,IDPROD55,VCNOMBRE55,NPESOVOLUMETRICO,DTCREACION,DTACTUALIZACION,VC20USUARIOCREACION,VC20USUARIOACTUALIZACION
        ///             "paging":   { "pageNumber": 0, "pageSize": 0, "search": "string" },
        ///             "filters":  [
        ///                     {"Key": "vcSAP", "value": "string" , "required": false},
        ///                     {"Key": "IdProd55", "value": "string" , "required": false},
        ///                     {"Key": "vcNombre55", "value": "string" , "required": false},
        ///                     {"Key": "nPesoVolumetrico", "value": "string" , "required": false}
        ///                     {"Key": "dtCreacion", "value": "string" , "required": false},
        ///                     {"Key": "dtActualizacion", "value": "string" , "required": false},
        ///                     {"Key": "vc20UsuarioCreacion", "value": "string" , "required": false},
        ///                     {"Key": "vc20UsuarioActualizacion", "value": "string" , "required": false}
        ///             ],
        ///             "Columns":  [
        ///                     {"Key": "vcSAP", "value": "string"},
        ///                     {"Key": "IdProd55", "value": "string"},
        ///                     {"Key": "vcNombre55", "value": "string"},
        ///                     {"Key": "nPesoVolumetrico", "value": "string"},
        ///                     {"Key": "dtCreacion", "value": "string"},
        ///                     {"Key": "dtActualizacion", "value": "string"},
        ///                     {"Key": "vc20UsuarioCreacion", "value": "string"},
        ///                     {"Key": "vc20UsuarioActualizacion", "value": "string"}
        ///             ],
        ///     }
        ///
        /// </remarks>
        [HttpPost("Export")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<string>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> ExportAsync([FromBody] FilterGrid filter)
        {
            var response = await this.productInterfaceExceptionService.ExportAsync(filter);
            return Ok(response);
        }

        // POST api/<ProductInterfaceController>
        [HttpPut]
        public async Task<IActionResult> InsertAsync([FromBody] ProductInterfaceExceptionInsertDto data)
        {
            await this.productInterfaceExceptionService.InsertAsync(data);
            return Ok();
        }

        // PUT api/<ProductInterfaceController>/5
        [HttpPost]
        public async Task<IActionResult> UpdateAsync([FromBody] ProductInterfaceExceptionInsertDto data)
        {
            await this.productInterfaceExceptionService.UpdateAsync(data);
            return Ok();
        }

        // DELETE api/<ProductInterfaceController>/5
        [HttpDelete("{vcSap}")]
        public async Task<IActionResult> DeleteAsync(string vcSap)
        {
            await this.productInterfaceExceptionService.DeleteAsync(vcSap);
            return Ok();
        }
    }
}
