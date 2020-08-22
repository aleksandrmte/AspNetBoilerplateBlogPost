using System.Threading.Tasks;
using Abp.Application.Services;
using BlogPost.Authorization.Accounts.Dto;

namespace BlogPost.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
