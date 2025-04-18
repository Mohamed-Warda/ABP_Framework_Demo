using ABPDemo.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace ABPDemo.Configurations;

// 'IEntityTypeConfiguration' is an EF Core-related interface, not specific to ABP
internal class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        // 'ConfigureByConvention' is an ABP-specific method
        // It configures the properties inherited from ABP base classes
        builder.ConfigureByConvention();

        builder.Property(x => x.NameAr).HasMaxLength(ABPDemoConsts.GeneralTextMaxLength).IsRequired();
        builder.Property(x => x.NameEn).HasMaxLength(ABPDemoConsts.GeneralTextMaxLength).IsRequired();
        builder.Property(x => x.DescriptionAr).HasMaxLength(ABPDemoConsts.DescriptionTextMaxLength).IsRequired();
        builder.Property(x => x.DescriptionEn).HasMaxLength(ABPDemoConsts.DescriptionTextMaxLength).IsRequired();

        // Table relationships
        builder.HasOne(x => x.Category)
            .WithMany()
            .HasForeignKey(x => x.CategoryId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        builder.ToTable("Products");
    }
}
