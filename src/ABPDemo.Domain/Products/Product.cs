using ABPDemo.Categories;
using Volo.Abp.Domain.Entities.Auditing;

namespace ABPDemo.Products;

// Explore other base entity types such as Entity<>, FullAuditedEntity<>, AuditedEntity<>, etc., to determine which best fits your needs.
public class Product : FullAuditedEntity<int>
{
    public string NameAr { get; set; }
    public string NameEn { get; set; }
    public string DescriptionAr { get; set; }
    public string DescriptionEn { get; set; }
    public int CategoryId { get; set; }
    public virtual Category Category { get; set; }
}