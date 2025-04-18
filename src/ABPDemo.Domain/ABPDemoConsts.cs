using Volo.Abp.Identity;

namespace ABPDemo;

// A common place to store project-wide constants
public static class ABPDemoConsts
{
    public const int GeneralTextMaxLength = 300;
    public const int DescriptionTextMaxLength = 1000;
    public const string DbTablePrefix = "App";
    public const string? DbSchema = null;
    public const string AdminEmailDefaultValue = IdentityDataSeedContributor.AdminEmailDefaultValue;
    public const string AdminPasswordDefaultValue = IdentityDataSeedContributor.AdminPasswordDefaultValue;
}
