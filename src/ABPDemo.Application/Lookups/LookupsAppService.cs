using ABPDemo.Bases;
using ABPDemo.Categories.Dtos;
using ABPDemo.Categories;
using AutoMapper.Internal.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Caching;
using Volo.Abp.Domain.Repositories;

namespace ABPDemo.Lookups;
public class LookupsAppService : BaseApplicationService
{
    #region fields
    private readonly IRepository<Category, int> categoryRepository;
    private readonly IDistributedCache<List<CategoryDto>> categoryCache;
    #endregion

    #region ctor
    public LookupsAppService(
        IRepository<Category, int> categoryRepository,
        IDistributedCache<List<CategoryDto>> categoryCache)
    {
        this.categoryRepository = categoryRepository;
        this.categoryCache = categoryCache;
    }
    #endregion

    #region methods
    public async Task<List<CategoryDto>> GetCategories()
    {
        return await GetAllCategoriesFromDbAsync();
       
    }
    #endregion

    #region private methods
    private async Task<List<CategoryDto>> GetAllCategoriesFromDbAsync()
    {
        var categories = await categoryRepository.GetListAsync();
        return ObjectMapper.Map<List<Category>, List<CategoryDto>>(categories);
    }
    #endregion
}