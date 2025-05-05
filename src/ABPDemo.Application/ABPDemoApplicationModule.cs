using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.Account;
using Volo.Abp.Identity;
using Volo.Abp.AutoMapper;
using Volo.Abp.FeatureManagement;
using Volo.Abp.FluentValidation;
using Volo.Abp.Modularity;
using Volo.Abp.Caching.StackExchangeRedis;
using System;
using Volo.Abp.Caching;

namespace ABPDemo;

[DependsOn(
    typeof(ABPDemoDomainModule),
    typeof(ABPDemoApplicationContractsModule),
    typeof(AbpPermissionManagementApplicationModule),
    typeof(AbpFeatureManagementApplicationModule),
    typeof(AbpIdentityApplicationModule),
    typeof(AbpAccountApplicationModule),
    typeof(AbpSettingManagementApplicationModule),
    typeof(AbpFluentValidationModule),
    typeof(AbpCachingStackExchangeRedisModule)
    )]
public class ABPDemoApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<ABPDemoApplicationModule>();
        });
        Configure<AbpDistributedCacheOptions>(options =>
        {
            options.KeyPrefix = "Demo1_";
            options.GlobalCacheEntryOptions.AbsoluteExpiration = DateTimeOffset.Now.AddHours(1);
        });
    }
}

