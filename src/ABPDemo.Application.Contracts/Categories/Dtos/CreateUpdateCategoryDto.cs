using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;

namespace ABPDemo.Categories.Dtos;

// Explore other base Dto entity types such as EntityDto<>, FullAuditedEntityDto<>, AuditedEntityDto<>, etc., to determine which best fits your needs.
public class CreateUpdateCategoryDto : EntityDto<int>
{
    public string NameAr { get; set; }
    public string NameEn { get; set; }
    public string DescriptionAr { get; set; }
    public string DescriptionEn { get; set; }
}