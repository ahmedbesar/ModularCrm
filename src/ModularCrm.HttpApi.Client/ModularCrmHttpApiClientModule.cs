using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Account;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.TenantManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.VirtualFileSystem;
using ModularCrm.Products;
using ModularCrm.Ordering;

namespace ModularCrm;

[DependsOn(
    typeof(ModularCrmApplicationContractsModule),
    typeof(AbpAccountHttpApiClientModule),
    typeof(AbpIdentityHttpApiClientModule),
    typeof(AbpPermissionManagementHttpApiClientModule),
    typeof(AbpTenantManagementHttpApiClientModule),
    typeof(AbpFeatureManagementHttpApiClientModule),
    typeof(AbpSettingManagementHttpApiClientModule)
)]
[DependsOn(typeof(ProductsHttpApiClientModule))]
    [DependsOn(typeof(OrderingHttpApiClientModule))]
    public class ModularCrmHttpApiClientModule : AbpModule
{
    public const string RemoteServiceName = "Default";

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(ModularCrmApplicationContractsModule).Assembly,
            RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<ModularCrmHttpApiClientModule>();
        });
    }
}
