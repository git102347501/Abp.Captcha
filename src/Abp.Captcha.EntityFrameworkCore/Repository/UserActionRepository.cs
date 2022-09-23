using MagicalConch.Abp.Captcha.UserAction;
using MaigcalConch.Abp.Captcha.EntityFrameworkCore;
using MaigcalConch.Abp.Captcha.UserAction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace MagicalConch.Abp.Captcha.Repository
{
    public class UserActionRepository : EfCoreRepository<CaptchaDbContext, UserActionMaster, int>, IUserActionRepository
    {
        public UserActionRepository(IDbContextProvider<CaptchaDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<int> GetForDeviceListAsync(string deviceName, Guid? userId = null)
        {
            var dbContext = await GetDbContextAsync();
            return dbContext.Set<UserActionMaster>()
                .WhereIf(userId.HasValue, c => c.UserId == userId)
                .Where(c=> c.Device == deviceName)
                .Count();
        }

        public async Task<int> GetForIpListAsync(string ipv4, Guid? userId = null)
        {
            var dbContext = await GetDbContextAsync();
            return dbContext.Set<UserActionMaster>()
               .WhereIf(userId.HasValue, c => c.UserId == userId)
               .Where(c => c.Ipv4 == ipv4)
               .Count();
        }
    }
}
