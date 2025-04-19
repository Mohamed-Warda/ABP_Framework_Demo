using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;

namespace ABPDemo.Categories.Dtos;

// Explore other base Dto entity types such as EntityDto<>, FullAuditedEntityDto<>, AuditedEntityDto<>, etc., to determine which best fits your needs.
public class CreateUpdateCategoryDto : EntityDto<int>
{
    [Required]
    [MaxLength(300)] 
    public string NameAr { get; set; }

    [Required]
    [MaxLength(300)]
    public string NameEn { get; set; }

    [Required]
    [MaxLength(1000)]
    public string DescriptionAr { get; set; }

    [Required]
    [MaxLength(1000)]
    public string DescriptionEn { get; set; }
}