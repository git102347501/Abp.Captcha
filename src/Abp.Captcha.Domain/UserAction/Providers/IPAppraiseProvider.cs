using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace MagicalConch.Abp.Captcha.UserAction.Providers
{
    /// <summary>
    /// IP安全模型评估
    /// </summary>
    public class IPAppraiseProvider : IIPAppraiseProvider, ITransientDependency
    {
        private readonly int basicGrade = 59;
        private readonly IUserActionRepository _userActionRepository;

        public IPAppraiseProvider(IUserActionRepository userActionRepository)
        {
            _userActionRepository = userActionRepository;
        }

        public async Task<int> GetGrade(Guid? userId, string ip)
        {
            if (string.IsNullOrWhiteSpace(ip) || !userId.HasValue)
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
