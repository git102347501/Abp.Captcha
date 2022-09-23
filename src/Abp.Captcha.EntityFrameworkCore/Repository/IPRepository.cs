using MagicalConch.Abp.Captcha.IP;
using MagicalConch.Abp.Captcha.UserAction;
using MaigcalConch.Abp.Captcha.EntityFrameworkCore;
using MaigcalConch.Abp.Captcha.UserAction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace MagicalConch.Abp.Captcha.Repository
{
    public class IPRepository : EfCoreRepository<CaptchaDbContext, IPMaster, int>, IIPRepository
    {
        public IPRepository(IDbContextProvider<CaptchaDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
