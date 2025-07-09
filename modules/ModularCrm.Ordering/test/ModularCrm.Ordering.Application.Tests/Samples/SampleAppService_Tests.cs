using System.Threading.Tasks;
using Shouldly;
using Volo.Abp.Modularity;
using Xunit;

namespace ModularCrm.Ordering.Samples;

public abstract class SampleAppService_Tests<TStartupModule> : OrderingApplicationTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

    protected SampleAppService_Tests()
    {
    }
}
