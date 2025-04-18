using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace ABPDemo.Categories;

// Explore other base entity types such as Entity<>, FullAuditedEntity<>, AuditedEntity<>, etc., to determine which best fits your needs.
public class Category: FullAuditedEntity<int>
{
    public string NameAr { get; set; }
    public string NameEn { get; set; }
    public string DescriptionAr { get; set; }
    public string DescriptionEn { get; set; }
    
    public Category(int id, string nameAr, string nameEn, string descriptionAr, string descriptionEn) : base(id)
    {
        Id = id;
        NameAr = nameAr;
        NameEn = nameEn;
        DescriptionAr = descriptionAr;
        DescriptionEn = descriptionEn;
    }
}