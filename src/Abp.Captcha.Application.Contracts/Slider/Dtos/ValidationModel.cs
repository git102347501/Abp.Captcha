using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Abp.Captcha.Slider.Dtos
{
    public class ValidationModel : EntityDto
    {
        public string[] Data { get; set; }

        public ValidationModel(string[] data)
        {
            Data = data;
        }
    }
}
