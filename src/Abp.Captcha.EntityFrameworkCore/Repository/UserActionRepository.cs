using MagicalConch.Abp.Captcha.UserAction;
using MaigcalConch.Abp.Captcha.EntityFrameworkCore;
using MaigcalConch.Abp.Captcha.UserAction;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace MagicalConch.Abp.Captcha.Repository
{
    public class UserActionRepository : EfCoreRepository<CaptchaDbContext, UserActionMaster, Guid>, IUserActionRepository
    {
        public UserActionRepository(IDbContextProvider<CaptchaDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<int> GetForDeviceListAsync(Guid? userId, string deviceName)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetForIpListAsync(Guid? userId, string ip)
        {
            throw new NotImplementedException();
        }
    }
}
