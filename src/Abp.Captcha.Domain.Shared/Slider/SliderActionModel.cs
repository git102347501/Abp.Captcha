using System;
using System.Collections.Generic;
using System.Text;

namespace MaigcalConch.Abp.Captcha.Slider
{
    /// <summary>
    /// 请求会话信息
    /// </summary>
    public class SliderActionModel
    {
        public string Ip { get; set; }

        public string Device { get; set; }

        public SliderActionModel(string ip, string device)
        {
            this.Ip = ip;
            Device = device;
        }
    }
}
