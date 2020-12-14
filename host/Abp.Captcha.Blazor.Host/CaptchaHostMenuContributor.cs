using System.Threading.Tasks;
using Abp.Captcha.Localization;
using Volo.Abp.UI.Navigation;

namespace Abp.Captcha.Blazor.Host
{
    public class CaptchaHostMenuContributor : IMenuContributor
    {
        public Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if(context.Menu.DisplayName != StandardMenus.Main)
            {
                return Task.CompletedTask;
            }

            var l = context.GetLocalizer<CaptchaResource>();

            context.Menu.Items.Insert(
                0,
                new ApplicationMenuItem(
                    "Captcha.Home",
                    l["Menu:Home"],
                    "/",
                    icon: "fas fa-home"
                )
            );

            return Task.CompletedTask;
        }
    }
}
