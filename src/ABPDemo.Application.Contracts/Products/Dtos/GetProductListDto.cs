using Volo.Abp.Application.Dtos;

namespace ABPDemo.Products.Dtos;

// Explore other base Dto entity types such as EntityDto<>, FullAuditedEntityDto<>, AuditedEntityDto<>, etc., to determine which best fits your needs.
public class GetProductListDto : PagedAndSortedResultRequestDto
{
    public string Filter { get; set; }
    public int? CategoryId { get; set; }
}