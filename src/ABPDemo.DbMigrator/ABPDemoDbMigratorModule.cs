using ABPDemo.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace ABPDemo.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(ABPDemoEntityFrameworkCoreModule),
    typeof(ABPDemoApplicationContractsModule)
)]
public class ABPDemoDbMigratorModule : AbpModule
{
}
