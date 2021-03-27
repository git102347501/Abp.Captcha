using System;
using System.Collections.Generic;
using System.Text;

namespace Abp.Captcha.Slider
{
    /// <summary>
    /// 滑条验证数据模型
    /// </summary>
    public class ValidationModel
    {
        /// <summary>
        /// 请求数据
        /// </summary>
        public int[] Data { get; set; }

        /// <summary>
        /// 会话信息
        /// </summary>
        public SliderActionModel ActionData { get; set; }

        public ValidationModel(int[] data)
        {
            Data = data;
        }
    }
}
