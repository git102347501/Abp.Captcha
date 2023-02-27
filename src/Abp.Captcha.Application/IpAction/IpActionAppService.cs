using MagicalConch.Abp.Captcha.IP;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MagicalConch.Abp.Captcha.IpAction
{
    public class IpActionAppService : IIpActionAppService
    {
        private readonly IPManager _ipManager;

        public IpActionAppService(IPManager ipManager)
        {
            _ipManager = ipManager;
        }

        public async Task AddAsync(string ip)
        {
            await _ipManager.AddAsync(ip);
        }

        public async Task ValidationAsync(string ip)
        {
            await _ipManager.ValidationAsync(ip);
        }
    }
}
