using AutoMapper;
using Cnx.Caiman.Core.DTOs.AssignmentTrip;
using Cnx.Caiman.Core.DTOs.Feasibility;
using Cnx.Caiman.Core.DTOs.FeasibilityAgreement;
using Cnx.Caiman.Core.DTOs.ManualPlan;
using Cnx.Caiman.Core.DTOs.PriorityList;
using Cnx.Caiman.Core.Entities.QueryEntities.AsignacionViajes;
using Cnx.Caiman.Core.Interfaces;
using Cnx.Caiman.Core.Interfaces.Providers;
using Cnx.Caiman.Core.Interfaces.Services;
using Cemex.Core.Entities;
using Cemex.Core.Entities.Filters;
using Cemex.Core.Exceptions;
using Cemex.Core.Extension;
using ClosedXML.Excel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using RestSharp;
using System.Text.Json.Serialization;

namespace Cnx.Caiman.Core.Services
{
    public class AssignmentTripService : IAssignmentTripService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly PaginationConfiguration paginationConfiguration;
        private readonly IMapper mapper;
        private readonly IConfiguration Configuration;
        private readonly IRemoteConnection ftpConnection;

        public AssignmentTripService(IUnitOfWork unitOfWork, IOptions<PaginationConfiguration> options, IMapper Mapper, IConfiguration Configuration, IRemoteConnection ftpConnection)
        {
            this.unitOfWork = unitOfWork;
            this.paginationConfiguration = options.Value;
            this.mapper = Mapper;
            this.Configuration = Configuration;
            this.ftpConnection = ftpConnection;
        }

        public async Task DeleteAsync(int idTrip, string Vc20Usuario)
        {
            await this.unitOfWork.AssignmentTripRepository.DeleteAsync(idTrip, Vc20Usuario);
        }

        public async Task<ApiResponse<IEnumerable<KeyValuePair<int, string>>>> getPlanAssigListAsyc(PaginationQuery filter, int idZone, DateTime date)
        {
            filter.PageNumber = filter.PageNumber == 0 ? this.paginationConfiguration.DefaultPageNumber : filter.PageNumber;
            filter.PageSize = filter.PageSize == 0 ? this.paginationConfiguration.DefaultPageSize : filter.PageSize;

            var result = await this.unitOfWork.AssignmentTripRepository.getPlanAssigListAsyc(idZone, date);
            var productsPage = PageList<KeyValuePair<int, string>>.Create(result, filter.PageNumber, filter.PageSize);


            var response = new ApiResponse<IEnumerable<KeyValuePair<int, string>>>(result).ToPagination(productsPage);

            return response;
        }

        public async Task<ApiResponse<AceptTripListDto>> getAceptTripListAsyc(int resultTrip)
        {
            AceptTripListDto aceptTrip = new AceptTripListDto();
            var result = await this.unitOfWork.AssignmentTripRepository.getAceptTripListAsyc(resultTrip);

            foreach (var rows in result)
            {
                var fields = (KeyValuePair<string, object>)rows;

                switch (fields.Key)
                {
                    case "bAceptacion":
                        {
                            aceptTrip.bAceptacion = (bool)fields.Value;
                            break;
                        }
                    case "bCambio":
                        {
                            aceptTrip.bCambio = (bool)fields.Value;
                            break;
                        }
                    case "conveniosInf":
                        {
                            aceptTrip.conveniosInf = (fields.Value == null) ? 0 : (int)fields.Value;
                            break;
                        }
                    case "copia":
                        {
                            aceptTrip.copia = (bool)fields.Value;
                            break;
                        }
                    case "infactibles":
                        {
                            aceptTrip.infactibles = (fields.Value == null) ? 0 : (int)fields.Value;
                            break;
                        }
                    case "planAceptado":
                        {
                            aceptTrip.planAceptado = (bool)fields.Value;
                            break;
                        }
                    case "ArchivoEnviado":
                        {
                            aceptTrip.ArchivoEnviado = (int)fields.Value;
                            break;
                        }
                    case "EstatusAzure":
                        {
                            aceptTrip.EstatusAzure = (fields.Value == null) ? 0 : (int)fields.Value;
                            break;
                        }
                }
            }



            var response = new ApiResponse<AceptTripListDto>(aceptTrip);

            return response;
        }

        public async Task<ApiResponse<TripListCostsDto>> getCostsAsyc(TripListCostsParamsDto model)
        {

            var result = await this.unitOfWork.AssignmentTripRepository.getCostsAsyc(model);
            var map = this.mapper.Map<TripListCostsDto>(result);

            var response = new ApiResponse<TripListCostsDto>(map);

            return response;
        }

