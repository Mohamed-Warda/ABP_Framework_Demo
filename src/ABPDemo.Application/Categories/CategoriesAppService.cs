using ABPDemo.Categories.Contracts;
using ABPDemo.Categories.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace ABPDemo.Categories;

// 'CrudAppService' is a built-in ABP base class that provides standard CRUD operations
public class CategoriesAppService :
    CrudAppService<Category,               // The Entity type
        CategoryDto,            // The DTO used to return data
        int,                    // The type of the primary key
        PagedAndSortedResultRequestDto, // Used for pagination and sorting
        CreateUpdateCategoryDto>,       // The DTO used to create or update a category
    ICategoriesAppService                  // Interface this service implements
{
    public CategoriesAppService(IRepository<Category, int> repository)
        : base(repository)
    {
    }
}