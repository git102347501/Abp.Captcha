using MaigcalConch.Abp.Captcha.Slider;
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
        private readonly ISilderManager _silderManager;

        public UserActionManager(IDeviceAppraiseProvider deviceAppraiseProvider, IIPAppraiseProvider ipAppraiseProvider, ISilderManager silderManager)
        {
            _deviceAppraiseProvider = deviceAppraiseProvider;
            _ipAppraiseProvider = ipAppraiseProvider;
            _silderManager = silderManager;
        }

        /// <summary>
        /// get user action appraise
        /// </summary>
        /// <returns></returns>
        private async Task<UserActionAppraise> GetAppraise(Guid userId, string ip, string device)
        {
            var deviceGrade = await _deviceAppraiseProvider.GetGrade(userId, device);
            var ipGrade = await _ipAppraiseProvider.GetGrade(userId, ip);

            return new UserActionAppraise(){ 
                DeviceGrade = deviceGrade,
                IPGrade = ipGrade
            };
        }

        public async Task<UserActionVerificationModel> GetVerificationModeAsync(Guid userId, ValidationModel<string> input)
        {
            var data = await this.GetAppraise(userId, input.ActionData.Ip, input.ActionData.Device);
            if (data.AverageGrade <= 60)
            {
                // 严格策略-拼图
                return new UserActionVerificationModel()
                {
                    Type = UserActionVerificationTypeEnum.VerifyPicture,
                    Data = ""
                };
            } 
            else if (data.AverageGrade >= 60 && data.AverageGrade <= 80)
            {
                // 正常策略-图形验证码
                return new UserActionVerificationModel()
                {
                    Type = UserActionVerificationTypeEnum.Jigsaw,
                    Data = ""
                };
            }
            else if (data.AverageGrade >= 80 && data.AverageGrade <= 90)
            {
                // 宽松策略-滑条
                return new UserActionVerificationModel()
                {
                    Type = UserActionVerificationTypeEnum.Slider,
                    Data = await _silderManager.GetVerificationTokenAsync(input)
                };
            } 
            else
            {
                // 免认证
                return new UserActionVerificationModel()
                {
                    Type = UserActionVerificationTypeEnum.UnAuth,
                    Data = "Security"
                };
            }
        }
    }
}
