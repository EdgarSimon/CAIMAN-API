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
    [Route("api/ProductInterface")]
    [ApiController]
    public class ProductInterfaceController : ControllerBase
    {
        private readonly IProductInterfaceService productInterfaceService;
        public ProductInterfaceController(IProductInterfaceService productInterfaceService)
        {
            this.productInterfaceService = productInterfaceService;
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
        ///             "orderBy": { "column": "", "isDesc": 0 },//IDPRODUCTOINTERFAZ,VCSAP,VCNOMBRE900,IDPROD55,VCNOMBRE55,NPESOVOLUMETRICO,DTCREACION,DTACTUALIZACION,VC20USUARIOCREACION,VC20USUARIOACTUALIZACION,VCBORRAR,PROCESADO,BPROCESADO,
        ///             "paging":   { "pageNumber": 0, "pageSize": 0, "search": "string" },
        ///             "filters":  [
        ///                     {"Key": "VcSap", "value": "string" , "required": false},
        ///                     {"Key": "VcNombre900", "value": "string" , "required": false},
        ///                     {"Key": "IdProd55", "value": "string" , "required": false},
        ///                     {"Key": "VcNombre55", "value": "string" , "required": false},
        ///                     {"Key": "NPesoVolumetrico", "value": "string" , "required": false},
        ///                     {"Key": "DtCreacion", "value": "string" , "required": false},
        ///                     {"Key": "DtActualizacion", "value": "string" , "required": false},
        ///                     {"Key": "Vc20UsuarioCreacion", "value": "string" , "required": false},
        ///                     {"Key": "Vc20UsuarioActualizacion", "value": "string" , "required": false},
        ///                     {"Key": "VcBorrar", "value": "string" , "required": false},
        ///                     {"Key": "Procesado", "value": "string" , "required": false},
        ///                     {"Key": "BProcesado", "value": "string" , "required": false}
        ///             ],
        ///     }
        ///
        /// </remarks>
        [HttpPost("List")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<ProductInterfaceDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAsync([FromBody] FilterGrid filter)
        {
            var response = await this.productInterfaceService.GetAsync(filter);
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
        ///             "orderBy": { "column": "", "isDesc": 0 },//IDPRODUCTOINTERFAZ,VCSAP,VCNOMBRE900,IDPROD55,VCNOMBRE55,NPESOVOLUMETRICO,DTCREACION,DTACTUALIZACION,VC20USUARIOCREACION,VC20USUARIOACTUALIZACION,VCBORRAR,PROCESADO,BPROCESADO,
        ///             "paging":   { "pageNumber": 0, "pageSize": 0, "search": "string" },
        ///             "filters":  [
        ///                     {"Key": "VcSap", "value": "string" , "required": false},
        ///                     {"Key": "VcNombre900", "value": "string" , "required": false},
        ///                     {"Key": "IdProd55", "value": "string" , "required": false},
        ///                     {"Key": "VcNombre55", "value": "string" , "required": false},
        ///                     {"Key": "NPesoVolumetrico", "value": "string" , "required": false},
        ///                     {"Key": "DtCreacion", "value": "string" , "required": false},
        ///                     {"Key": "DtActualizacion", "value": "string" , "required": false},
        ///                     {"Key": "Vc20UsuarioCreacion", "value": "string" , "required": false},
        ///                     {"Key": "Vc20UsuarioActualizacion", "value": "string" , "required": false},
        ///                     {"Key": "VcBorrar", "value": "string" , "required": false},
        ///                     {"Key": "Procesado", "value": "string" , "required": false},
        ///                     {"Key": "BProcesado", "value": "string" , "required": false}
        ///             ],
        ///             "Columns":  [
        ///                     {"Key": "VcSap", "value": "string"},
        ///                     {"Key": "VcNombre900", "value": "string"},
        ///                     {"Key": "IdProd55", "value": "string"},
        ///                     {"Key": "VcNombre55", "value": "string"},
        ///                     {"Key": "NPesoVolumetrico", "value": "string"},
        ///                     {"Key": "DtCreacion", "value": "string"},
        ///                     {"Key": "DtActualizacion", "value": "string"},
        ///                     {"Key": "Vc20UsuarioCreacion", "value": "string"},
        ///                     {"Key": "Vc20UsuarioActualizacion", "value": "string"},
        ///                     {"Key": "VcBorrar", "value": "string"},
        ///                     {"Key": "Procesado", "value": "string"},
        ///                     {"Key": "BProcesado", "value": "string"}
        ///             ],
        ///     }
        ///
        /// </remarks>
        [HttpPost("Export")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<string>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> ExportAsync([FromBody] FilterGrid filter)
        {
            var response = await this.productInterfaceService.ExportAsync(filter);
            return Ok(response);
        }

        // POST api/<ProductInterfaceController>
        [HttpPut]
        public async Task<IActionResult> InsertAsync([FromBody] ProductInterfaceInsertDto data)
        {
            await this.productInterfaceService.InsertAsync(data);
            return Ok();
        }

        // PUT api/<ProductInterfaceController>/5
        [HttpPost]
        public async Task<IActionResult> Put([FromBody] ProductInterfaceInsertDto data)
        {
            await this.productInterfaceService.UpdateAsync(data);
            return Ok();
        }

        // DELETE api/<ProductInterfaceController>/5
        [HttpDelete("{vcSap}")]
        public async Task<IActionResult> DeleteAsync(string vcSap)
        {
            await this.productInterfaceService.DeleteAsync(vcSap);
            return Ok();
        }
    }
}
