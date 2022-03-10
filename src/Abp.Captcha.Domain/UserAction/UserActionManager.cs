using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MagicalConch.Abp.Captcha.UserAction
{
    /// <summary>
    /// 用户行为领域服务
    /// </summary>
    public class UserActionManager : IUserActionManager
    {
        private readonly IDeviceAppraiseProvider _deviceAppraiseProvider;
        private readonly IIPAppraiseProvider _ipAppraiseProvider;

        public UserActionManager(IDeviceAppraiseProvider deviceAppraiseProvider, IIPAppraiseProvider ipAppraiseProvider)
        {
            _deviceAppraiseProvider = deviceAppraiseProvider;
            _ipAppraiseProvider = ipAppraiseProvider;
        }

        public async Task<UserActionAppraise> GetAppraise()
        {
            var deviceGrade = await _deviceAppraiseProvider.GetGrade();
            var ipGrade = await _ipAppraiseProvider.GetGrade();

            return new UserActionAppraise(){ 
            
            };
        }
    }
}
