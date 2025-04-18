using ABPDemo.Categories.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace ABPDemo.Categories.Contracts;

// 'ICrudAppService' is a built-in ABP base Interface that provides standard CRUD operations
public interface ICategoriesAppService : ICrudAppService<
    CategoryDto,                    // The DTO used to return category data to the client
    int,                            // The type of the primary key (ID) of the Category entity
    PagedAndSortedResultRequestDto, // Used to request paged and sorted lists of categories
    CreateUpdateCategoryDto>         // The DTO used to create or update a category
{
}