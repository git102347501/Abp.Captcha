using JetBrains.Annotations;
using MagicalConch.Abp.Captcha.UserAction.CacheModel;
using MaigcalConch.Abp.Captcha.Slider;
using MaigcalConch.Abp.Captcha.UserAction;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Caching;
using Volo.Abp.Domain.Services;
using Volo.Abp.Guids;

namespace MagicalConch.Abp.Captcha.UserAction
{
    /// <summary>
    /// user action domain service
    /// </summary>
    public class UserActionManager : DomainService, IUserActionManager
    {
        private readonly IDeviceAppraiseProvider _deviceAppraiseProvider;
        private readonly IIPAppraiseProvider _ipAppraiseProvider;
        private readonly IUserActionRepository _userActionRepository;
        private readonly IDistributedCache<UserActionCache> _cache;

        public UserActionManager(IDeviceAppraiseProvider deviceAppraiseProvider, IIPAppraiseProvider ipAppraiseProvider,
            IDistributedCache<UserActionCache> cache, IUserActionRepository userActionRepository)
        {
            _deviceAppraiseProvider = deviceAppraiseProvider;
            _ipAppraiseProvider = ipAppraiseProvider;
            _cache = cache;
            _userActionRepository = userActionRepository;
        }

        /// <summary>
        /// get user action appraise
        /// </summary>
        /// <returns></returns>
        private async Task<UserActionAppraise> GetAppraise(Guid? userId, string ip, string device)
        {
            var deviceGrade = await _deviceAppraiseProvider.GetGrade(userId, device);
            var ipGrade = await _ipAppraiseProvider.GetGrade(userId, ip);

            return new UserActionAppraise(){ 
                DeviceGrade = deviceGrade,
                IPGrade = ipGrade
            };
        }

        public async Task<UserActionVerificationModel> GetVerificationModeAsync(Guid? userId, ValidationModel<string> input)
        {
            var data = await this.GetAppraise(userId, input.ActionData.Ip, input.ActionData.Device);
            var result = new UserActionVerificationModel()
            {
                Type = UserActionVerificationTypeEnum.VerifyPicture,
                Data = "",
                Id = GuidGenerator.Create()
            };
            if (data.AverageGrade <= 60)
            {
                // 严格策略-拼图
                result.Type = UserActionVerificationTypeEnum.VerifyPicture;
            } 
            else if (data.AverageGrade >= 60 && data.AverageGrade <= 80)
            {
                // 正常策略-图形验证码
                result.Type = UserActionVerificationTypeEnum.Jigsaw;
            }
            else if (data.AverageGrade >= 80 && data.AverageGrade <= 90)
            {
                // 宽松策略-滑条
                result.Type = UserActionVerificationTypeEnum.Slider;
            } 
            else
            {
                // 免认证
                result.Type = UserActionVerificationTypeEnum.UnAuth;
            }
            await _cache.SetAsync(result.Id.ToString(), new UserActionCache()
            {
                Type = result.Type
            }, new Microsoft.Extensions.Caching.Distributed.DistributedCacheEntryOptions() { AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(1) });
            return result;
        }

        public async Task AddAsync(string ip, string path, string deviceName, Guid? userId = null)
        {
            await _userActionRepository.InsertAsync(new UserActionMaster(ip,path, deviceName, userId));
        }

        public async Task<bool> VerificationTokenAsync(Guid id, UserActionVerificationTypeEnum type)
        {
            var data = await _cache.GetAsync(id.ToString());
            if (data == null || data.Type != type)
            {
                return false;
            } 
            else
            {
                await _cache.RemoveAsync(id.ToString());
                return true;
            }
        }
    }
}
