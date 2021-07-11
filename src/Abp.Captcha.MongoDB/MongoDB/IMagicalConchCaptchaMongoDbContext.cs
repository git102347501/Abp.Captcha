using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace MaigcalConch.Abp.Captcha.MongoDB
{
    [ConnectionStringName(CaptchaDbProperties.ConnectionStringName)]
    public interface IMagicalConchCaptchaMongoDbContext : IAbpMongoDbContext
    {
        /* Define mongo collections here. Example:
         * IMongoCollection<Question> Questions { get; }
         */
    }
}
