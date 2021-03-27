using System;
using System.Collections.Generic;
using System.Text;

namespace Abp.Captcha.Slider
{
    public class SliderActionCacheModel
    {
        public string Ip { get; set; }

        public string Address { get; set; }

        public string Browser { get; set; }

        public int Count { get; set; }

        public SliderActionCacheModel(string ip, string address = "", string brower = "", int count = 0)
        {
            this.Ip = ip;
            this.Address = address;
            this.Browser = brower;
            this.Count = count;
        }

        public void AddCount()
        {
            this.Count++;
        }
    }
}