        public async Task<ApiResponse<IEnumerable<TripListDto>>> ListTripAsync(FilterGrid filter)
        {
            // PAGE DATA
            filter.Paging.PageNumber = filter.Paging.PageNumber == 0 ? this.paginationConfiguration.DefaultPageNumber : filter.Paging.PageNumber;
            filter.Paging.PageSize = filter.Paging.PageSize == 0 ? this.paginationConfiguration.DefaultPageSize : filter.Paging.PageSize;


            object objectMultiple = await this.unitOfWork.AssignmentTripRepository.ListTripAsync(filter.GetProperties(hasPaginationProperties: true));
            var trips = (IEnumerable<ViajeListarResult>)objectMultiple.GetType().GetProperty("records").GetValue(objectMultiple);
            var totalCount = (int)objectMultiple.GetType().GetProperty("count").GetValue(objectMultiple);

            // PAGINATION DATE
            var tripsPage = PageList<ViajeListarResult>.Create(trips, totalCount, filter.Paging.PageNumber, filter.Paging.PageSize);
            var tripsDto = this.mapper.Map<IEnumerable<TripListDto>>(tripsPage);
            // RESPONSE GENERAL SHIPPER
            return new ApiResponse<IEnumerable<TripListDto>>(tripsDto).ToPagination(tripsPage);
        }

        public async Task<ApiResponse<string>> ExportAsync(FilterGrid filter)
        {
            var agreements = await this.unitOfWork.AssignmentTripRepository.ListTripAsync(filter.GetProperties());
            var entity = (IEnumerable<ViajeListarResult>)agreements.GetType().GetProperty("records").GetValue(agreements);

            using (var workbook = new XLWorkbook())
            {
                string base64 = workbook.GetExcelFromEnumerableModel<ViajeListarResult>(entity, filter.Columns, "Reporte asignacion de viajes");
                return new ApiResponse<string>(base64);
            }
        }

        public async Task AceptAssignPlanAsync(AceptAssignPlanDto model)
        {
            var data = await this.unitOfWork.AssignmentTripRepository.SapFileJsonAsync();
            if (data == "J") {
               await this.AceptAssignPlanJsonAsync(model);
            }
            else
            {
                await this.AceptAssignPlanFileAsync(model);
            }
        }

