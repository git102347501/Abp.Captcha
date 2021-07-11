using MaigcalConch.Abp.Captcha.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace MaigcalConch.Abp.Captcha.Permissions
{
    public class CaptchaPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(CaptchaPermissions.GroupName, L("Permission:Captcha"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<CaptchaResource>(name);
        }
    }
}