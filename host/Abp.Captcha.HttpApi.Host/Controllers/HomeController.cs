using MaigcalConch.Abp.Captcha.VerifyPicture;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace MaigcalConch.Abp.Captcha.Controllers
{
    public class HomeController : AbpController
    {
        public ActionResult Index()
        {
            return Redirect("~/swagger");
        }
    }
}
