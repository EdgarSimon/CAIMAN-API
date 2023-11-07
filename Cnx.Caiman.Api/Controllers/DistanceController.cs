using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Cnx.Caiman.Core.DTOs.Distance;
using Cnx.Caiman.Core.Entities.Filters;
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
    [Route("api/distance")]
    [ApiController]
    public class DistanceController : ControllerBase
    {
        private readonly IDistanceService distanceService;

        public DistanceController(IDistanceService distanceService)
        {
            this.distanceService = distanceService;
        }

        /// <summary>
        /// Distance
        /// </summary>
        /// <param name='filter'></param>
        /// <returns>Distance Collection</returns>
        /// <remarks>
        /// Sample Request:
        ///
        ///     POST /FilterGrid
        ///     {
        ///             "orderBy": { "column": "", "isDesc": 0 },//IDORIGEN,IDPRODUCTO,IDDISTANCIA,NOMBRE,PRODUCTO,DISTANCIA_F,TARIFA_F,DTACTUALIZACION,VC20USUARIOACTUALIZACION,IDDESTINO,TARIFA_M,TARIFA_P,TARIFA_ED,TARIFA_J,UM_M,UM_P,UM_ED,UM_J,IDENLACEMANUAL,ENPROCESO,NDISTANCIA,
        ///             "paging":   { "pageNumber": 0, "pageSize": 0, "search": "string" },
        ///             "filters":  [
        ///                     {"Key": "IdOrigen", "value": "string" , "required": true},
        ///                     {"Key": "idProducto", "value": "string" , "required": true},
        ///                     {"Key": "IdDistancia", "value": "string" , "required": false},
        ///                     {"Key": "Nombre", "value": "string" , "required": false},
        ///                     {"Key": "Producto", "value": "string" , "required": false},
        ///                     {"Key": "Distancia_F", "value": "string" , "required": false},
        ///                     {"Key": "Tarifa_F", "value": "string" , "required": false},
        ///                     {"Key": "dtActualizacion", "value": "string" , "required": false},
        ///                     {"Key": "vc20UsuarioActualizacion", "value": "string" , "required": false},
        ///                     {"Key": "IdDestino", "value": "string" , "required": false},
        ///                     {"Key": "Tarifa_M", "value": "string" , "required": false},
        ///                     {"Key": "Tarifa_P", "value": "string" , "required": false},
        ///                     {"Key": "Tarifa_ED", "value": "string" , "required": false},
        ///                     {"Key": "Tarifa_J", "value": "string" , "required": false},
        ///                     {"Key": "UM_M", "value": "string" , "required": false},
        ///                     {"Key": "UM_P", "value": "string" , "required": false},
        ///                     {"Key": "UM_ED", "value": "string" , "required": false},
        ///                     {"Key": "UM_J", "value": "string" , "required": false},
        ///                     {"Key": "idEnlaceManual", "value": "string" , "required": false},
        ///                     {"Key": "EnProceso", "value": "string" , "required": false},
        ///                     {"Key": "nDistancia", "value": "string" , "required": false}
        ///             ],
        ///             "Columns":  [
        ///                     {"Key": "IdOrigen", "value": "string"},
        ///                     {"Key": "idProducto", "value": "string"},
        ///                     {"Key": "IdDistancia", "value": "string"},
        ///                     {"Key": "Nombre", "value": "string"},
        ///                     {"Key": "Producto", "value": "string"},
        ///                     {"Key": "Distancia_F", "value": "string"},
        ///                     {"Key": "Tarifa_F", "value": "string"},
        ///                     {"Key": "dtActualizacion", "value": "string"},
        ///                     {"Key": "vc20UsuarioActualizacion", "value": "string"},
        ///                     {"Key": "IdDestino", "value": "string"},
        ///                     {"Key": "Tarifa_M", "value": "string"},
        ///                     {"Key": "Tarifa_P", "value": "string"},
        ///                     {"Key": "Tarifa_ED", "value": "string"},
        ///                     {"Key": "Tarifa_J", "value": "string"},
        ///                     {"Key": "UM_M", "value": "string"},
        ///                     {"Key": "UM_P", "value": "string"},
        ///                     {"Key": "UM_ED", "value": "string"},
        ///                     {"Key": "UM_J", "value": "string"},
        ///                     {"Key": "idEnlaceManual", "value": "string"},
        ///                     {"Key": "EnProceso", "value": "string"},
        ///                     {"Key": "nDistancia", "value": "string"}
        ///             ],
        ///     }
        ///
        /// </remarks>

        [HttpPost("TariffConsultOriginProductList")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<TariffDestinationProductDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> TariffConsultOriginProductAsync([FromBody] FilterGrid filter)
        {
            var response = await this.distanceService.TariffConsultOriginProductAsync(filter);
            return Ok(response);
        }

        /// <summary>
        /// Distance excel
        /// </summary>
        /// <param name='filter'></param>
        /// <returns>Distance excel stream</returns>
        /// <remarks>
        /// Sample Request:
        ///
        ///     POST /FilterGrid
        ///     {
        ///             "orderBy": { "column": "", "isDesc": 0 },//IDORIGEN,IDPRODUCTO,IDDISTANCIA,NOMBRE,PRODUCTO,DISTANCIA_F,TARIFA_F,DTACTUALIZACION,VC20USUARIOACTUALIZACION,IDDESTINO,TARIFA_M,TARIFA_P,TARIFA_ED,TARIFA_J,UM_M,UM_P,UM_ED,UM_J,IDENLACEMANUAL,ENPROCESO,NDISTANCIA,
        ///             "paging":   { "pageNumber": 0, "pageSize": 0, "search": "string" },
        ///             "filters":  [
        ///                     {"Key": "IdOrigen", "value": "string" , "required": true},
        ///                     {"Key": "idProducto", "value": "string" , "required": true},
        ///                     {"Key": "IdDistancia", "value": "string" , "required": false},
        ///                     {"Key": "Nombre", "value": "string" , "required": false},
        ///                     {"Key": "Producto", "value": "string" , "required": false},
        ///                     {"Key": "Distancia_F", "value": "string" , "required": false},
        ///                     {"Key": "Tarifa_F", "value": "string" , "required": false},
        ///                     {"Key": "dtActualizacion", "value": "string" , "required": false},
        ///                     {"Key": "vc20UsuarioActualizacion", "value": "string" , "required": false},
        ///                     {"Key": "IdDestino", "value": "string" , "required": false},
        ///                     {"Key": "Tarifa_M", "value": "string" , "required": false},
        ///                     {"Key": "Tarifa_P", "value": "string" , "required": false},
        ///                     {"Key": "Tarifa_ED", "value": "string" , "required": false},
        ///                     {"Key": "Tarifa_J", "value": "string" , "required": false},
        ///                     {"Key": "UM_M", "value": "string" , "required": false},
        ///                     {"Key": "UM_P", "value": "string" , "required": false},
        ///                     {"Key": "UM_ED", "value": "string" , "required": false},
        ///                     {"Key": "UM_J", "value": "string" , "required": false},
        ///                     {"Key": "idEnlaceManual", "value": "string" , "required": false},
        ///                     {"Key": "EnProceso", "value": "string" , "required": false},
        ///                     {"Key": "nDistancia", "value": "string" , "required": false}
        ///             ],
        ///     }
        ///
        /// </remarks>

        [HttpPost("TariffConsultOriginProductExport")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<string>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> TariffConsultOriginProductExportAsync([FromBody] FilterGrid filter)
        {
            var response = await this.distanceService.TariffConsultOriginProductExportAsync(filter);
            return Ok(response);
        }
        /// <summary>
        /// Distancia por destinos
        /// </summary>
        /// <param name='filter'></param>
        /// <returns>Distancia por destinos excel</returns>
        /// <remarks>
        /// Sample Request:
        ///
        ///     POST /FilterGrid
        ///     {
        ///             "orderBy": { "column": "", "isDesc": 0 },//IDDESTINO,IDPRODUCTO,BTODOS,NOMBRE,PRODUCTO,DISTANCIA_F,TARIFA_F,DTACTUALIZACION,VC20USUARIOACTUALIZACION,IDORIGEN,IDDESTINO,IDPRODUCTO,TARIFA_M,TARIFA_P,TARIFA_ED,TARIFA_J,UM_M,UM_P,UM_ED,UM_J,IDENLACEMANUAL,ENPROCESO,NDISTANCIA,
        ///             "paging":   { "pageNumber": 0, "pageSize": 0, "search": "string" },
        ///             "filters":  [
        ///                     {"Key": "IdDestino", "value": "string" , "required": true},
        ///                     {"Key": "idProducto", "value": "string" , "required": true},
        ///                     {"Key": "bTodos", "value": "string" , "required": true},
        ///                     {"Key": "Nombre", "value": "string" , "required": false},
        ///                     {"Key": "producto", "value": "string" , "required": false},
        ///                     {"Key": "Distancia_F", "value": "string" , "required": false},
        ///                     {"Key": "Tarifa_F", "value": "string" , "required": false},
        ///                     {"Key": "dtActualizacion", "value": "string" , "required": false},
        ///                     {"Key": "vc20UsuarioActualizacion", "value": "string" , "required": false},
        ///                     {"Key": "IdOrigen", "value": "string" , "required": false},
        ///                     {"Key": "IdDestino", "value": "string" , "required": false},
        ///                     {"Key": "IdProducto", "value": "string" , "required": false},
        ///                     {"Key": "Tarifa_M", "value": "string" , "required": false},
        ///                     {"Key": "Tarifa_P", "value": "string" , "required": false},
        ///                     {"Key": "Tarifa_ED", "value": "string" , "required": false},
        ///                     {"Key": "Tarifa_J", "value": "string" , "required": false},
        ///                     {"Key": "UM_M", "value": "string" , "required": false},
        ///                     {"Key": "UM_P", "value": "string" , "required": false},
        ///                     {"Key": "UM_ED", "value": "string" , "required": false},
        ///                     {"Key": "UM_J", "value": "string" , "required": false},
        ///                     {"Key": "idEnlaceManual", "value": "string" , "required": false},
        ///                     {"Key": "EnProceso", "value": "string" , "required": false},
        ///                     {"Key": "nDistancia", "value": "string" , "required": false}
        ///             ],
        ///             "Columns":  []
        ///     }
        ///
        /// </remarks>
        [HttpPost("TariffConsultDestinationProductList")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<TariffDestinationProductDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> TariffConsultDestinationProductAsync([FromBody] FilterGrid filter)
        {
            var response = await this.distanceService.TariffConsultDestinationProductAsync(filter);
            return Ok(response);
        }

        /// <summary>
        /// Distancia por destinos
        /// </summary>
        /// <param name='filter'></param>
        /// <returns>Distancia por destinos excel</returns>
        /// <remarks>
        /// Sample Request:
        ///
        ///     POST /FilterGrid
        ///     {
        ///             "orderBy": { "column": "", "isDesc": 0 },//IDDESTINO,IDPRODUCTO,BTODOS,NOMBRE,PRODUCTO,DISTANCIA_F,TARIFA_F,DTACTUALIZACION,VC20USUARIOACTUALIZACION,IDORIGEN,IDDESTINO,IDPRODUCTO,TARIFA_M,TARIFA_P,TARIFA_ED,TARIFA_J,UM_M,UM_P,UM_ED,UM_J,IDENLACEMANUAL,ENPROCESO,NDISTANCIA,
        ///             "paging":   { "pageNumber": 0, "pageSize": 0, "search": "string" },
        ///             "filters":  [
        ///                     {"Key": "IdDestino", "value": "string" , "required": true},
        ///                     {"Key": "idProducto", "value": "string" , "required": true},
        ///                     {"Key": "bTodos", "value": "string" , "required": true},
        ///                     {"Key": "Nombre", "value": "string" , "required": false},
        ///                     {"Key": "producto", "value": "string" , "required": false},
        ///                     {"Key": "Distancia_F", "value": "string" , "required": false},
        ///                     {"Key": "Tarifa_F", "value": "string" , "required": false},
        ///                     {"Key": "dtActualizacion", "value": "string" , "required": false},
        ///                     {"Key": "vc20UsuarioActualizacion", "value": "string" , "required": false},
        ///                     {"Key": "IdOrigen", "value": "string" , "required": false},
        ///                     {"Key": "IdDestino", "value": "string" , "required": false},
        ///                     {"Key": "IdProducto", "value": "string" , "required": false},
        ///                     {"Key": "Tarifa_M", "value": "string" , "required": false},
        ///                     {"Key": "Tarifa_P", "value": "string" , "required": false},
        ///                     {"Key": "Tarifa_ED", "value": "string" , "required": false},
        ///                     {"Key": "Tarifa_J", "value": "string" , "required": false},
        ///                     {"Key": "UM_M", "value": "string" , "required": false},
        ///                     {"Key": "UM_P", "value": "string" , "required": false},
        ///                     {"Key": "UM_ED", "value": "string" , "required": false},
        ///                     {"Key": "UM_J", "value": "string" , "required": false},
        ///                     {"Key": "idEnlaceManual", "value": "string" , "required": false},
        ///                     {"Key": "EnProceso", "value": "string" , "required": false},
        ///                     {"Key": "nDistancia", "value": "string" , "required": false}
        ///             ],
        ///             "Columns":  [
        ///                     {"Key": "IdDestino", "value": "string"},
        ///                     {"Key": "idProducto", "value": "string"},
        ///                     {"Key": "bTodos", "value": "string"},
        ///                     {"Key": "Nombre", "value": "string"},
        ///                     {"Key": "producto", "value": "string"},
        ///                     {"Key": "Distancia_F", "value": "string"},
        ///                     {"Key": "Tarifa_F", "value": "string"},
        ///                     {"Key": "dtActualizacion", "value": "string"},
        ///                     {"Key": "vc20UsuarioActualizacion", "value": "string"},
        ///                     {"Key": "IdOrigen", "value": "string"},
        ///                     {"Key": "IdDestino", "value": "string"},
        ///                     {"Key": "IdProducto", "value": "string"},
        ///                     {"Key": "Tarifa_M", "value": "string"},
        ///                     {"Key": "Tarifa_P", "value": "string"},
        ///                     {"Key": "Tarifa_ED", "value": "string"},
        ///                     {"Key": "Tarifa_J", "value": "string"},
        ///                     {"Key": "UM_M", "value": "string"},
        ///                     {"Key": "UM_P", "value": "string"},
        ///                     {"Key": "UM_ED", "value": "string"},
        ///                     {"Key": "UM_J", "value": "string"},
        ///                     {"Key": "idEnlaceManual", "value": "string"},
        ///                     {"Key": "EnProceso", "value": "string"},
        ///                     {"Key": "nDistancia", "value": "string"}
        ///             ]
        ///     }
        ///
        /// </remarks>
        [HttpPost("TariffConsultDestinationProductExport")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<string>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> TariffConsultDestinationProductExportAsync([FromBody] FilterGrid filter)
        {
            var response = await this.distanceService.TariffConsultDestinationProductExportAsync(filter);
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> PostAsync([FromBody] DistanceUpdateDto data)
        {
            await this.distanceService.UpdateAsync(data);
            return Ok();
        }
    }
}
