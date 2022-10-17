using MagicalConch.Abp.Captcha.IP.Caches;
using MagicalConch.Abp.Captcha.IP.Providers;
using MaigcalConch.Abp.Captcha.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Caching;
using Volo.Abp.Domain.Services;
using Volo.Abp.Settings;

namespace MagicalConch.Abp.Captcha.IP
{
    public class IPManager: IDomainService, IIPManager
    {
        private readonly IIPRepository _ipRepository;
        private readonly ISettingProvider _settingProvider;
        private readonly IIPQPSRestrictionsProvider _ipQpsRestrictionsProvider;
        private readonly IDistributedCache<IPVisitCache> _ipVisitCache;

        public IPManager(IIPRepository ipRepository, IDistributedCache<IPVisitCache> ipVisitCache)
        {
            _ipRepository = ipRepository;
            _ipVisitCache = ipVisitCache;
        }

        /// <summary>
        /// 添加IP
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public async Task AddAsync(string ip)
        {
            Check.NotNullOrWhiteSpace(ip, nameof(ip));

            var data = await _ipVisitCache.GetAsync(ip);
            if (data != null)
            {
                data.DateTimeList.Add(DateTime.Now);
            } 
            else
            {
                await _ipVisitCache.SetAsync(ip, new IPVisitCache(DateTime.Now));
            }
        }

        /// <summary>
        /// 添加IP
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="type"></param>
        /// <param name="category"></param>
        /// <returns></returns>
        public async Task AddIpConfigAsync(string ip, IPTypeEnum type, IPCategoryEnum category)
        {
            Check.NotNullOrWhiteSpace(ip, nameof(ip));

            await _ipRepository.InsertAsync(new IPMaster(ip, type, category));
        }

        /// <summary>
        /// 审核IP访问次数
        /// </summary>
        /// <param name="ip">IP地址</param>
        /// <returns></returns>
        /// <exception cref="BusinessException"></exception>
        public async Task ValidationAsync(string ip)
        {
            var configTime = await _settingProvider.GetAsync<int>(CaptchaSettings.IpTime);
            var configCount = await _settingProvider.GetAsync<int>(CaptchaSettings.IpCount);
            if (configTime < 1 || configCount < 1)
            {
                throw new BusinessException("Ip:WrongIpConfig");
            }

            if (await _ipQpsRestrictionsProvider.ValidationAsync(ip, configTime, configCount))
            {
                throw new BusinessException("Ip:FrequentIPAccess");
            }
        }
    }
}
