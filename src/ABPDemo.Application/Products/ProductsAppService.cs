using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using ABPDemo.Bases;
using ABPDemo.Products.Contracts;
using ABPDemo.Products.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using ABPDemo.Products.DomainExceptions;
using ABPDemo.Products.Validators;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using ABPDemo.Permissions;
using static ABPDemo.Permissions.ABPDemoPermissions;
using Volo.Abp.Authorization;

namespace ABPDemo.Products;


    public class ProductsAppService : BaseApplicationService, IProductsAppService
    {
        #region fields
        private readonly IRepository<Product, int> productsRepository; 
        #endregion

        #region constructor
        public ProductsAppService(IRepository<Product, int> productsRepository)
        {
            this.productsRepository = productsRepository;
        }
    #endregion constructor

    #region IProductsAppService
     [Authorize(ProductPermissions.CreateEditProductPermission)]
    public async Task<ProductDto> CreateProductAsync(CreateUpdateProductDto input)
        {
            //validation
            var validateResult = new CreateUpdateProductValidator().Validate(input);
            if(!validateResult.IsValid)
            {
                var exception = GetValidationException(validateResult);
                throw exception;
            }

            var product = ObjectMapper.Map<CreateUpdateProductDto, Product>(input);
            var inserted = await productsRepository.InsertAsync(product, autoSave: true);
            return ObjectMapper.Map<Product, ProductDto>(inserted);
        }

    [Authorize(ProductPermissions.CreateEditProductPermission)]
    public async Task<ProductDto> UpdateProductAsync(CreateUpdateProductDto input)
        {
            //validation
            var validateResult = new CreateUpdateProductValidator().Validate(input);
            if (!validateResult.IsValid)
            {
                var exception = GetValidationException(validateResult);
                throw exception;
            }

            var existing = await productsRepository.GetAsync(input.Id);
            if (existing == null) 
            {
                throw new ProductNotFoundException(input.Id);
            }
            var mapped= ObjectMapper.Map<CreateUpdateProductDto, Product>(input, existing);
            var updated = await productsRepository.UpdateAsync(mapped, autoSave: true);
            return ObjectMapper.Map<Product, ProductDto>(updated);
        }

    [Authorize(ProductPermissions.DeleteProductPermission)]

    public async Task<bool> DeleteProductAsync(int id)
        {
            var existingProduct = await productsRepository.GetAsync(id);
            if(existingProduct == null)
            {
                throw new ProductNotFoundException(id);
            }

            await productsRepository.DeleteAsync(existingProduct);
            return true;
        }


    [Authorize(ProductPermissions.GetProductPermission)]
    public async Task<PagedResultDto<ProductDto>> GetListAsync(GetProductListDto input)
        {
            if (input.Sorting.IsNullOrWhiteSpace())
            {
                input.Sorting = nameof(Product.Id);
            }

            var products = await productsRepository
                .WithDetailsAsync(product => product.Category)
                .Result
                .AsQueryable()
                .WhereIf(
                    !input.Filter.IsNullOrWhiteSpace(),
                    product => product.NameAr.Contains(input.Filter) ||
                               product.NameEn.Contains(input.Filter)
                )
                .WhereIf(
                    input.CategoryId.HasValue,
                    product => product.CategoryId == input.CategoryId
                )
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount)
                // 'OrderBy' is from the 'System.Linq.Dynamic.Core' namespace
                .OrderBy(input.Sorting)
                // Requires installing the 'Microsoft.EntityFrameworkCore' package to use 'ToListAsync'
                .ToListAsync();
            
            var totalCount = input.Filter == null
                ? await productsRepository.CountAsync()
                : await productsRepository.CountAsync(product => product.NameAr.Contains(input.Filter) ||
                                                                 product.NameEn.Contains(input.Filter));

            return new PagedResultDto<ProductDto>(
                totalCount,
                ObjectMapper.Map<List<Product>, List<ProductDto>>(products)
            );
        }

    [Authorize(ProductPermissions.GetProductPermission)]
    public async Task<ProductDto> GetProductAsync(int id)
        {
            var product = await productsRepository
                           .WithDetailsAsync(x => x.Category)
                           .Result
                           .FirstOrDefaultAsync(x => x.Id == id);

            if (product == null)
            {
                throw new ProductNotFoundException(id);
            }
            return ObjectMapper.Map<Product, ProductDto>(product);
        }



    // you dont need to  be loged in to call this action
    [AllowAnonymous]
    public Task<bool> LabTestProductAsync(int id)
    {
        //call lab test service

        return Task.FromResult(true);
    }

    //how to check if the user has permission
    public async Task<bool> TestComplexPermissions()
    {
        var result = await AuthorizationService.AuthorizeAsync(ProductPermissions.CreateEditProductPermission);
        if (result.Succeeded == false)
        {
            //throw exception
            throw new AbpAuthorizationException("You don't have permission for this action");
        }

        return true;
    }
    #endregion IProductsAppService


}



