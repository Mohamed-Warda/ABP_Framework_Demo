using Volo.Abp;

namespace ABPDemo.Products.DomainExceptions;

// 'BusinessException' is an ABP class that helps create domain-specific exceptions
public class ProductNotFoundException: BusinessException
{
    public ProductNotFoundException(int id) : base(ABPDemoDomainErrorCodes.PRODUCT_NOT_FOUND)
    {
        WithData("id", id);        
    }
}