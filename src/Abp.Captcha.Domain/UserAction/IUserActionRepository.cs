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
        public Task<int> GetForDeviceListAsync(string deviceName, Guid? userId = null);

        public Task<int> GetForIpListAsync(string ip, Guid? userId = null);
    }
}
