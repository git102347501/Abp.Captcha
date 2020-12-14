using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Abp.Captcha.EntityFrameworkCore
{
    [ConnectionStringName(CaptchaDbProperties.ConnectionStringName)]
    public interface ICaptchaDbContext : IEfCoreDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */
    }
}