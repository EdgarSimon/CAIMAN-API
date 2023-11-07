using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Cnx.Caiman.Core.DTOs.Offer;
using Cnx.Caiman.Core.Entities.QueryEntities.Oferta;
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
    [Route("api/TransportOffer")]
    [ApiController]
    public class TransportOfferController : ControllerBase
    {
        private readonly ITransportOfferService transportOfferService;

        public TransportOfferController(ITransportOfferService transportOfferService)
        {
            this.transportOfferService = transportOfferService;
        }
        /// <summary>
        /// Oferta Transporte excel
        /// </summary>
        /// <param name='filter'></param>
        /// <returns>Oferta Transporte excel stream</returns>
        /// <remarks>
        /// Sample Request:
        ///
        ///     POST /FilterGrid
        ///     {
        ///             "orderBy": { "column": "", "isDesc": 0 },//DTFECHA,IDOFERTATRANSPORTE,MANEJA,TRANSPORTISTA,VIAJES,ASIGNADO,DISPONIBLE,OBSERVACIONES,IDTRANSPORTISTA,
        ///             "paging":   { "pageNumber": 0, "pageSize": 0, "search": "string" },
        ///             "filters":  [
        ///                     {"Key": "dtfecha", "value": "string" , "required": true},
        ///                     {"Key": "idzona", "value": "string" , "required": true},
        ///                     {"Key": "idOfertaTransporte", "value": "string" , "required": false},
        ///                     {"Key": "maneja", "value": "string" , "required": false},
        ///                     {"Key": "transportista", "value": "string" , "required": false},
        ///                     {"Key": "viajes", "value": "string" , "required": false},
        ///                     {"Key": "asignado", "value": "string" , "required": false},
        ///                     {"Key": "disponible", "value": "string" , "required": false},
        ///                     {"Key": "observaciones", "value": "string" , "required": false},
        ///                     {"Key": "idTransportista", "value": "string" , "required": false}
        ///             ]
        ///     }
        ///
        /// </remarks>
        [HttpPost("List")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<OfertaTransporteResult>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAsync([FromBody] FilterGrid filter)
        {
            var response = await this.transportOfferService.GetAsync(filter);
            return Ok(response);
        }

        /// <summary>
        /// Oferta Transporte excel
        /// </summary>
        /// <param name='filter'></param>
        /// <returns>Oferta Transporte excel stream</returns>
        /// <remarks>
        /// Sample Request:
        ///
        ///     POST /FilterGrid
        ///     {
        ///             "orderBy": { "column": "", "isDesc": 0 },//DTFECHA,IDZONA,IDUSUARIO,IDOFERTATRANSPORTE,MANEJA,TRANSPORTISTA,VIAJES,ASIGNADO,DISPONIBLE,OBSERVACIONES,IDTRANSPORTISTA,
        ///             "paging":   { "pageNumber": 0, "pageSize": 0, "search": "string" },
        ///             "filters":  [
        ///                     {"Key": "dtfecha", "value": "string" , "required": true},
        ///                     {"Key": "idzona", "value": "string" , "required": true},
        ///                     {"Key": "idOfertaTransporte", "value": "string" , "required": false},
        ///                     {"Key": "maneja", "value": "string" , "required": false},
        ///                     {"Key": "transportista", "value": "string" , "required": false},
        ///                     {"Key": "viajes", "value": "string" , "required": false},
        ///                     {"Key": "asignado", "value": "string" , "required": false},
        ///                     {"Key": "disponible", "value": "string" , "required": false},
        ///                     {"Key": "observaciones", "value": "string" , "required": false},
        ///                     {"Key": "idTransportista", "value": "string" , "required": false}
        ///             ],
        ///             "Columns":  [
        ///                     {"Key": "dtfecha", "value": "string"},
        ///                     {"Key": "idOfertaTransporte", "value": "string"},
        ///                     {"Key": "maneja", "value": "string"},
        ///                     {"Key": "transportista", "value": "string"},
        ///                     {"Key": "viajes", "value": "string"},
        ///                     {"Key": "asignado", "value": "string"},
        ///                     {"Key": "disponible", "value": "string"},
        ///                     {"Key": "observaciones", "value": "string"},
        ///                     {"Key": "idTransportista", "value": "string"}
        ///             ],
        ///     }
        ///
        /// </remarks>
        [HttpPost("Export")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<string>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> ExportAsync([FromBody] FilterGrid filter)
        {
            var response = await this.transportOfferService.ExportAsync(filter);
            return Ok(response);
        }

        // POST api/<TransportOfferController>
        [HttpPost("Update/{idTransportOffer}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> PostAsync(int idTransportOffer, [FromBody] TransportOfferInsertDto data)
        {
            await this.transportOfferService.UpdateAsync(data, idTransportOffer);
            return Ok();
        }


        [HttpGet, Route("ValidateOrden")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<ValidationDto>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> ValidateOrdenAsync([FromQuery] int idzone, DateTime date)
        {
            var response = await this.transportOfferService.ShowPhotoAsync(idzone, date);

            return Ok(response);
        }
    }
}
