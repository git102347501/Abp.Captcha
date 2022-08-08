using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MagicalConch.Abp.Captcha.UserAction.Providers
{
    public class DeviceAppraiseProvider : IDeviceAppraiseProvider
    {
        public Task<int> GetGrade(Guid userId, string deviceName)
        {
            throw new NotImplementedException();
        }
    }
}
