using Volo.Abp.Domain;
using Volo.Abp.Modularity;
using Volo.Abp.EventBus.RabbitMq;

namespace ModularCrm.Products;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(ProductsDomainSharedModule)
)]
[DependsOn(typeof(AbpEventBusRabbitMqModule))]
    public class ProductsDomainModule : AbpModule
{

}
