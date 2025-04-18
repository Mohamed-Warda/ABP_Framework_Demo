using ABPDemo.Categories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace ABPDemo.Configurations;
// 'IEntityTypeConfiguration' is an EF Core-related interface, not specific to ABP
internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        // 'ConfigureByConvention' is an ABP-specific method
        // It configures the properties inherited from ABP base classes
        builder.ConfigureByConvention();
        
        // To disable identity (auto-increment) for the Id column
        builder.Property(x => x.Id).ValueGeneratedNever();

        builder.Property(x => x.NameAr).HasMaxLength(ABPDemoConsts.GeneralTextMaxLength).IsRequired();
        builder.Property(x => x.NameEn).HasMaxLength(ABPDemoConsts.GeneralTextMaxLength).IsRequired();
        builder.Property(x => x.DescriptionAr).HasMaxLength(ABPDemoConsts.DescriptionTextMaxLength).IsRequired();
        builder.Property(x => x.DescriptionEn).HasMaxLength(ABPDemoConsts.DescriptionTextMaxLength).IsRequired();

        // You can specify the schema name
        builder.ToTable("Categories", "LookUp");

    }
}