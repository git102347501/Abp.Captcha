namespace MaigcalConch.Abp.Captcha.Settings
{
    public static class CaptchaSettings
    {
        public const string GroupName = "Captcha";

        /* Add constants for setting names. Example:
         * public const string MySettingName = GroupName + ".MySettingName";
         */
        public const string IpGroup = GroupName + ".Ip";
        public const string IpTime = IpGroup + ".Time";
        public const string IpCount = IpGroup + ".Count";
    }
}