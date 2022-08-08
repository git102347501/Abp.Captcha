using System;
using System.Collections.Generic;
using System.Text;

namespace MagicalConch.Abp.Captcha.UserAction
{
    public class UserActionVerificationModel
    {
        public UserActionVerificationTypeEnum Type { get; set; }

        public string Data { get; set; }
    }
}
