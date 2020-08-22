using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using BlogPost.Roles.Dto;
using BlogPost.Users.Dto;

namespace BlogPost.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);

        Task<bool> ChangePassword(ChangePasswordDto input);
    }
}
