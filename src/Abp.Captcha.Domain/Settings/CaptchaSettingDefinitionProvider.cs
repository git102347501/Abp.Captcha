using Volo.Abp.Settings;

namespace MaigcalConch.Abp.Captcha.Settings
{
    public class CaptchaSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            context.Add(
                new SettingDefinition(CaptchaSettings.IpTime, "10"),
                new SettingDefinition(CaptchaSettings.IpCount, "3")
            );
        }
    }
}