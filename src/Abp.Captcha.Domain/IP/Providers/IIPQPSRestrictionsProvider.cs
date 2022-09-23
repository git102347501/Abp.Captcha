using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MagicalConch.Abp.Captcha.IP.Providers
{
    public interface IIPQPSRestrictionsProvider
    {
        Task<bool> ValidationAsync(string ip, int time, int count);
    }
}
