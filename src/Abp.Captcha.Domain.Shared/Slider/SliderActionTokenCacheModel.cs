using System;
using System.Collections.Generic;
using System.Text;

namespace MaigcalConch.Abp.Captcha.Slider
{
    public class SliderActionTokenCacheModel
    {
        public string Ip { get; set; }

        public SliderActionTokenCacheModel(string ip)
        {
            this.Ip = ip;
        }
    }
}
