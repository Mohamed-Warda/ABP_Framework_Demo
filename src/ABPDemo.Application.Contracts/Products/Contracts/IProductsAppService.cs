using System.Threading.Tasks;
using ABPDemo.Products.Dtos;
using Volo.Abp.Application.Dtos;

namespace ABPDemo.Products.Contracts;

public interface IProductsAppService
{
    Task<ProductDto> CreateProductAsync(CreateUpdateProductDto input);
    Task<ProductDto> UpdateProductAsync(CreateUpdateProductDto input);
    Task<ProductDto> GetProductAsync(int id);
    Task<PagedResultDto<ProductDto>> GetListAsync(GetProductListDto input);
    Task<bool> DeleteProductAsync(int id);
}