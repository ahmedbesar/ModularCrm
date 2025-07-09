using System.Threading.Tasks;
using Shouldly;
using Volo.Abp.Modularity;
using Xunit;

namespace ModularCrm.Products.Samples;

public abstract class SampleAppService_Tests<TStartupModule> : ProductsApplicationTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{
    
}
