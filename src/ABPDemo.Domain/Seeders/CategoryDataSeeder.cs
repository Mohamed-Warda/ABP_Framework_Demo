using System.Collections.Generic;
using System.Threading.Tasks;
using ABPDemo.Categories;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace ABPDemo.Seeders;

// 'IDataSeedContributor' is an interface used for seeding data into the database.
// Running the DB Migrator project will trigger the execution of this seed method.
public class CategoryDataSeeder : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<Category, int> categoriesRepository;

    public CategoryDataSeeder(IRepository<Category, int> categoriesRepository)
    {
        this.categoriesRepository = categoriesRepository;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        // Insert seed data only when the table has no existing records
        if (!await categoriesRepository.AnyAsync())
        {
            var categories = new List<Category>
            {
                new(1,
                    "أطعمة ومشروبات",
                    "Food & Drinks",
                    "جميع أنواع الأطعمة والمشروبات",
                    "All food and drink categories"),
                new(2,
                    "مواد تنظيف",
                    "Detergents",
                    "المنظفات بأنواعها",
                    "all materials used for cleaning"),
                new(3,
                    "عطور",
                    "Fragrances",
                    "العطور بأنواعها",
                    "all perfumes and its sub-categories"),
                new(4,
                    "بلاستيك",
                    "Plastic",
                    "البلاستيك القابل للتدوير والغير قابل للتدوير",
                    "all reusable and non-reusable plastic materials")
            };

            await categoriesRepository.InsertManyAsync(categories);
        }
    }
}