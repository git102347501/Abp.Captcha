using Localization.Resources.AbpUi;
using MaigcalConch.Abp.Captcha.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace MaigcalConch.Abp.Captcha
{
    [DependsOn(
        typeof(MagicalConchCaptchaApplicationContractsModule),
        typeof(AbpAspNetCoreMvcModule))]
    public class MagicalConchCaptchaHttpApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(MagicalConchCaptchaHttpApiModule).Assembly);
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
