using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MagicalConch.Abp.Captcha.UserAction.Providers
{
    public class IPAppraiseProvider : IIPAppraiseProvider
    {
        private readonly int basicGrade = 59;
        private readonly IUserActionRepository _userActionRepository;

        public IPAppraiseProvider(IUserActionRepository userActionRepository)
        {
            _userActionRepository = userActionRepository;
        }

        public async Task<int> GetGrade(Guid? userId, string ip)
        {
            if (string.IsNullOrWhiteSpace(ip))
            {
                return 0;
            }
            var count = await _userActionRepository.GetForIpListAsync(ip, userId);
            if (count < 1)
            {
                return basicGrade;
            }

            var num = count + basicGrade;
            if (num > 100)
            {
                return 100;
            }
            else
            {
                return num;
            }
        }
    }
}
