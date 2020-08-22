using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using BlogPost.Blogs.Dto;

namespace BlogPost.Blogs
{
    public interface IBlogAppService: IApplicationService
    {
        Task<IEnumerable<GetBlogOutput>> ListAll();
        Task Create(CreateBlogInput input);
        Task Update(UpdateBlogInput input);
        Task Delete(DeleteBlogInput input);
        Task<GetBlogOutput> GetById(GetBlogInput input);
    }
}
