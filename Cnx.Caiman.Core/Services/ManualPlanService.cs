using AutoMapper;
using Cnx.Caiman.Core.DTOs.ManualPlan;
using Cnx.Caiman.Core.Entities;
using Cnx.Caiman.Core.Entities.QueryEntities.CuboDiario;
using Cnx.Caiman.Core.Entities.QueryEntities.PlanManualInfo_Nvo;
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;

namespace Cnx.Caiman.Core.Services
{
    public class ManualPlanService : IManualPlanService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly PaginationConfiguration paginationConfiguration;
        private readonly IMapper mapper;
        private readonly IRemoteConnection ftpConnection;
        private readonly IConfiguration Configuration;

        public ManualPlanService(IUnitOfWork unitOfWork, IOptions<PaginationConfiguration> options, IMapper Mapper, IRemoteConnection ftpConnection, IConfiguration Configuration)
        {
            this.unitOfWork = unitOfWork;
            paginationConfiguration = options.Value;
            this.mapper = Mapper;
            this.ftpConnection = ftpConnection;
            this.Configuration = Configuration;
        }

        public async Task<ApiResponse<List<ManualPlanDto>>> GetPlanAsync(PaginationQuery filter, int idzone, DateTime date)
        {
            if (idzone == 0)
            {
                throw new BusinessException("El valor zona debe ser mayor a cero.");
            }

            filter.PageNumber = filter.PageNumber == 0 ? this.paginationConfiguration.DefaultPageNumber : filter.PageNumber;
            filter.PageSize = filter.PageSize == 0 ? this.paginationConfiguration.DefaultPageSize : filter.PageSize;

            var entity = await this.unitOfWork.PlanManualRepository.GetPlanAsync(idzone, date);

            var responsePage = PageList<PlanManual>.Create(entity, filter.PageNumber, filter.PageSize);

            var map = this.mapper.Map<List<ManualPlanDto>>(responsePage);

            var response = new ApiResponse<List<ManualPlanDto>>(map).ToPagination(responsePage);

            return response;
        }

        public async Task<ApiResponse<ManualPlanInfoDto>> GetPlanInfoAsync(FilterGrid filter)
        {
            filter.Paging.PageNumber = filter.Paging.PageNumber == 0 ? this.paginationConfiguration.DefaultPageNumber : filter.Paging.PageNumber;
            filter.Paging.PageSize = filter.Paging.PageSize == 0 ? this.paginationConfiguration.DefaultPageSize : filter.Paging.PageSize;

            var entity = await this.unitOfWork.PlanManualRepository.GetManualInfoAsync(filter.GetProperties(hasPaginationProperties: true));

            var manualPlanResult = (PlanManualResult)entity.GetType().GetProperty("ManualPlanCollection").GetValue(entity);
            var manualTripResul = (IEnumerable<ViajeManualResult>)entity.GetType().GetProperty("ViajeManualuserCollection").GetValue(entity);
            var totalCount = (int)entity.GetType().GetProperty("total").GetValue(entity);


            var responsePage = PageList<ViajeManualResult>.Create(manualTripResul, totalCount, filter.Paging.PageNumber, filter.Paging.PageSize);

            var mapplan = this.mapper.Map<ManualPlanInfoDto>(manualPlanResult);
            var maptripPage = this.mapper.Map<List<ManualPlanTripDto>>(responsePage);


            mapplan.planManualDetalle = new List<ManualPlanTripDto>();
            mapplan.planManualDetalle = maptripPage;

            var response = new ApiResponse<ManualPlanInfoDto>(mapplan).ToPagination(responsePage);

            return response;
        }

        public async Task<ApiResponse<string>> GetInfoListExportAsync(FilterGrid filter)
        {
            var entity = await this.unitOfWork.PlanManualRepository.GetManualInfoAsync(filter.GetProperties());

            var manualTripResul = (IEnumerable<ViajeManualResult>)entity.GetType().GetProperty("ViajeManualuserCollection").GetValue(entity);
            // CREATE EXCEL FILE
            using (var workbook = new XLWorkbook())
            {
                string base64 = workbook.GetExcelFromEnumerableModel<ViajeManualResult>(manualTripResul, filter.Columns, "Reporte planes");
                return new ApiResponse<string>(base64);
            }

        }

        public async Task<ApiResponse<long>> InsertAsync(int idzone, DateTime date, string user)
        {

            if (idzone == 0)
                throw new BusinessException("El valor zona debe ser mayor a cero.");

            if (string.IsNullOrEmpty(user))
                throw new BusinessException("El usuario debe ser diferente a nulo o vacio.");

            var result = await this.unitOfWork.PlanManualRepository.InsertAsync(idzone, date, user);

            return new ApiResponse<long>(result);
        }

        public async Task AuthorizeAsync(ManualPlanUpdateDto model)
        {

            if (model.idplan == 0)
                throw new BusinessException("El valor zona debe ser mayor a cero.");

            await this.unitOfWork.PlanManualRepository.AuthorizeAsync(model);
        }
        public async Task<ApiResponse<ManualTripSapDto>> AcceptAsync(ManualPlanUpdateDto model)
        {
            var data = await this.unitOfWork.AssignmentTripRepository.SapFileJsonAsync();
            if (data == "J")
            {
              return  await this.AcceptJsonAsync(model);
            }
            else
            {
              return await this.AcceptFileAsync(model);
            }
        }

