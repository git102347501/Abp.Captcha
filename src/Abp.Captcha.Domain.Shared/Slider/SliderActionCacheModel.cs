using System;
using System.Collections.Generic;
using System.Text;

namespace MaigcalConch.Abp.Captcha.Slider
{
    public class SliderActionCacheModel
    {
        public string Ip { get; set; }

        public int Count { get; set; }

        public SliderActionCacheModel(string ip, int count = 1)
        {
            this.Ip = ip;
            this.Count = count;
        }

        public void AddCount()
        {
            this.Count++;
        }
    }
}
