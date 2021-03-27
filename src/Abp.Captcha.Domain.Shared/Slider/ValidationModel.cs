using System;
using System.Collections.Generic;
using System.Text;

namespace Abp.Captcha.Slider
{
    public class ValidationModel
    {
        public int[] Data { get; set; }

        public ValidationModel(int[] data)
        {
            Data = data;
        }
    }
}
