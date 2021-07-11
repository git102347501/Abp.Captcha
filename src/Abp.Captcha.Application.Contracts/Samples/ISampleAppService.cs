using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace MaigcalConch.Abp.Captcha.Samples
{
    public interface ISampleAppService : IApplicationService
    {
        Task<SampleDto> GetAsync();

        Task<SampleDto> GetAuthorizedAsync();
    }
}
