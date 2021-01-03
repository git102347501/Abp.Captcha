using Abp.Captcha.VerifyPicture.Dtos;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abp.Captcha.VerifyPicture
{
    public class VerifyPictureAutoMapperProfile : Profile
    {
        public VerifyPictureAutoMapperProfile()
        {
            CreateMap<DownloadModel, VerifyPictureOutput>().ConstructUsing(cp => new VerifyPictureOutput
            {
                Index = cp.Index,
                Content = cp.Content
            });
        }
    }
}
