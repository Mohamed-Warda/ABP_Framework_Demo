using ABPDemo.Categories;
using ABPDemo.Categories.Dtos;
using AutoMapper;

namespace ABPDemo.Mappings;

public class CategoryMappingProfile:Profile
{
    public CategoryMappingProfile()
    {
        CreateMap<Category, CategoryDto>();
        CreateMap<CreateUpdateCategoryDto, Category>();

    }
}