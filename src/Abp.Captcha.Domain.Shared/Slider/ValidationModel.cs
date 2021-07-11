using System;
using System.Collections.Generic;
using System.Text;

namespace MaigcalConch.Abp.Captcha.Slider
{
    /// <summary>
    /// 滑条验证数据模型
    /// </summary>
    public class ValidationModel<T>
    {
        /// <summary>
        /// 请求数据
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// 会话信息
        /// </summary>
        public SliderActionModel ActionData { get; set; }

        public ValidationModel(T data, SliderActionModel actionData)
        {
            Data = data;
            ActionData = actionData;
        }
    }
}
