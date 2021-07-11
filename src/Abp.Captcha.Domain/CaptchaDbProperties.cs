namespace MaigcalConch.Abp.Captcha
{
    public static class CaptchaDbProperties
    {
        public static string DbTablePrefix { get; set; } = "Captcha";

        public static string DbSchema { get; set; } = null;

        public const string ConnectionStringName = "Captcha";
    }
}
