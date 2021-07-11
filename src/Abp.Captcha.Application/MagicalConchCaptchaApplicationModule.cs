using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.Application;

namespace MaigcalConch.Abp.Captcha
{
    [DependsOn(
        typeof(MagicalConchCaptchaDomainModule),
        typeof(MagicalConchCaptchaApplicationContractsModule),
        typeof(AbpDddApplicationModule),
        typeof(AbpAutoMapperModule)
        )]
    public class MagicalConchCaptchaApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<MagicalConchCaptchaApplicationModule>();
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<MagicalConchCaptchaApplicationModule>(validate: true);
            });
        }
    }
}
