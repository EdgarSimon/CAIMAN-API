using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Cnx.Caiman.Core.DTOs;
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
    [Route("api/GeneralShipper")]
    [ApiController]
    public class GeneralShipperController : ControllerBase
    {
        private readonly IGeneralShipperService generalShipperService;

        public GeneralShipperController(IGeneralShipperService generalShipperService)
        {
            this.generalShipperService = generalShipperService;
        }
        /// <summary>
        /// General Shipper
        /// </summary>
        /// <param name='filter'></param>
        /// <returns>General Shipper Collection</returns>
        /// <remarks>
        /// Sample Request:
        ///
        ///     POST /FilterGrid
        ///     {
        ///             "orderBy": { "column": "", "isDesc": 0 },//VCSAP,VC50NOMBRE,BPROPIO,DTCREACION,DTMODIFICADO,VCUSUARIOCREACION,VCUSUARIOMODIFICO,PAGESIZE,PAGENUMBER,
        ///             "paging":   { "pageNumber": 0, "pageSize": 0, "search": "string" },
        ///             "filters":  [
        ///                     {"Key": "vcSap", "value": "string"},
        ///                     {"Key": "vc50Nombre", "value": "string"},
        ///                     {"Key": "bPropio", "value": "string"},
        ///                     {"Key": "dtCreacion", "value": "string"},
        ///                     {"Key": "dtModificado", "value": "string"},
        ///                     {"Key": "VcUsuarioCreacion", "value": "string"},
        ///                     {"Key": "VcUsuarioModifico", "value": "string"},
        ///                     {"Key": "pageSize", "value": "string"},
        ///                     {"Key": "pageNumber", "value": "string"}
        ///             ],
        ///     }
        ///
        /// </remarks>

        [HttpPost("List")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<GeneralShipperDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAsync([FromBody] FilterGrid filter)
        {
            var response = await this.generalShipperService.GetAsync(filter);
            return Ok(response);
        }

        /// <summary>
        /// General Shipper excel
        /// </summary>
        /// <param name='filter'></param>
        /// <returns>General Shipper excel stream</returns>
        /// <remarks>
        /// Sample Request:
        ///
        ///     POST /FilterGrid
        ///     {
        ///             "orderBy": { "column": "", "isDesc": 0 },//VCSAP,VC50NOMBRE,BPROPIO,DTCREACION,DTMODIFICADO,VCUSUARIOCREACION,VCUSUARIOMODIFICO,PAGESIZE,PAGENUMBER,
        ///             "paging":   { "pageNumber": 0, "pageSize": 0, "search": "string" },
        ///             "filters":  [
        ///                     {"Key": "vcSap", "value": "string"},
        ///                     {"Key": "vc50Nombre", "value": "string"},
        ///                     {"Key": "bPropio", "value": "string"},
        ///                     {"Key": "dtCreacion", "value": "string"},
        ///                     {"Key": "dtModificado", "value": "string"},
        ///                     {"Key": "VcUsuarioCreacion", "value": "string"},
        ///                     {"Key": "VcUsuarioModifico", "value": "string"},
        ///                     {"Key": "pageSize", "value": "string"},
        ///                     {"Key": "pageNumber", "value": "string"}
        ///             ],
        ///             "Columns":  [
        ///                     {"Key": "vcSap", "value": "string"},
        ///                     {"Key": "vc50Nombre", "value": "string"},
        ///                     {"Key": "bPropio", "value": "string"},
        ///                     {"Key": "dtCreacion", "value": "string"},
        ///                     {"Key": "dtModificado", "value": "string"},
        ///                     {"Key": "VcUsuarioCreacion", "value": "string"},
        ///                     {"Key": "VcUsuarioModifico", "value": "string"},
        ///                     {"Key": "pageSize", "value": "string"},
        ///                     {"Key": "pageNumber", "value": "string"}
        ///             ],
        ///     }
        ///
        /// </remarks>

        [HttpPost("Export")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<string>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> ExportAsync([FromBody] FilterGrid filter)
        {
            var response = await this.generalShipperService.ExportAsync(filter);
            return Ok(response);
        }

        [HttpGet("GetShipperAvailable")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<GeneralShipperDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetShipperAvailableAsync([FromQuery] ZoneIntFilter filter)
        {
            var response = await this.generalShipperService.GetShipperAvailableAsync(filter);
            return Ok(response);
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> PutAsync([FromBody] GeneralShipperInsertDto data)
        {
            await this.generalShipperService.InsertAsync(data);
            return Ok();
        }

        [HttpPost("{IdTransportista}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> PostAsync(int IdTransportista, [FromBody] GeneralShipperUpdateDto data)
        {
            await this.generalShipperService.UpdateAsync(IdTransportista,data);
            return Ok();
        }

        [HttpDelete("{id}/{username}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DeleteAsync(int id, string username)
        {
            await this.generalShipperService.DeleteAsync(id, username);
            return Ok();
        }

        [HttpGet("GetShipperByGeneralShipper")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<GeneralShipperDto>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult GetShipperByGeneralShipper([FromQuery] ShipperByGeneralShipperDto data)
        {
            var response = this.generalShipperService.GetShipperByGeneralShipperAsync(data);
            return Ok(response);
        }
    }
}
