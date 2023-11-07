using Cnx.Caiman.Core.DTOs.AssigPlan;
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
    [Produces("application/json")]
    [Route("api/AssigPlan")]
    [ApiController]
    public class AssigPlanController : Controller
    {
        private readonly IAssigPlanService assigPlanService;

        public AssigPlanController(IAssigPlanService assigPlanService)
        {
            this.assigPlanService = assigPlanService;
        }

        /// <summary>
        /// Assig Plan collection
        /// </summary>
        /// <param name="filter">* value requeried</param>
        /// <returns>Assig plan collection</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /FilterGrid
        ///     {
        ///         "orderBy":  { "column": "", "isDesc": 0 }, //vc50NombrePlan, vc255Observaciones, dtfechaPlan, iEstatus, FechaModificado
        ///         "paging":   { "pageNumber": 0, "pageSize": 0, "search": "string" },
        ///         "filters":  [
        ///                        * { "key": "idzona", "value": "string" }, 
        ///                        * { "key": "fechaPlan", "value": "string" }, 
        ///                          { "key": "vc50Nombre", "value": "string" }, 
        ///                          { "key": "vc255Observaciones", "value": "string" },
        ///                          { "key": "bActivo", "value": "bool" },
        ///                          { "key": "iEstatus", "value": "int" },
        ///                          { "key": "dtModificado", "value": "date" },
        ///                          { "key": "VcUsuarioModifico", "value": "date" },
        ///                     ]
        ///     }
        ///
        /// </remarks>
        [HttpPost("List")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<AssigPlanDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAsync([FromBody] FilterGrid filter)
        {
            var response = await this.assigPlanService.GetAsync(filter);
            return Ok(response);
        }

        [HttpPost, Route("Export")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<string>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> ExportAsync([FromBody] FilterGrid filter)
        {
            var response = await this.assigPlanService.ExportAsync(filter);
            return Ok(response);
        }

        /// <summary>
        /// Assig Plan collection
        /// </summary>
        /// <param name="model">* value requeried</param>
        /// <returns>Assig plan collection</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST 
        ///     {
        ///        * "idPlanAsignacion": 0,
        ///        * "vc50Nombre": "string",
        ///        * "vc255Observaciones": "string",
        ///        * "costos": 0
        ///     }
        ///
        /// </remarks>
        [HttpPost, Route("Update")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task PostAsync([FromBody] AssigPlanUpdateDto model)
        {
            await this.assigPlanService.UpdateAsync(model);
        }

        /// <summary>
        /// Assig Plan collection
        /// </summary>
        /// <param name="model">* value requeried</param>
        /// <returns>Assig plan collection</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST 
        ///     {
        ///        * "IdPlanAsignacion": 0,
        ///        * "Estatus": 0
        ///     }
        ///
        /// </remarks>
        [HttpPost, Route("PlanChangeState")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task PostStateAsync([FromBody] AssigPlanstateDto model)
        {
            await this.assigPlanService.UpdateStateAsync(model);
        }

        /// <summary>
        /// Assig Plan collection
        /// </summary>
        /// <param name="model">* value requeried</param>
        /// <returns>Assig plan collection</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT 
        ///     {
        ///         "nombre": "string",
        ///         "observaciones": "string",
        ///         "idZona": 0,
        ///         "dtFecha": "2022-06-02T03:58:17.972Z"
        ///     }
        ///
        /// </remarks>
        [HttpPut, Route("Insert")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task PutAsync([FromBody] AssigPlanInsertDto model)
        {
            await this.assigPlanService.InsertAsync(model);
        }

        /// <summary>
        /// Assig Plan collection
        /// </summary>
        /// <param name="model">* value requeried copy insert</param>
        /// <returns>Assig plan collection</returns>
        [HttpPut, Route("InsertCopy")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task InsertCopyAsync([FromBody] AssigPlanInsertCopyDto model)
        {
            await this.assigPlanService.InsertCopyAsync(model);
        }

        /// <summary>
        /// Assig Plan collection
        /// </summary>
        /// <param name="IdPlanAsignacion">* value requeried</param>
        /// <param name="vc20Usuario">Hidden</param>
        /// <returns>Assig plan collection</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     DELETE
        ///
        /// </remarks>
        [HttpDelete, Route("Delete")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task Delete(int IdPlanAsignacion, [HiddenParam] string vc20Usuario)
        {
            await this.assigPlanService.DeleteAsync(IdPlanAsignacion, vc20Usuario);
        }


    }
}
