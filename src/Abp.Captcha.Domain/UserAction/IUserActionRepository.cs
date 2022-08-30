using MaigcalConch.Abp.Captcha.UserAction;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace MagicalConch.Abp.Captcha.UserAction
{
    public interface IUserActionRepository : IRepository<UserActionMaster>
    {
        public Task<int> GetForDeviceListAsync(Guid? userId, string deviceName);

        public Task<int> GetForIpListAsync(Guid? userId, string ip);
    }
}