        private async Task AceptAssignPlanJsonAsync(AceptAssignPlanDto model)
        {
            int IdStatus = 1;
            var resultTrips = await this.unitOfWork.AssignmentTripRepository.AceptAssignPlanAsync(model);


            var result = await this.unitOfWork.AssignmentTripRepository.TripsSapAsync(model);
            result.planType = "A";

            var SecretKey = this.Configuration.GetSection("TripsSend")["SecretKey"];


            var Uri = new Uri(Configuration.GetSection("TripsSend")["EndPoint"]);

            var options = new RestClientOptions($"{Uri.Scheme}://{Uri.Authority}") { ThrowOnAnyError = true, Timeout = -1 };

            var client = new RestClient(options);

            var request = new RestRequest(Uri.AbsolutePath, Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Ocp-Apim-Subscription-Key", SecretKey);

            var body = JsonConvert.SerializeObject(result);

            request.AddParameter("", body, ParameterType.RequestBody);
            var response = await client.ExecuteAsync(request);

            if (response.StatusCode != System.Net.HttpStatusCode.Accepted && response.StatusCode != System.Net.HttpStatusCode.OK)
                IdStatus = 2;

            string responseString = JsonConvert.SerializeObject(response);
            //se trunca a 200 el response porque en BD el campo vc20MensajeAzure es un varchar(200), quitar si se modifica el tipo de dato en BD
            //responseString = responseString.Length <= 200 ? responseString : responseString.Substring(0, 200);

            await this.unitOfWork.AssignmentTripRepository.UpdateStatusPlan(int.Parse(result.AssignmentPlanID), IdStatus, "A",responseString);

        }

        private async Task AceptAssignPlanFileAsync(AceptAssignPlanDto model)
        {
            var resultTrips = await this.unitOfWork.AssignmentTripRepository.AceptAssignPlanAsync(model);

            //TODO se comenta por el cambio de generacion
            //var resultInfoSicadi = await this.unitOfWork.AssignmentTripRepository.PlanSendSicadiAsync(model);

            var result = await this.unitOfWork.AssignmentTripRepository.TripsSapFileAsync(model);
            var tripResult = this.mapper.Map<List<ManualTripSapDto>>(result.Key);

            if (tripResult != null && tripResult.Count > 0)
            {
                var nameFile = result.Value;


                StringBuilder file = new StringBuilder();

                tripResult.ForEach(delegate (ManualTripSapDto item)
                {
                    file.Append((item.Pedido != null ? item.Pedido.ToString() : "") + "\t");
                    file.Append((item.Linea != null ? item.Linea.ToString() : "") + "\t");
                    file.Append((item.Destino != null ? item.Destino.ToString() : "") + "\t");
                    file.Append((item.Producto != null ? item.Producto.ToString() : "") + "\t");
                    file.Append((item.Origen != null ? item.Origen.ToString() : "") + "\t");
                    file.Append((item.Cedis != null ? item.Cedis.ToString() : "") + "\t");
                    file.Append((item.Transportista != null ? item.Transportista.ToString() : "") + "\t");
                    file.Append((item.Volumen != null ? item.Volumen.ToString() : "") + "\t");
                    file.Append((item.Unidad != null ? item.Unidad.ToString() : "") + "\t");
                    file.Append((item.FechaCompromiso?.ToString("yyyy-MM-dd HH:mm:ss")) + "\t");
                    file.Append((item.PagaFlete != null ? item.PagaFlete.ToString() : "") + "\t");
                    file.Append(item.Vehiculo != null ? item.Vehiculo.ToString() : "");
                    file.AppendLine("");
                });

                var server = this.Configuration.GetSection("SharedResource")["Server"];
                var user = this.Configuration.GetSection("SharedResource")["User"];
                var pass = this.Configuration.GetSection("SharedResource")["Pass"];
                var pathRemote = this.Configuration.GetSection("SharedResource")["FolderShare"];
                var protocol = this.Configuration.GetSection("SharedResource")["Protocol"];

                switch (protocol)
                {
                    case "SMB1":
                        await this.ftpConnection.UploadFileSMB1Async(file.ToString(), nameFile, pathRemote, user, pass, server);
                        break;
                    case "SMB2":
                        await this.ftpConnection.UploadFileAsync(file.ToString(), nameFile, pathRemote, user, pass, server);
                        break;
                    case "FTP":
                        await this.ftpConnection.UploadFileFTPAsync(file.ToString(), nameFile, pathRemote, user, pass, server);
                        break;
                }

                await this.unitOfWork.PlanManualRepository.FileCreateAsync(model.idresultado, file.ToString(), nameFile, "PA");
            }
        }

            //COMPONENT EDICION

            public async Task<ApiResponse<IEnumerable<ListEditTripDto>>> TripEditListAsync(FilterGrid filter)
        {
            filter.Paging.PageNumber = filter.Paging.PageNumber == 0 ? this.paginationConfiguration.DefaultPageNumber : filter.Paging.PageNumber;
            filter.Paging.PageSize = filter.Paging.PageSize == 0 ? this.paginationConfiguration.DefaultPageSize : filter.Paging.PageSize;


            object objectMultiple = await this.unitOfWork.AssignmentTripRepository.TripEditListAsync(filter.GetProperties(hasPaginationProperties: true));
            var tripEdit = (IEnumerable<ViajeListarEdicionResult>)objectMultiple.GetType().GetProperty("records").GetValue(objectMultiple);
            var totalCount = (int)objectMultiple.GetType().GetProperty("count").GetValue(objectMultiple);

            // PAGINATION DATE
            var tripsPage = PageList<ViajeListarEdicionResult>.Create(tripEdit, totalCount, filter.Paging.PageNumber, filter.Paging.PageSize);
            var tripsDto = this.mapper.Map<IEnumerable<ListEditTripDto>>(tripsPage);
            // RESPONSE GENERAL SHIPPER
            return new ApiResponse<IEnumerable<ListEditTripDto>>(tripsDto).ToPagination(tripsPage);
        }

        public async Task<ApiResponse<string>> TripEditListExportAsync(FilterGrid filter)
        {
            var agreements = await this.unitOfWork.AssignmentTripRepository.ListTripAsync(filter.GetProperties());
            var entity = (IEnumerable<ViajeListarEdicionResult>)agreements.GetType().GetProperty("records").GetValue(agreements);

            using (var workbook = new XLWorkbook())
            {
                string base64 = workbook.GetExcelFromEnumerableModel<ViajeListarEdicionResult>(entity, filter.Columns, "Reporte asignacion de viajes");
                return new ApiResponse<string>(base64);
            }
        }

        public async Task<ApiResponse<IEnumerable<KeyValuePair<int, string>>>> getTripCarrierListAsync(int idresult)
        {

            var result = await this.unitOfWork.AssignmentTripRepository.getTripCarrierListAsync(idresult);
            var response = new ApiResponse<IEnumerable<KeyValuePair<int, string>>>(result);

            return response;
        }

        public async Task<ApiResponse<IEnumerable<KeyValuePair<int, string>>>> getTripOriginListAsync(int idresult)
        {

            var result = await this.unitOfWork.AssignmentTripRepository.getTripOriginListAsync(idresult);
            var response = new ApiResponse<IEnumerable<KeyValuePair<int, string>>>(result);

            return response;
        }

        public async Task UpdateTripAsync(UpdateTripDto model)
        {
            await this.unitOfWork.AssignmentTripRepository.UpdateTripAsync(model);
        }

        //factibilidad

        private async Task<List<ListLinkDto>> getLink(int idzone, string date, int idresult)
        {
            var result = await this.unitOfWork.AssignmentTripRepository.ListsFactibilityAsync(idzone, 1, date, idresult);
            ListLinkDto olink;
            List<ListLinkDto> ListLink = new List<ListLinkDto>();
            foreach (var rows in result)
            {
                olink = new ListLinkDto();

                foreach (var item in rows)
                {
                    var fields = (KeyValuePair<string, object>)item;

                    switch (fields.Key)
                    {
                        case "Origen":
                            olink.Origen = fields.Value.ToString();
                            break;
                        case "Destino":
                            olink.Destino = fields.Value.ToString();
                            break;
                        case "Distancia":
                            olink.Distancia = fields.Value.ToString();
                            break;
                        case "Validacion":
                            olink.Validacion = (int)fields.Value;
                            break;
                    }
                }
                ListLink.Add(olink);
            }

            return ListLink;
        }

        private async Task<List<OwnLinkDto>> getOwnLink(int idzone, string date, int idresult)
        {
            var result = await this.unitOfWork.AssignmentTripRepository.ListsFactibilityAsync(idzone, 10, date, idresult);
            OwnLinkDto obj;
            List<OwnLinkDto> List = new List<OwnLinkDto>();
            foreach (var rows in result)
            {
                obj = new OwnLinkDto();
                foreach (var item in rows)
                {
                    var fields = (KeyValuePair<string, object>)item;
                    switch (fields.Key)
                    {
                        case "Transportista":
                            obj.Origen = fields.Value.ToString();
                            break;
                        case "Origen":
                            obj.Destino = fields.Value.ToString();
                            break;
                        case "Destino":
                            obj.Destino = fields.Value.ToString();
                            break;
                        case "Tarifa":
                            obj.Tarifa = fields.Value.ToString();
                            break;
                        case "Validacion":
                            obj.Validacion = (int)fields.Value;
                            break;
                    }
                }
                List.Add(obj);
            }

            return List;
        }

        private async Task<List<DemandvsOTDto>> getDemandvsOT(int idzone, string date, int idresult)
        {
            var result = await this.unitOfWork.AssignmentTripRepository.ListsFactibilityAsync(idzone, 6, date, idresult);
            DemandvsOTDto obj;
            List<DemandvsOTDto> List = new List<DemandvsOTDto>();
            foreach (var rows in result)
            {
                obj = new DemandvsOTDto();
                foreach (var item in rows)
                {
                    var fields = (KeyValuePair<string, object>)item;
                    switch (fields.Key)
                    {
                        case "Cantidad_asignada":
                            obj.Cantidad_asignada = (int)fields.Value;
                            break;
                        case "Oferta_Total":
                            obj.Oferta_Total = fields.Value.ToString();
                            break;
                        case "Transportista":
                            obj.Transportista = fields.Value.ToString();
                            break;
                        case "Validacion":
                            obj.Validacion = (int)fields.Value;
                            break;
                    }
                }
                List.Add(obj);
            }

            return List;
        }

        private async Task<List<ProductOriginDto>> getProductOrigin(int idzone, string date, int idresult)
        {
            var result = await this.unitOfWork.AssignmentTripRepository.ListsFactibilityAsync(idzone, 2, date, idresult);
            ProductOriginDto obj;
            List<ProductOriginDto> List = new List<ProductOriginDto>();
            foreach (var rows in result)
            {
                obj = new ProductOriginDto();
                foreach (var item in rows)
                {
                    var fields = (KeyValuePair<string, object>)item;
                    switch (fields.Key)
                    {
                        case "Origen":
                            obj.Origen = fields.Value.ToString();
                            break;
                        case "Producto":
                            obj.Producto = fields.Value.ToString();
                            break;
                        case "Validacion":
                            obj.Validacion = (int)fields.Value;
                            break;
                    }
                }
                List.Add(obj);
            }
            return List;
        }

        private async Task<List<ProductDestinationDto>> getProductDestination(int idzone, string date, int idresult)
        {
            var result = await this.unitOfWork.AssignmentTripRepository.ListsFactibilityAsync(idzone, 3, date, idresult);
            ProductDestinationDto obj;
            List<ProductDestinationDto> List = new List<ProductDestinationDto>();
            foreach (var rows in result)
            {
                obj = new ProductDestinationDto();
                foreach (var item in rows)
                {
                    var fields = (KeyValuePair<string, object>)item;
                    switch (fields.Key)
                    {
                        case "Destino":
                            obj.Destino = fields.Value.ToString();
                            break;
                        case "Producto":
                            obj.Producto = fields.Value.ToString();
                            break;
                        case "Validacion":
                            obj.Validacion = (int)fields.Value;
                            break;
                    }
                }
                List.Add(obj);
            }
            return List;
        }

        private async Task<List<AssignOfferDto>> getAssignOffer(int idzone, string date, int idresult)
        {
            var result = await this.unitOfWork.AssignmentTripRepository.ListsFactibilityAsync(idzone, 4, date, idresult);
            AssignOfferDto obj;
            List<AssignOfferDto> List = new List<AssignOfferDto>();
            foreach (var rows in result)
            {
                obj = new AssignOfferDto();
                foreach (var item in rows)
                {
                    var fields = (KeyValuePair<string, object>)item;
                    switch (fields.Key)
                    {
                        case "Cantidad_Asignada":
                            obj.Cantidad_Asignada = (int)fields.Value;
                            break;
                        case "Oferta_Total":
                            obj.Oferta_Total = (int)fields.Value;
                            break;
                        case "Origen":
                            obj.Origen = (fields.Value == null) ? "" : fields.Value.ToString();
                            break;
                        case "Producto":
                            obj.Producto = (fields.Value == null) ? "" : fields.Value.ToString();
                            break;
                        case "Validacion":
                            obj.Validacion = (int)fields.Value;
                            break;
                    }
                }
                List.Add(obj);
            }
            return List;
        }

        private async Task<List<DemandFulfilledDto>> getDemandFulfilled(int idzone, string date, int idresult)
        {
            var result = await this.unitOfWork.AssignmentTripRepository.ListsFactibilityAsync(idzone, 5, date, idresult);
            DemandFulfilledDto obj;
            List<DemandFulfilledDto> List = new List<DemandFulfilledDto>();
            foreach (var rows in result)
            {
                obj = new DemandFulfilledDto();
                foreach (var item in rows)
                {
                    var fields = (KeyValuePair<string, object>)item;
                    switch (fields.Key)
                    {
                        case "Cantidad_Asignada":
                            obj.Cantidad_Asignada = fields.Value.ToString();
                            break;
                        case "Demanda_total":
                            obj.Demanda_total = fields.Value.ToString();
                            break;
                        case "Destino":
                            obj.Destino = fields.Value.ToString();
                            break;
                        case "Producto":
                            obj.Producto = fields.Value.ToString();
                            break;
                        case "IdDestino":
                            obj.IdDestino = (int)fields.Value;
                            break;
                        case "IdFotoDemandaIndex":
                            obj.IdFotoDemandaIndex = (int)fields.Value;
                            break;
                        case "IdPlanAsignacion":
                            obj.IdPlanAsignacion = (int)fields.Value;
                            break;
                        case "IdProducto":
                            obj.IdProducto = (int)fields.Value;
                            break;
                        case "IdResultado":
                            obj.IdResultado = (int)fields.Value;
                            break;
                        case "Validacion":
                            obj.Validacion = (int)fields.Value;
                            break;
                    }
                }
                List.Add(obj);
            }
            return List;
        }

        private async Task<List<OfferHoursAssignDto>> getOfferHoursAssign(int idzone, string date, int idresult)
        {
            var result = await this.unitOfWork.AssignmentTripRepository.ListsFactibilityAsync(idzone, 9, date, idresult);
            OfferHoursAssignDto obj;
            List<OfferHoursAssignDto> List = new List<OfferHoursAssignDto>();
            foreach (var rows in result)
            {
                obj = new OfferHoursAssignDto();
                foreach (var item in rows)
                {
                    var fields = (KeyValuePair<string, object>)item;
                    switch (fields.Key)
                    {
                        case "Transportista":
                            obj.Transportista = fields.Value.ToString();
                            break;
                        case "Asignado":
                            obj.Asignado = (int)fields.Value;
                            break;
                        case "Oferta":
                            obj.Oferta = (decimal)fields.Value;
                            break;
                        case "Validacion":
                            obj.Validacion = (int)fields.Value;
                            break;
                    }
                }
                List.Add(obj);
            }
            return List;
        }


        private async Task<List<TravelRequestsDto>> getTravelRequests(int idzone, string date, int idresult)
        {
            var result = await this.unitOfWork.AssignmentTripRepository.ListsFactibilityAsync(idzone, 11, date, idresult);
            TravelRequestsDto obj;
            List<TravelRequestsDto> List = new List<TravelRequestsDto>();
            foreach (var rows in result)
            {
                obj = new TravelRequestsDto();
                foreach (var item in rows)
                {
                    var fields = (KeyValuePair<string, object>)item;
                    switch (fields.Key)
                    {
                        case "Transportista":
                            obj.Transportista = fields.Value.ToString();
                            break;
                        case "Origen":
                            obj.Origen = fields.Value.ToString();
                            break;
                        case "Destino":
                            obj.Destino = fields.Value.ToString();
                            break;
                        case "Producto":
                            obj.Producto = fields.Value.ToString();
                            break;
                        case "Pedidos_viaje":
                            obj.Pedidos_viaje = (int)fields.Value;
                            break;
                        case "Dif":
                            obj.Dif = (int)fields.Value;
                            break;
                        case "Validacion":
                            obj.Validacion = (int)fields.Value;
                            break;
                    }
                }
                List.Add(obj);
            }
            return List;
        }

        /// <summary>
        /// factibilidad prioriad
        /// </summary>
        /// <param name="idzone"></param>
        /// <param name="date"></param>
        /// <param name="idresult"></param>
        /// <returns></returns>
        private async Task<List<PriorityOriginDto>> getPriorityOrigin(int idzone, int idresult)
        {
            var result = await this.unitOfWork.AssignmentTripRepository.ListsPriorityAsync(idzone, idresult, 1);
            PriorityOriginDto obj;
            List<PriorityOriginDto> List = new List<PriorityOriginDto>();
            foreach (var rows in result)
            {
                obj = new PriorityOriginDto();
                foreach (var item in rows)
                {
                    var fields = (KeyValuePair<string, object>)item;
                    switch (fields.Key)
                    {
                        case "Folio":
                            obj.Folio = (int)fields.Value;
                            break;
                        case "Origen":
                            obj.Origen = fields.Value.ToString();
                            break;
                        case "Asignado":
                            obj.Asignado = fields.Value.ToString();
                            break;
                        case "imaniana":
                            obj.imaniana = (int)fields.Value;
                            break;
                        case "itarde":
                            obj.itarde = (int)fields.Value;
                            break;
                        case "inoche":
                            obj.inoche = (int)fields.Value;
                            break;
                    }
                }
                List.Add(obj);
            }
            return List;
        }

        private async Task<List<PriorityDemandDto>> getPriorityDemand(int idzone, int idresult)
        {
            var result = await this.unitOfWork.AssignmentTripRepository.ListsPriorityAsync(idzone, idresult, 2);
            PriorityDemandDto obj;
            List<PriorityDemandDto> List = new List<PriorityDemandDto>();
            foreach (var rows in result)
            {
                obj = new PriorityDemandDto();
                foreach (var item in rows)
                {
                    var fields = (KeyValuePair<string, object>)item;
                    switch (fields.Key)
                    {
                        case "Folio":
                            obj.Folio = (int)fields.Value;
                            break;
                        case "Destino":
                            obj.Destino = fields.Value.ToString();
                            break;
                        case "Producto":
                            obj.Producto = fields.Value.ToString();
                            break;
                        case "Asignado":
                            obj.Asignado = fields.Value.ToString();
                            break;
                        case "imaniana":
                            obj.imaniana = (int)fields.Value;
                            break;
                        case "itarde":
                            obj.itarde = (int)fields.Value;
                            break;
                        case "inoche":
                            obj.inoche = (int)fields.Value;
                            break;
                    }
                }
                List.Add(obj);
            }
            return List;
        }

        private async Task<List<CapacityModelDto>> getCapacity(int idzone, int idresult, int entity)
        {
            var result = await this.unitOfWork.AssignmentTripRepository.ListsPriorityAsync(idzone, idresult, entity);
            CapacityModelDto obj;
            List<CapacityModelDto> List = new List<CapacityModelDto>();

            foreach (var rows in result)
            {
                obj = new CapacityModelDto();

                foreach (var item in rows)
                {
                    var fields = (KeyValuePair<string, object>)item;
                    switch (fields.Key)
                    {
                        case "Origen":
                            obj.Nombre = fields.Value.ToString();
                            break;
                        case "Destino":
                            obj.Nombre = fields.Value.ToString();
                            break;
                        case "Transportista":
                            obj.Nombre = fields.Value.ToString();
                            break;
                        case "Horario":
                            obj.Horario = fields.Value.ToString();
                            break;
                        case "Cantidad":
                            obj.Cantidad = (int)fields.Value;
                            break;
                        case "viajes":
                            obj.viajes = (int)fields.Value;
                            break;
                    }
                }
                List.Add(obj);
            }
            return List;
        }

        public async Task<ApiResponse<FeasibilityDto>> getFeasibilityAsync(int idzone, string date, int idresult)
        {
            var Feasibility = new FeasibilityDto();
            Feasibility.link = new List<ListLinkDto>(await this.getLink(idzone, date, idresult));
            Feasibility.OwnLink = new List<OwnLinkDto>(await this.getOwnLink(idzone, date, idresult));
            Feasibility.DemandvsOT = new List<DemandvsOTDto>(await this.getDemandvsOT(idzone, date, idresult));
            Feasibility.ProductOrigin = new List<ProductOriginDto>(await this.getProductOrigin(idzone, date, idresult));
            Feasibility.ProductDestination = new List<ProductDestinationDto>(await this.getProductDestination(idzone, date, idresult));
            Feasibility.AssignOffer = new List<AssignOfferDto>(await this.getAssignOffer(idzone, date, idresult));
            Feasibility.DemandFulfilled = new List<DemandFulfilledDto>(await this.getDemandFulfilled(idzone, date, idresult));
            Feasibility.OfferHoursAssign = new List<OfferHoursAssignDto>(await this.getOfferHoursAssign(idzone, date, idresult));
            Feasibility.TravelRequests = new List<TravelRequestsDto>(await this.getTravelRequests(idzone, date, idresult));
            //capacity
            Feasibility.PriorityOrigin = new List<PriorityOriginDto>(await this.getPriorityOrigin(idzone, idresult));
            Feasibility.PriorityDemand = new List<PriorityDemandDto>(await this.getPriorityDemand(idzone, idresult));
            Feasibility.CapacityDispatch = new List<CapacityModelDto>(await this.getCapacity(idzone, idresult, 3));
            Feasibility.CapacityReception = new List<CapacityModelDto>(await this.getCapacity(idzone, idresult, 4));
            Feasibility.CapacityDispatchCarrier = new List<CapacityModelDto>(await this.getCapacity(idzone, idresult, 5));


            var response = new ApiResponse<FeasibilityDto>(Feasibility);

            return response;

        }

        //FACTIBILIDAD CONVENIOS
        private async Task<List<OfferPriorityDto>> getOfferPriority(int idzone, string date, int idresult)
        {
            var result = await this.unitOfWork.AssignmentTripRepository.ListsFactibilityAsync(idzone, 8, date, idresult);
            OfferPriorityDto obj;
            List<OfferPriorityDto> List = new List<OfferPriorityDto>();
            foreach (var rows in result)
            {
                obj = new OfferPriorityDto();
                foreach (var item in rows)
                {
                    var fields = (KeyValuePair<string, object>)item;
                    switch (fields.Key)
                    {
                        case "Origen":
                            obj.Origen = fields.Value.ToString();
                            break;
                        case "Producto":
                            obj.Producto = fields.Value.ToString();
                            break;
                        case "Oferta":
                            obj.Oferta = (int)fields.Value;
                            break;
                        case "Asignado":
                            obj.Asignado = (int)fields.Value;
                            break;
                        case "Validacion":
                            obj.Validacion = (int)fields.Value;
                            break;
                    }
                }
                List.Add(obj);
            }
            return List;
        }

        private async Task<List<OfferShipperPriorityDto>> getOfferShipperPriority(int idzone, string date, int idresult)
        {
            var result = await this.unitOfWork.AssignmentTripRepository.ListsFactibilityAsync(idzone, 7, date, idresult);
            OfferShipperPriorityDto obj;
            List<OfferShipperPriorityDto> List = new List<OfferShipperPriorityDto>();
            foreach (var rows in result)
            {
                obj = new OfferShipperPriorityDto();
                foreach (var item in rows)
                {
                    var fields = (KeyValuePair<string, object>)item;
                    switch (fields.Key)
                    {
                        case "Transportista":
                            obj.Transportista = fields.Value.ToString();
                            break;
                        case "Oferta":
                            obj.Oferta = (int)fields.Value;
                            break;
                        case "Asignado":
                            obj.Asignado = (int)fields.Value;
                            break;
                        case "Validacion":
                            obj.Validacion = (int)fields.Value;
                            break;
                    }
                }
                List.Add(obj);
            }
            return List;
        }

        public async Task<ApiResponse<FeasibilityAgreementDto>> getFeasibilityAgreementAsync(int idzone, string date, int idresult)
        {
            var FeasibilityAgreement = new FeasibilityAgreementDto();
            FeasibilityAgreement.OfferPriority = new List<OfferPriorityDto>(await this.getOfferPriority(idzone, date, idresult));
            FeasibilityAgreement.OfferShipperPriority = new List<OfferShipperPriorityDto>(await this.getOfferShipperPriority(idzone, date, idresult));

            var response = new ApiResponse<FeasibilityAgreementDto>(FeasibilityAgreement);

            return response;

        }

        public async Task<ApiResponse<IEnumerable<RestrictionListUnfulfilledDto>>> ListFeasibilityAgreementAsync(FilterGrid filter)
        {
            filter.Paging.PageNumber = filter.Paging.PageNumber == 0 ? this.paginationConfiguration.DefaultPageNumber : filter.Paging.PageNumber;
            filter.Paging.PageSize = filter.Paging.PageSize == 0 ? this.paginationConfiguration.DefaultPageSize : filter.Paging.PageSize;


            object objectMultiple = await this.unitOfWork.AssignmentTripRepository.ListFeasibilityAgreementAsync(filter.GetProperties(hasPaginationProperties: true));
            var tripEdit = (IEnumerable<RestriccionListarIncumplidoResult>)objectMultiple.GetType().GetProperty("records").GetValue(objectMultiple);
            var totalCount = (int)objectMultiple.GetType().GetProperty("count").GetValue(objectMultiple);

            // PAGINATION DATE
            var tripsPage = PageList<RestriccionListarIncumplidoResult>.Create(tripEdit, totalCount, filter.Paging.PageNumber, filter.Paging.PageSize);
            var tripsDto = this.mapper.Map<IEnumerable<RestrictionListUnfulfilledDto>>(tripsPage);
            // RESPONSE GENERAL SHIPPER
            return new ApiResponse<IEnumerable<RestrictionListUnfulfilledDto>>(tripsDto).ToPagination(tripsPage);
        }

        public async Task<ApiResponse<string>> FeasibilityAgreementExportAsync(FilterGrid filter)
        {
            var agreements = await this.unitOfWork.AssignmentTripRepository.ListFeasibilityAgreementAsync(filter.GetProperties());
            var entity = (IEnumerable<RestriccionListarIncumplidoResult>)agreements.GetType().GetProperty("records").GetValue(agreements);

            using (var workbook = new XLWorkbook())
            {
                string base64 = workbook.GetExcelFromEnumerableModel<RestriccionListarIncumplidoResult>(entity, filter.Columns, "Reporte factibilidad convenio");
                return new ApiResponse<string>(base64);
            }
        }

        //reevaluar
        public async Task ReevaluateTripAsync(ReevaluateDto model)
        {
            await this.unitOfWork.AssignmentTripRepository.ReevaluateTripAsync(model.resultado);
        }

        //Nuevo plan
        public async Task<ApiResponse<IEnumerable<KeyValuePair<int, string>>>> getFilterListElementAsync(FilterListElementDto filter)
        {
            filter.PageNumber = filter.PageNumber == 0 ? this.paginationConfiguration.DefaultPageNumber : filter.PageNumber;
            filter.PageSize = filter.PageSize == 0 ? this.paginationConfiguration.DefaultPageSize : filter.PageSize;

            var result = await this.unitOfWork.AssignmentTripRepository.getFilterListElementAsync(filter);
            var filters = PageList<KeyValuePair<int, string>>.Create(result, filter.PageNumber, filter.PageSize);


            var response = new ApiResponse<IEnumerable<KeyValuePair<int, string>>>(result).ToPagination(filters);

            return response;
        }

        public async Task<ApiResponse<int>> InsertPlanTripAsync(InsertPlanTripDto model)
        {
            var result = await this.unitOfWork.AssignmentTripRepository.InsertPlanTripAsync(model);
            var response = new ApiResponse<int>(result);

            return response;
        }

    }
}
