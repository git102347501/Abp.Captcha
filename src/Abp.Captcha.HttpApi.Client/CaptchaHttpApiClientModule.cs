using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace Abp.Captcha
{
    [DependsOn(
        typeof(CaptchaApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class CaptchaHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "Captcha";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(CaptchaApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
