﻿using System.Threading.Tasks;
using Abp.Captcha.VerifyPicture;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;

namespace Abp.Captcha.Samples
{
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
    }
}
