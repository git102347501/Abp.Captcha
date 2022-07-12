using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MagicalConch.Abp.Captcha.UserAction.Providers
{
    public class IPAppraiseProvider : IIPAppraiseProvider
    {
        public Task<int> GetGrade()
        {
            throw new NotImplementedException();
        }
    }
}
