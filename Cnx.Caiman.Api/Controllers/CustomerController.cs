using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Cnx.Caiman.Core.DTOs.Destination;
using Cnx.Caiman.Core.Interfaces.Services;
using Cemex.Core.Entities;
using Cemex.Core.Entities.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cnx.Caiman.Api.Controllers
{
    [Authorize]
    [Route("api/customer")]
    [Produces("application/json")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }
        /// <summary>
        /// Request Customer collection
        /// </summary>
        /// <param name="filter"></param>
        /// <returns>Cedi collection</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /FilterGrid
        ///     {
        ///         "orderBy":  { "column": "", "isDesc": 0 }, //VC50NOMBRE, IMANIANA, ITARDE, INOCHE, ICLAVESICADI, 
        ///             ICLAVESIT, DTACTUALIZACION, DTCREACION, VC20USUARIOACTUALIZACION, VC20USUARIOCREACION, VC12CLAVESAP, VC25NOMBRECORTO, CEDISVCDESCRIPCION, SUBZONAVC50NOMBRE
        ///         "paging":   { "pageNumber": 0, "pageSize": 0, "search": "string" },
        ///         "filters":  [
        ///                         { "key": "zona", "value": "string" },
        ///                         { "Key": "Destino", "value": "string" },
        ///                         { "Key": "Maniana", "value": "string" },
        ///                         { "Key": "Tarde", "value": "string" },
        ///                         { "Key": "Noche", "value": "string" },
        ///                         { "Key": "AutoABasto", "value": "string" },
        ///                         { "Key": "Clavesicadi", "value": "string" },
        ///                         { "Key": "Clavesit", "value": "string" },
        ///                         { "Key": "Clavesap", "value": "string" }
        ///                         { "Key": "Zonasap", "value": "string" },
        ///                         { "Key": "DateCreacion", "value": "string" },
        ///                         { "Key": "DateActualizacion", "value": "string" },
        ///                         { "Key": "UsuarioCreacion", "value": "string" },
        ///                         { "Key": "Usuarioactualizacion", "value": "string" }
        ///                         { "Key": "NombreCorto", "value": "string" },
        ///                         { "Key": "Cedis", "value": "string" },
        ///                         { "Key": "Subzona", "value": "string" }
        ///                     ],
        ///     }
        ///
        /// </remarks>

        [HttpPost("List")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<DestinationDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAsync([FromBody] FilterGrid filter)
        {
            var response = await customerService.GetAsync(filter);
            return Ok(response);
        }

        /// <summary>
        /// Request Customer excel
        /// </summary>
        /// <param name="filter"></param>
        /// <returns>Cedi excel</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /FilterGrid
        ///     {
        ///         "orderBy":  { "column": "", "isDesc": 0 }, //VC50NOMBRE, IMANIANA, ITARDE, INOCHE, ICLAVESICADI, 
        ///             ICLAVESIT, DTACTUALIZACION, DTCREACION, VC20USUARIOACTUALIZACION, VC20USUARIOCREACION, VC12CLAVESAP, VC25NOMBRECORTO, CEDISVCDESCRIPCION, SUBZONAVC50NOMBRE
        ///         "paging":   { "pageNumber": 0, "pageSize": 0, "search": "string" },
        ///         "filters":  [
        ///                         { "key": "zona", "value": "string" },
        ///                         { "Key": "Destino", "value": "string" },
        ///                         { "Key": "Maniana", "value": "string" },
        ///                         { "Key": "Tarde", "value": "string" },
        ///                         { "Key": "Noche", "value": "string" },
        ///                         { "Key": "AutoABasto", "value": "string" },
        ///                         { "Key": "Clavesicadi", "value": "string" },
        ///                         { "Key": "Clavesit", "value": "string" },
        ///                         { "Key": "Clavesap", "value": "string" }
        ///                         { "Key": "Zonasap", "value": "string" },
        ///                         { "Key": "DateCreacion", "value": "string" },
        ///                         { "Key": "DateActualizacion", "value": "string" },
        ///                         { "Key": "UsuarioCreacion", "value": "string" },
        ///                         { "Key": "Usuarioactualizacion", "value": "string" }
        ///                         { "Key": "NombreCorto", "value": "string" },
        ///                         { "Key": "Cedis", "value": "string" },
        ///                         { "Key": "Subzona", "value": "string" }
        ///                     ],
        ///         "Columns":  [
        ///                         { "key": "idDestino", "value": "string" },
        ///                         { "Key": "vc50Nombre", "value": "string" },
        ///                         { "Key": "iManiana", "value": "string" },
        ///                         { "Key": "iTarde", "value": "string" },
        ///                         { "Key": "iNoche", "value": "string" },
        ///                         { "Key": "bAutoAbasto", "value": "string" },
        ///                         { "Key": "iclavesicadi", "value": "string" },
        ///                         { "Key": "iclavesit", "value": "string" },
        ///                         { "Key": "dtactualizacion", "value": "string" }
        ///                         { "Key": "vc20usuarioactualizacion", "value": "string" },
        ///                         { "Key": "dtCreacion", "value": "string" },
        ///                         { "Key": "vc20UsuarioCreacion", "value": "string" },
        ///                         { "Key": "vc12clavesap", "value": "string" },
        ///                         { "Key": "vczonasap", "value": "string" }
        ///                         { "Key": "vc25NombreCorto", "value": "string" },
        ///                         { "Key": "SubZona.", "value": "string" },
        ///                         { "Key": "Subzona.Vc50Nombre", "value": "string" }
        ///                         { "Key": "Cedi.vcdescripcion", "value": "string" }
        ///                     ]
        ///     }
        ///
        /// </remarks>

        [HttpPost("Export")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<string>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> ExportAsync([FromBody] FilterGrid filter)
        {
            var response = await customerService.ExportAsync(filter);
            return Ok(response);
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> PutAsync([FromBody] DestinationInsertDto data)
        {
            await customerService.InsertAsync(data);
            return Ok();
        }
    }
}
