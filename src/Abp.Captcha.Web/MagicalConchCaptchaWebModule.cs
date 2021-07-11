using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;
using MaigcalConch.Abp.Captcha.Localization;
using MaigcalConch.Abp.Captcha.Web.Menus;
using Volo.Abp.AspNetCore.Mvc.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;
using Volo.Abp.VirtualFileSystem;
using MaigcalConch.Abp.Captcha.Permissions;

namespace MaigcalConch.Abp.Captcha.Web
{
    [DependsOn(
        typeof(MagicalConchCaptchaHttpApiModule),
        typeof(AbpAspNetCoreMvcUiThemeSharedModule),
        typeof(AbpAutoMapperModule)
        )]
    public class MagicalConchCaptchaWebModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.PreConfigure<AbpMvcDataAnnotationsLocalizationOptions>(options =>
            {
                options.AddAssemblyResource(typeof(CaptchaResource), typeof(MagicalConchCaptchaWebModule).Assembly);
            });

            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(MagicalConchCaptchaWebModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpNavigationOptions>(options =>
            {
                options.MenuContributors.Add(new CaptchaMenuContributor());
            });

            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<MagicalConchCaptchaWebModule>();
            });

            context.Services.AddAutoMapperObjectMapper<MagicalConchCaptchaWebModule>();
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<MagicalConchCaptchaWebModule>(validate: true);
            });

            Configure<RazorPagesOptions>(options =>
            {
                //Configure authorization.
            });
        }
    }
}
