using Microsoft.Extensions.DependencyInjection;
using Abp.Captcha.Blazor.Menus;
using Volo.Abp.AspNetCore.Components.WebAssembly.Theming.Routing;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;

namespace Abp.Captcha.Blazor
{
    [DependsOn(
        typeof(CaptchaHttpApiClientModule),
        typeof(AbpAutoMapperModule)
        )]
    public class CaptchaBlazorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<CaptchaBlazorModule>();

            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<CaptchaBlazorAutoMapperProfile>(validate: true);
            });

            Configure<AbpNavigationOptions>(options =>
            {
                options.MenuContributors.Add(new CaptchaMenuContributor());
            });

            Configure<AbpRouterOptions>(options =>
            {
                options.AdditionalAssemblies.Add(typeof(CaptchaBlazorModule).Assembly);
            });
        }
    }
}