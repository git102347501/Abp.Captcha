using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.DependencyInjection;

namespace Abp.Captcha.Slider
{
    /// <summary>
    /// 滑条验证提供实现
    /// </summary>
    public class SliderVerificationProvider : ISliderVerificationProvider, ITransientDependency
    {
        private readonly int _averageMax;
        private readonly int _averageMin;

        public SliderVerificationProvider(IConfiguration configuration)
        {
            var averageMax = configuration["Verification:Slider:AverageMax"];
            var averageMin = configuration["Verification:Slider:AverageMin"];
            if (averageMax.IsNullOrWhiteSpace() || averageMin.IsNullOrWhiteSpace())
            {
                throw new UserFriendlyException("Verify configuration exception");
            }
            _averageMax = int.Parse(averageMax);
            _averageMin = int.Parse(averageMin);
        }

        /// <summary>
        /// 验证滑条是否有效
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task<bool> VerificationAsync(ValidationModel<int[]> data)
        {
            // 判断数字滑动速率是否超出正常值
            if (!await VerificationAverage(data.Data))
            {
                return false;
            }

            // 判断数字速率是否由慢变快
            if (!VerificationSpeed(data.Data))
            {
                return false;
            }
            // 根
            return true;
        }

        /// <summary>
        /// 判断数字滑动速率是否超出正常值
        /// </summary>
        private async Task<bool> VerificationAverage(int[] data)
        {
            return await Task.Run(() =>
            {
                int sum = 0;
                foreach (var item in data)
                {
                    sum += item;
                }
                int agv = sum / data.Length;
                return agv < _averageMax && agv > _averageMin;
            });
        }

        /// <summary>
        /// 验证滑动速率
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private bool VerificationSpeed(int[] data)
        {
            var results = new List<int>();
            for (int i = 0; i < data.Length - 1; i++)
            {
                results.Add(data[i + 1] - data[i]);
            }
            var couunt = results.Distinct().Count();
            if (couunt > 1)
            {
                var start = 0;
                var center = 0;
                var end = 0;

                while (results.Count == results.Count / 3 * 3)
                {
                    results.Remove(results.Last());
                }
                var count = results.Count / 3;
                for (int i = 0; i < count; i++)
                {
                    start += results[i];
                }

                for (int i = count; i < (count * 2); i++)
                {
                    center += results[i];
                }

                for (int i = (count * 2); i < (results.Count); i++)
                {
                    end += results[i];
                }
                start /= count;
                center /= count;
                end /= count;
                if (start < center && end > center)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
