using System.Collections.Generic;
using SIENN.Services.DTO;

namespace SIENN.Services.IServices
{
    public interface IProductService : IBaseCRUDService<ProductDto>
    {
        PagingDto<ProductDto> GetAvailableProducts(PagingRequestDto request);

        IEnumerable<ProductDto> GetProducts(ProductFilterDto filters);

        PagingDto<ProductCustomViewDto> GetProductCustomViews(PagingRequestDto request);
    }
}
