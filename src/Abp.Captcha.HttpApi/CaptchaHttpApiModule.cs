using Localization.Resources.AbpUi;
using Abp.Captcha.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Abp.Captcha
{
    [DependsOn(
        typeof(CaptchaApplicationContractsModule),
        typeof(AbpAspNetCoreMvcModule))]
    public class CaptchaHttpApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(CaptchaHttpApiModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<CaptchaResource>()
                    .AddBaseTypes(typeof(AbpUiResource));
            });
        }
    }
}
