﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MagicalConch.Abp.Captcha.UserAction.Providers
{
    public class DeviceAppraiseProvider : IDeviceAppraiseProvider
    {
        private readonly int basicGrade = 59;
        private readonly IUserActionRepository _userActionRepository;

        public DeviceAppraiseProvider(IUserActionRepository userActionRepository)
        {
            _userActionRepository = userActionRepository;
        }

        public async Task<int> GetGrade(Guid userId, string deviceName)
        {
            if (string.IsNullOrWhiteSpace(deviceName))
            {
                return 0;
            }
            var count = await _userActionRepository.GetForDeviceListAsync(userId, deviceName);
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
