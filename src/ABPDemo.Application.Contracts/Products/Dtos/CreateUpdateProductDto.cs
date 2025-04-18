﻿using Volo.Abp.Application.Dtos;

namespace ABPDemo.Products.Dtos;


// Explore other base Dto entity types such as EntityDto<>, FullAuditedEntityDto<>, AuditedEntityDto<>, etc., to determine which best fits your needs.
public class CreateUpdateProductDto : EntityDto<int>
{
    public string NameAr { get; set; }
    public string NameEn { get; set; }
    public string DescriptionAr { get; set; }
    public string DescriptionEn { get; set; }
    public int CategoryId { get; set; }
}