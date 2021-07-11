using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace MaigcalConch.Abp.Captcha.EntityFrameworkCore
{
    [ConnectionStringName(CaptchaDbProperties.ConnectionStringName)]
    public class CaptchaDbContext : AbpDbContext<CaptchaDbContext>, ICaptchaDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * public DbSet<Question> Questions { get; set; }
         */

        public CaptchaDbContext(DbContextOptions<CaptchaDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureCaptcha();
        }
    }
}