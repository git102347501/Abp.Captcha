using System;
using System.Collections.Generic;
using System.Text;

namespace Abp.Captcha.Slider
{
    /// <summary>
    /// 请求会话信息
    /// </summary>
    public class SliderActionModel
    {
        public string Ip { get; set; }

        public SliderActionModel(string ip)
        {
            this.Ip = ip;
        }
    }
}
