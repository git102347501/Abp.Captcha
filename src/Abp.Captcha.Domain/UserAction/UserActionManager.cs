using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MagicalConch.Abp.Captcha.UserAction
{
    /// <summary>
    /// user action domain service
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

        /// <summary>
        /// get user action appraise
        /// </summary>
        /// <returns></returns>
        private async Task<UserActionAppraise> GetAppraise()
        {
            var deviceGrade = await _deviceAppraiseProvider.GetGrade();
            var ipGrade = await _ipAppraiseProvider.GetGrade();

            return new UserActionAppraise(){ 
                DeviceGrade = deviceGrade,
                IPGrade = ipGrade
            };
        }

        public async Task<UserActionVerificationModel> GetVerificationModeAsync(object input)
        {
            var data = this.GetAppraise(input);
        }
    }
}