        public async Task<ApiResponse<ManualTripSapDto>> AcceptJsonAsync(ManualPlanUpdateDto model)
        {
            int IdStatus = 1;
            if (model.idplan == 0)
                throw new BusinessException("El valor zona debe ser mayor a cero.");


            var result = await this.unitOfWork.PlanManualRepository.AcceptAsync(model);
            result.planType = "M";

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

            await this.unitOfWork.AssignmentTripRepository.UpdateStatusPlan(int.Parse(result.AssignmentPlanID), IdStatus, "M",responseString);

            return new ApiResponse<ManualTripSapDto>(null);

        }

        public async Task<ApiResponse<ManualTripSapDto>> AcceptFileAsync(ManualPlanUpdateDto model)
        {
            if (model.idplan == 0)
                throw new BusinessException("El valor zona debe ser mayor a cero.");


            var result = await this.unitOfWork.PlanManualRepository.AcceptFileAsync(model);

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

                switch(protocol)
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

                await this.unitOfWork.PlanManualRepository.FileCreateAsync(model.idplan, file.ToString(), nameFile, "PM");

            }

            return new ApiResponse<ManualTripSapDto>(null);

        }

        public async Task<ApiResponse<CubeDailyAggDto>> CubeDailyAsync(PaginationQuery filter, int idzone, int? iddestination)
        {
            try
            {
                if (idzone == 0)
                    throw new BusinessException("El valor zona debe ser mayor a cero.");

                var result = await this.unitOfWork.PlanManualRepository.DailyCubeAsync(idzone, filter.Search, iddestination);

                CubeDailyAggDto root = new CubeDailyAggDto();

                var DestinationProduct = (List<CuboCaimanReal>)result.GetType().GetProperty("destinationProduct").GetValue(result);
                var originShipper = (List<CuboDiario>)result.GetType().GetProperty("originShipper").GetValue(result);
                var UM = (string)result.GetType().GetProperty("UM").GetValue(result);

                root.destination = new List<ManualFilterDestinationDto>();

                //obtenemos la lista de destinos
                var listDesitnacion = DestinationProduct.Select(k =>
                    new ManualFilterDestinationDto
                    {
                        id = k.IdDestino,
                        Description = k.Destino + "(" + k.Vc12ClaveSap + ")"
                    }).Distinct().ToList();


                //Obtnemos la lista de productos dependiendo del desitno
                listDesitnacion.ForEach(delegate (ManualFilterDestinationDto item) {
                    var Products = DestinationProduct.Where(k => k.IdDestino == item.id).Select(s => new ManualFilterProductDTO
                    { id = s.IdProducto, Description = s.Producto }).ToList();
                    item.product = Products.Distinct().ToList();
                });

                //Obtnemos la lista de orignenes acorde el destino y producto
                listDesitnacion.ForEach(delegate (ManualFilterDestinationDto item)
                {

                    foreach (var prodcut in item.product)
                    {
                        var Idoriginlist = DestinationProduct.Where(k => k.IdDestino == item.id && k.IdProducto == prodcut.id).Select(s => s.IdOrigen).Distinct().ToList();

                        var originlist = originShipper.Where(k => Idoriginlist.Contains(k.IdOrigen)).Select(s => new ManualFilterOriginDTO { id = s.IdOrigen, Description = s.Origen }).Distinct().ToList();

                        prodcut.origin = originlist;
                    }
                });

                //Llenamos la lista de transportista dependiento del origen
                listDesitnacion.ForEach(delegate (ManualFilterDestinationDto item)
                {
                    foreach (var product in item.product)
                    {
                        foreach (var origin in product.origin)
                        {
                            var listshipper = originShipper.Where(k => k.IdOrigen == origin.id).Select(s => new ManualFilteShipperDTO
                            {
                                id = s.IdTransportista,
                                Description = s.Transportista,
                                Fee = s.nTarifa,
                                SingleAmount = s.iCantSencillos,
                                TripAmount = s.nCantidadPorViaje
                            }).ToList();

                            origin.Shipper = listshipper;
                        }
                    }
                });

                filter.PageNumber = filter.PageNumber == 0 ? this.paginationConfiguration.DefaultPageNumber : filter.PageNumber;
                filter.PageSize = filter.PageSize == 0 ? this.paginationConfiguration.DefaultPageSize : filter.PageSize;

                var listDesitnacionPage = PageList<ManualFilterDestinationDto>.Create(listDesitnacion, filter.PageNumber, filter.PageSize);

                root.UM = UM;
                root.destination = listDesitnacionPage;

                return new ApiResponse<CubeDailyAggDto>(root);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task InsertTripManualAsync(ManualTripDto model)
        {
            if (model.idTrip == 0)
                throw new BusinessException("El valor viaje debe ser mayor a cero.");
            if (model.idManualPlan == 0)
                throw new BusinessException("El valor plan manual debe ser mayor a cero.");
            if (model.idShidder == 0)
                throw new BusinessException("El valor transportista debe ser mayor a cero.");
            if (model.idDestination == 0)
                throw new BusinessException("El valor destino debe ser mayor a cero.");
            if (model.idProduct == 0)
                throw new BusinessException("El valor producto debe ser mayor a cero.");
            if (model.idOrigin == 0)
                throw new BusinessException("El valor origen debe ser mayor a cero.");

            await this.unitOfWork.PlanManualRepository.InsertTripManualAsync(model);
        }

        public async Task DeleteAsync(long idtrip)
        {
            await this.unitOfWork.PlanManualRepository.DeleteAsync(idtrip);
        }
    }
}
