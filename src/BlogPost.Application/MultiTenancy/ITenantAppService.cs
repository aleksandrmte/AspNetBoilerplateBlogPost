using Abp.Application.Services;
using BlogPost.MultiTenancy.Dto;

namespace BlogPost.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

