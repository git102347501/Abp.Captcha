using MaigcalConch.Abp.Captcha.VerifyPicture.Dtos;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaigcalConch.Abp.Captcha.VerifyPicture
{
    public class VerifyPictureAutoMapperProfile : Profile
    {
        public VerifyPictureAutoMapperProfile()
        {
            CreateMap<DownloadModel, VerifyPictureOutput>()
                .ForMember(cp => cp.Index, opt => opt.MapFrom(src => src.Index))
                .ForMember(cp => cp.Content, opt => opt.MapFrom(src => Convert.ToBase64String(src.Content)));
        }
    }
}
