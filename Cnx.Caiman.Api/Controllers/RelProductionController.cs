using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Cnx.Caiman.Core.DTOs.Distance;
using Cnx.Caiman.Core.DTOs.Origin;
using Cnx.Caiman.Core.DTOs.Product;
using Cnx.Caiman.Core.Interfaces.Services;
using Cemex.Core.Entities;
using Cemex.Core.Entities.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cnx.Caiman.Api.Controllers
{
    //[Authorize]
    [Produces("application/json")]
    [Route("api/RelProduction")]
    [ApiController]
    public class RelProductionController : ControllerBase
    {
        private readonly IRelProductionService producctionService;
        
        public RelProductionController(IRelProductionService producctionService)
        {
            this.producctionService = producctionService;
        }

        [HttpGet("GetList")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<RelProductionDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAsync([FromQuery] PaginationQuery filter, int idOrigin)
        {
            var response = await this.producctionService.GetAsync(idOrigin, filter);
            return Ok(response);
        }

        /// <summary>
        /// Sobrecostos excel
        /// </summary>
        /// <param name='filter'></param>
        /// <returns>Sobrecostos excel stream</returns>
        /// <remarks>
        /// Sample Request:
        ///
        ///     POST /FilterGrid
        ///     {
        ///             "orderBy": { "column": "", "isDesc": 0 },IDPRODUCCION,NCOSTOINTEGRAL,NPRECIO,NCOSTOPORCALIDAD,DTACTUALIZACION,VC20USUARIOACTUALIZACION,DTCREACION,VC20USUARIOCREACION,KILOGRAMOS,IDTIPOSC,COSTOCEMENTO,NFACTORUSO,PRODUCTOVC50NOMBRE,ORIGEVC50NOMBRE,
        ///             "paging":   { "pageNumber": 0, "pageSize": 0, "search": "string" },
        ///             "filters":  [
        ///                     {"Key": "IdZona", "value": "string" , "required": true},
        ///                     {"Key": "idproduccion", "value": "string" , "required": false},
        ///                     {"Key": "ncostointegral", "value": "string" , "required": false},
        ///                     {"Key": "nprecio", "value": "string" , "required": false},
        ///                     {"Key": "ncostoporcalidad", "value": "string" , "required": false},
        ///                     {"Key": "dtactualizacion", "value": "string" , "required": false},
        ///                     {"Key": "vc20usuarioactualizacion", "value": "string" , "required": false},
        ///                     {"Key": "dtCreacion", "value": "string" , "required": false},
        ///                     {"Key": "vc20UsuarioCreacion", "value": "string" , "required": false},
        ///                     {"Key": "Kilogramos", "value": "string" , "required": false},
        ///                     {"Key": "IdTipoSC", "value": "string" , "required": false},
        ///                     {"Key": "CostoCemento", "value": "string" , "required": false},
        ///                     {"Key": "nFactorUso", "value": "string" , "required": false},
        ///                     {"Key": "ProductoVc50nombre", "value": "string" , "required": false},
        ///                     {"Key": "OrigeVc50nombre", "value": "string" , "required": false}
        ///             ]
        ///     }
        ///
        /// </remarks>

        [HttpPost("GetValuesOriginList")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<RelProductionDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetValuesOriginAsync([FromBody] FilterGrid filter)
        {
            var response = await this.producctionService.GetValuesOriginAsync(filter);
            return Ok(response);
        }

        /// <summary>
        /// Sobrecostos excel
        /// </summary>
        /// <param name='filter'></param>
        /// <returns>Sobrecostos excel stream</returns>
        /// <remarks>
        /// Sample Request:
        ///
        ///     POST /FilterGrid
        ///     {
        ///             "orderBy": { "column": "", "isDesc": 0 },IDPRODUCCION,NCOSTOINTEGRAL,NPRECIO,NCOSTOPORCALIDAD,DTACTUALIZACION,VC20USUARIOACTUALIZACION,DTCREACION,VC20USUARIOCREACION,KILOGRAMOS,IDTIPOSC,COSTOCEMENTO,NFACTORUSO,PRODUCTOVC50NOMBRE,ORIGEVC50NOMBRE,
        ///             "paging":   { "pageNumber": 0, "pageSize": 0, "search": "string" },
        ///             "filters":  [
        ///                     {"Key": "IdZona", "value": "string" , "required": true},
        ///                     {"Key": "idproduccion", "value": "string" , "required": false},
        ///                     {"Key": "ncostointegral", "value": "string" , "required": false},
        ///                     {"Key": "nprecio", "value": "string" , "required": false},
        ///                     {"Key": "ncostoporcalidad", "value": "string" , "required": false},
        ///                     {"Key": "dtactualizacion", "value": "string" , "required": false},
        ///                     {"Key": "vc20usuarioactualizacion", "value": "string" , "required": false},
        ///                     {"Key": "dtCreacion", "value": "string" , "required": false},
        ///                     {"Key": "vc20UsuarioCreacion", "value": "string" , "required": false},
        ///                     {"Key": "Kilogramos", "value": "string" , "required": false},
        ///                     {"Key": "IdTipoSC", "value": "string" , "required": false},
        ///                     {"Key": "CostoCemento", "value": "string" , "required": false},
        ///                     {"Key": "nFactorUso", "value": "string" , "required": false},
        ///                     {"Key": "ProductoVc50nombre", "value": "string" , "required": false},
        ///                     {"Key": "OrigeVc50nombre", "value": "string" , "required": false}
        ///             ],
        ///             "Columns":  [
        ///                     {"Key": "idproduccion", "value": "string"},
        ///                     {"Key": "ncostointegral", "value": "string"},
        ///                     {"Key": "nprecio", "value": "string"},
        ///                     {"Key": "ncostoporcalidad", "value": "string"},
        ///                     {"Key": "dtactualizacion", "value": "string"},
        ///                     {"Key": "vc20usuarioactualizacion", "value": "string"},
        ///                     {"Key": "dtCreacion", "value": "string"},
        ///                     {"Key": "vc20UsuarioCreacion", "value": "string"},
        ///                     {"Key": "Kilogramos", "value": "string"},
        ///                     {"Key": "IdTipoSC", "value": "string"},
        ///                     {"Key": "CostoCemento", "value": "string"},
        ///                     {"Key": "nFactorUso", "value": "string"},
        ///                     {"Key": "ProductoVc50nombre", "value": "string"},
        ///                     {"Key": "OrigeVc50nombre", "value": "string"}
        ///             ],
        ///     }
        ///
        /// </remarks>

        [HttpPost("GetValuesOriginExport")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<RelProductionDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetValuesOriginExportWAsync([FromBody] FilterGrid filter)
        {
            var response = await this.producctionService.GetValuesOriginExportAsync(filter);
            return Ok(response);
        }

        [HttpGet("GetProductosByZone")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<ProductDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetProductosByZoneAsync([FromQuery] PaginationQuery filter, int idOrigin, int idZone)
        {
            var response = await this.producctionService.GetProductosByZoneAsync(filter, idOrigin, idZone);
            return Ok(response);
        }

        [HttpPut("InsertProductOrigin")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> InsertProductOriginAsync([FromBody] RelOriginProductInsertDto data)
        {
            await this.producctionService.InsertProductOriginAsync(data);
            return Ok();
        }

        [HttpPost("UpdateProductOrigin/{idRel}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateProductOriginAsync(int idRel, [FromBody] RelOriginProductInsertDto data)
        {
            await this.producctionService.UpdateProductOriginAsync(data, idRel);
            return Ok();
        }

        [HttpDelete("DeleteProductOrigin/{idProd}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DeleteProductOriginAsync(int idRel)
        {
            await this.producctionService.DeleteProductOriginAsync(idRel);
            return Ok();
        }



        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateCostProductOverrunAsync([FromBody] CostProductOverrunUpdateDto data)
        {
            await this.producctionService.UpdateCostProductOverrunAsync(data);
            return Ok();
        }
    }
}
