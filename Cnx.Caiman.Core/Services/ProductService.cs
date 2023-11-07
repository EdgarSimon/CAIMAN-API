using AutoMapper;
using Cnx.Caiman.Core.DTOs.Product;
using Cnx.Caiman.Core.Entities;
using Cnx.Caiman.Core.Entities.Filters;
using Cnx.Caiman.Core.Enums;
using Cnx.Caiman.Core.Interfaces;
using Cnx.Caiman.Core.Interfaces.Services;
using Cemex.Core.Entities;
using Cemex.Core.Entities.Filters;
using Cemex.Core.Exceptions;
using Cemex.Core.Extension;
using ClosedXML.Excel;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cnx.Caiman.Core.Services
{
    public class ProductService: IProductService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly PaginationConfiguration paginationConfiguration;
        private readonly IMapper mapper;
        public ProductService(IUnitOfWork unitOfWork, IOptions<PaginationConfiguration> options, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.paginationConfiguration = options.Value;
            this.mapper = mapper;
        }

        public Task<int> DeleteAsync(string idProduct, string user)
        {
            return this.unitOfWork.ProductRepository.DeleteAsync(idProduct, user);
        }

        public async Task<ApiResponse<IEnumerable<ProductDto>>> GetAsync(FilterGrid filter)
        {
            
            filter.Paging.PageNumber = filter.Paging.PageNumber == 0 ? this.paginationConfiguration.DefaultPageNumber : filter.Paging.PageNumber;
            filter.Paging.PageSize = filter.Paging.PageSize == 0 ? this.paginationConfiguration.DefaultPageSize : filter.Paging.PageSize;
            IEnumerable<Producto> products = await this.unitOfWork.ProductRepository.GetAsync(filter.GetProperties());
            var productsPage = PageList<Producto>.Create(products, filter.Paging.PageNumber, filter.Paging.PageSize);
            var map = this.mapper.Map<IEnumerable<ProductDto>>(productsPage);
            return new ApiResponse<IEnumerable<ProductDto>>(map).ToPagination(productsPage);
        }
        public async Task<ApiResponse<string>> ExportAsync(FilterGrid filter)
        {
            IEnumerable<Producto> products = await this.unitOfWork.ProductRepository.GetAsync(filter.GetProperties());
            using (var workbook = new XLWorkbook())
            {
                string base64 = workbook.GetExcelFromEnumerableModel<Producto>(products, filter.Columns, "Reporte Productos");
                return new ApiResponse<string>(base64);
            }
        }

        public async Task<ApiResponse<IEnumerable<ProductDto>>> GetByZoneAllAsync(FilterZone filter, bool isagreement, string idFiltrados)
        {
            filter.PageNumber = filter.PageNumber == 0 ? this.paginationConfiguration.DefaultPageNumber : filter.PageNumber;
            filter.PageSize = filter.PageSize == 0 ? this.paginationConfiguration.DefaultPageSize : filter.PageSize;
            
            var products = await this.unitOfWork.ProductRepository.GetByZoneAllAsync(Convert.ToInt32(filter.IdZona), isagreement, filter.Search);
            var productsPage = PageList<Producto>.Create(products, filter.PageNumber, filter.PageSize);

            if (!string.IsNullOrEmpty(idFiltrados))
            {
                foreach (var item in idFiltrados.Split(','))
                {
                    if (!productsPage.Exists(k => k.IdProducto == Convert.ToInt32(item)))
                    {
                        var product = products.FirstOrDefault(k => k.IdProducto == Convert.ToInt32(item));

                        if (product != null)
                            productsPage.Add(product);
                    }
                }
            }

            var map = this.mapper.Map<List<ProductDto>>(productsPage);
            var response =new ApiResponse<IEnumerable<ProductDto>>(map).ToPagination(productsPage);
            return response;
        }

        public async Task<ApiResponse<IEnumerable<ProductDto>>> GetRestrictionAsync(PaginationQuery filter, int idZone, long tid)
        {
            filter.PageNumber = filter.PageNumber == 0 ? this.paginationConfiguration.DefaultPageNumber : filter.PageNumber;
            filter.PageSize = filter.PageSize == 0 ? this.paginationConfiguration.DefaultPageSize : filter.PageSize;

            var result = await this.unitOfWork.ProductRepository.GetRestrictionAsync(idZone, tid, filter.Search);
            var productsPage = PageList<Producto>.Create(result, filter.PageNumber, filter.PageSize);
            var map = this.mapper.Map<List<ProductDto>>(productsPage);


            var response = new ApiResponse<IEnumerable<ProductDto>>(map).ToPagination(productsPage);

            return response;
        }

        public async Task<ApiResponse<IEnumerable<ProductDto>>> GetRestrictionOneToOneAsync(PaginationQuery filter, int idZone, long tid)
        {
            filter.PageNumber = filter.PageNumber == 0 ? this.paginationConfiguration.DefaultPageNumber : filter.PageNumber;
            filter.PageSize = filter.PageSize == 0 ? this.paginationConfiguration.DefaultPageSize : filter.PageSize;

            var result = await this.unitOfWork.ProductRepository.GetRestrictionOneToOneAsync(idZone, tid);
            var productsPage = PageList<Producto>.Create(result, filter.PageNumber, filter.PageSize);
            var map = this.mapper.Map<List<ProductDto>>(productsPage);


            var response = new ApiResponse<IEnumerable<ProductDto>>(map).ToPagination(productsPage);

            return response;
        }

        public async Task<ApiResponse<IEnumerable<ProductDto>>> GetRestrictionInvolvedAsync(PaginationQuery filter, int idZone, long tid)
        {
            filter.PageNumber = filter.PageNumber == 0 ? this.paginationConfiguration.DefaultPageNumber : filter.PageNumber;
            filter.PageSize = filter.PageSize == 0 ? this.paginationConfiguration.DefaultPageSize : filter.PageSize;

            var result = await this.unitOfWork.ProductRepository.GetRestrictionInvolvedAsync(idZone, tid);
            var productsPage = PageList<Producto>.Create(result, filter.PageNumber, filter.PageSize);
            var map = this.mapper.Map<List<ProductDto>>(productsPage);


            var response = new ApiResponse<IEnumerable<ProductDto>>(map).ToPagination(productsPage);

            return response;
        }

        public async Task<ApiResponse<IEnumerable<ProductDto>>> GetRestrictionInvolvedOneToOneAsync(PaginationQuery filter, int idZone, long tid)
        {
            filter.PageNumber = filter.PageNumber == 0 ? this.paginationConfiguration.DefaultPageNumber : filter.PageNumber;
            filter.PageSize = filter.PageSize == 0 ? this.paginationConfiguration.DefaultPageSize : filter.PageSize;

            var result = await this.unitOfWork.ProductRepository.GetRestrictionInvolvedOneToOneAsync(idZone, tid);
            var productsPage = PageList<Producto>.Create(result, filter.PageNumber, filter.PageSize);
            var map = this.mapper.Map<List<ProductDto>>(productsPage);


            var response = new ApiResponse<IEnumerable<ProductDto>>(map).ToPagination(productsPage);

            return response;
        }

        public async Task InsertRestrictionAsync(ProductRestrictionDto data)
        {
            if (data.tid == 0)
            {
                throw new BusinessException("The tid must be greater than zero.");
            }

            await this.unitOfWork.ProductRepository.InsertRestrictionAsync(data);
        }

        public async Task InsertRestrictionOneToOneAsync(ProductRestrictionDto data)
        {
            if (data.tid == 0)
            {
                throw new BusinessException("The tid must be greater than zero.");
            }

            await this.unitOfWork.ProductRepository.InsertRestrictionOneToOneAsync(data.tid, data.value255);
        }
        public async Task<ApiResponse<IEnumerable<ProductDto>>> GetProductsByOriginAsync(int idOrigin, PaginationQuery filter)
        {
            filter.PageNumber = filter.PageNumber == 0 ? this.paginationConfiguration.DefaultPageNumber : filter.PageNumber;
            filter.PageSize = filter.PageSize == 0 ? this.paginationConfiguration.DefaultPageSize : filter.PageSize;
            var products = await this.unitOfWork.ProductRepository.GetProductsByOriginAsync(idOrigin);
            var productsPage = PageList<Producto>.Create(products, filter.PageNumber, filter.PageSize);
            var map = this.mapper.Map<IEnumerable<ProductDto>>(productsPage);
            return new ApiResponse<IEnumerable<ProductDto>>(map).ToPagination(productsPage);
        }

        public async Task<ApiResponse<IEnumerable<TypeProductDto>>> GetTypesProductsAsync(int idZone, bool? aplyAll)
        {
            var products = await this.unitOfWork.ProductRepository.GetTypesProductsAsync(idZone, aplyAll);
            var map = this.mapper.Map<IEnumerable<TypeProductDto>>(products);
            return new ApiResponse<IEnumerable<TypeProductDto>>(map);

        }

        public async Task<int> InsertAsync(ProductInsertDto data)
        {
            var response = await this.unitOfWork.ProductRepository.InsertAsync(data);
            if(response == -1)
                throw new BusinessException("ProductDuplicate");
            return response;
        }

        public Task<int> InsertMonthlyAsync(ProductInsertDto data)
        {
            return this.unitOfWork.ProductRepository.InsertMonthlyAsync(data);
        }

        public async Task<int> InsertShortAsync(ProductShortInsertDto data)
        {
            var response = await this.unitOfWork.ProductRepository.InsertShortAsync(data);
            if(response == (int)StatusExceptions.ErrorDuplicate)
                throw new DuplicateException(MessageCodesErrors.Duplicate);
            return response;
        }

        public Task<int> UpdateAsync(int idProduct, ProductInsertDto data)
        {
            return this.unitOfWork.ProductRepository.UpdateAsync(idProduct, data);
        }

        public async Task<int> UpdateRelationMonthlyAsync(int idProduct, ProductoRelationMonthlyUpdateDto data)
        {
            return await this.unitOfWork.ProductRepository.UpdateRelationMonthlyAsync(idProduct, data);
        }

        public async Task<ApiResponse<IEnumerable<ProductDto>>> GetProductDestinationByIdAsync(int idDestination, PaginationQuery filter)
        {
            filter.PageNumber = filter.PageNumber == 0 ? this.paginationConfiguration.DefaultPageNumber : filter.PageNumber;
            filter.PageSize = filter.PageSize == 0 ? this.paginationConfiguration.DefaultPageSize : filter.PageSize;
            var objectMultiple = await this.unitOfWork.ProductRepository.GetProductDestinationByIdAsync(idDestination, filter.PageNumber, filter.PageSize);
            var products = (IEnumerable<Producto>)objectMultiple.GetType().GetProperty("records").GetValue(objectMultiple);
            var totalCount = (int)objectMultiple.GetType().GetProperty("count").GetValue(objectMultiple);
            var productsPage = PageList<Producto>.Create(products, totalCount, filter.PageNumber, filter.PageSize);
            var map = this.mapper.Map<IEnumerable<ProductDto>>(productsPage);
            return new ApiResponse<IEnumerable<ProductDto>>(map).ToPagination(productsPage);
        }

        public async Task<ApiResponse<IEnumerable<ProductDto>>> GetProductDistanceByIdAsync(int idDestination, PaginationQuery filter)
        {
            filter.PageNumber = filter.PageNumber == 0 ? this.paginationConfiguration.DefaultPageNumber : filter.PageNumber;
            filter.PageSize = filter.PageSize == 0 ? this.paginationConfiguration.DefaultPageSize : filter.PageSize;
            
            var objectMultiple = await this.unitOfWork.ProductRepository.GetProductDistanceByIdAsync(idDestination, filter);
            
            var products = (IEnumerable<Producto>)objectMultiple.GetType().GetProperty("records").GetValue(objectMultiple);
            var totalCount = (int)objectMultiple.GetType().GetProperty("count").GetValue(objectMultiple);
            
            var productsPage = PageList<Producto>.Create(products, totalCount, filter.PageNumber, filter.PageSize);
            var map = this.mapper.Map<IEnumerable<ProductDto>>(productsPage);
            
            return new ApiResponse<IEnumerable<ProductDto>>(map).ToPagination(productsPage);
        }
    }
}
