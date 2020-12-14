using Volo.Abp.Reflection;

namespace Abp.Captcha.Permissions
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