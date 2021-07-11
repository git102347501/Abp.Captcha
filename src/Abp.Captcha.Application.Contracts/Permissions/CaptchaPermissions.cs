using Volo.Abp.Reflection;

namespace MaigcalConch.Abp.Captcha.Permissions
{
    public class CaptchaPermissions
    {
        public const string GroupName = "Captcha";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(CaptchaPermissions));
        }
    }
}