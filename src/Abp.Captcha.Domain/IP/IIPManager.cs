using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace MagicalConch.Abp.Captcha.IP
{
    public interface IIPManager : IDomainService
    {
        Task AddAsync(string ip, IPTypeEnum type, IPCategoryEnum category);
    }
}
