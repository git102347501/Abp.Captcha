using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace MaigcalConch.Abp.Captcha
{
    [DependsOn(
        typeof(MagicalConchCaptchaApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class MagicalConchCaptchaHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "Captcha";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(MagicalConchCaptchaApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
