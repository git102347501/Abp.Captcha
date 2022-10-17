using System.Threading.Tasks;
using MagicalConch.Abp.Captcha.UserAction;
using MaigcalConch.Abp.Captcha.Slider;
using MaigcalConch.Abp.Captcha.VerifyPicture;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;

namespace MaigcalConch.Abp.Captcha.Samples
{
    /// <summary>
    /// test
    /// </summary>
    [RemoteService]
    [Route("api/Captcha/sample")]
    public class SampleController : CaptchaController
    {
        [HttpGet]
        [Route("test")]
        [Captcha]
        public bool GetTest()
        {
            return true;
        }

        [HttpGet]
        [Route("slidertest")]
        [Slider]
        public bool GetTest1()
        {
            return true;
        }

        [HttpGet]
        [Route("useractiontest")]
        [UserAction]
        public bool GetTest2()
        {
            return true;
        }

        [HttpGet]
        [Route("useractiontest")]
        [UserAction]
        public bool GetTest3()
        {
            return true;
        }
    }
}
