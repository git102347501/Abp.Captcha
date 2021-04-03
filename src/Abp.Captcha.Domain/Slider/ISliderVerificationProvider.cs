using Abp.Captcha.VerifyPicture;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Abp.Captcha.Slider
{
    public interface ISliderVerificationProvider
    {
        Task<bool> VerificationAsync(ValidationModel<int[]> data);
    }
}
