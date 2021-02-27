﻿using Abp.Captcha.Slider.Dtos;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.DependencyInjection;

namespace Abp.Captcha.Slider
{
    public class SliderAttribute : Attribute, IAsyncActionFilter, ITransientDependency
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var data = context.HttpContext.Request.Headers.FirstOrDefault(c => c.Key == "Data");

            if (data.Key.IsNullOrWhiteSpace())
            {
                throw new UserFriendlyException("The verification code is not valid!");
            }

            var _verifyPictureAppService = context.HttpContext.RequestServices.GetService(typeof(ISliderAppService)) as ISliderAppService;
            if (!await _verifyPictureAppService.ValidationAsync(new ValidationModel(data.Value.ToString().Split(','))))
            {
                throw new UserFriendlyException("The verification code is wrong!");
            }
            await next();
        }
    }
}