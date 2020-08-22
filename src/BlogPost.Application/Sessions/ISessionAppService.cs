using System.Threading.Tasks;
using Abp.Application.Services;
using BlogPost.Sessions.Dto;

namespace BlogPost.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
