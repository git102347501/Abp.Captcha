using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace MagicalConch.Abp.Captcha.IP
{
    public class IPManager: IDomainService, IIPManager
    {
        private readonly IIPRepository _ipRepository;

        public IPManager(IIPRepository ipRepository)
        {
            _ipRepository = ipRepository;
        }

        /// <summary>
        /// 添加IP
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="type"></param>
        /// <param name="category"></param>
        /// <returns></returns>
        public async Task AddAsync(string ip, IPTypeEnum type, IPCategoryEnum category)
        {
            Check.NotNullOrWhiteSpace(ip, nameof(ip));

            await _ipRepository.InsertAsync(new IPMaster(ip, type, category));
        }

        public async Task ValidationAsync(string ip, int time, int count)
        {

        }
    }
}
