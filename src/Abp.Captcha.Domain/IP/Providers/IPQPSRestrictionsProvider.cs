using MagicalConch.Abp.Captcha.IP.Caches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Caching;

namespace MagicalConch.Abp.Captcha.IP.Providers
{
    public class IPQPSRestrictionsProvider : IIPQPSRestrictionsProvider
    {
        private readonly IDistributedCache<IPCacheCache> _cacheCountCache;

        /// <summary>
        /// 验证QPS限制
        /// </summary>
        /// <param name="ip">IP地址</param>
        /// <param name="time">需要限制的时间范围，以秒为单位</param>
        /// <param name="count"></param>
        /// <returns></returns>
        public async Task<bool> ValidationAsync(string ip, int time, int count)
        {
            var cache = await _cacheCountCache.GetAsync(ip);
            if (cache == null)
            {
                return true;
            } 
            else
            {
                var date = DateTime.Now.AddMinutes(time * -1);
                if (cache.DateTimeList.Count(c=> c > date) >= count)
                {
                    return false;
                } 
                else
                {
                    return true;
                }
            }
        }
    }
}
