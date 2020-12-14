using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Abp.Captcha.MongoDB
{
    [ConnectionStringName(CaptchaDbProperties.ConnectionStringName)]
    public interface ICaptchaMongoDbContext : IAbpMongoDbContext
    {
        /* Define mongo collections here. Example:
         * IMongoCollection<Question> Questions { get; }
         */
    }
}
