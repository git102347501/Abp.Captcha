using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace MagicalConch.Abp.Captcha.IpAction
{
    public interface IIpActionAppService : IApplicationService
    {
        Task ValidationAsync(string ip);

        Task AddAsync(string ip);
    }
}
