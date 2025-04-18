using ABPDemo.Products;
using ABPDemo.Products.Dtos;
using AutoMapper;

namespace ABPDemo.Mappings;

public class ProductMappingProfile:Profile
{
    public ProductMappingProfile()
    {
        CreateMap<CreateUpdateProductDto, Product>();
        CreateMap<Product, ProductDto>();
    }
}