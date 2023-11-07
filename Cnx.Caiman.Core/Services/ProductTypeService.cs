using AutoMapper;
using Cnx.Caiman.Core.DTOs.ProductType;
using Cnx.Caiman.Core.Entities;
using Cnx.Caiman.Core.Interfaces;
using Cnx.Caiman.Core.Interfaces.Services;
using Cemex.Core.Entities;
using Cemex.Core.Entities.Filters;
using Cemex.Core.Extension;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cnx.Caiman.Core.Services
{
    public class ProductTypeService: IProductTypeService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly PaginationConfiguration paginationConfiguration;
        private readonly IMapper mapper;
        public ProductTypeService(IUnitOfWork unitOfWork, IOptions<PaginationConfiguration> options, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.paginationConfiguration = options.Value;
            this.mapper = mapper;
        }

        public async Task<ApiResponse<IEnumerable<ProductTypeDto>>> GetAsync(int idZona, PaginationQuery filter)
        {

            filter.PageNumber = filter.PageNumber == 0 ? this.paginationConfiguration.DefaultPageNumber : filter.PageNumber;
            filter.PageSize = filter.PageSize == 0 ? this.paginationConfiguration.DefaultPageSize : filter.PageSize;
            var products = await this.unitOfWork.ProductTypeRepository.GetAsync(idZona);
            var productsPage = PageList<TipoProducto>.Create(products, filter.PageNumber, filter.PageSize);
            var map = this.mapper.Map<IEnumerable<ProductTypeDto>>(productsPage);
            return new ApiResponse<IEnumerable<ProductTypeDto>>(map).ToPagination(productsPage);
        }

        public async Task UpdateAsync(ProductTypeUpdateDto model)
        {
            await this.unitOfWork.ProductTypeRepository.UpdateAsync(model);
        }

        public async Task InsertAsync(ProductTypeInsertDto model)
        {
            await this.unitOfWork.ProductTypeRepository.InsertAsync(model);
        }
        public async Task DeleteAsync(int idTipoProducto, string Vc20Usuario)
        {
            await this.unitOfWork.ProductTypeRepository.DeleteAsync(idTipoProducto, Vc20Usuario);
        }
    }
}
