using Abp.Application.Services;
using Abp.Authorization;
using Abp.UI;
using BlogPost.Blogs.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPost.Blogs
{
    public class BlogAppService: ApplicationService, IBlogAppService
    {
        private readonly IBlogManager _manager;

        public BlogAppService(IBlogManager manager)
        {
            _manager = manager;
        }
        
        public async Task<IEnumerable<GetBlogOutput>> ListAll()
        {
            var list = await _manager.GetAllBlogsByActivity();
            return list.Select(ObjectMapper.Map<GetBlogOutput>).ToList();
        }

        [AbpAuthorize("Administration.BlogManagement")]
        public async Task Create(CreateBlogInput input)
        {
            var entity = new Blog(input.Name, AbpSession.UserId.Value);

            await _manager.Create(entity);
        }

        [AbpAuthorize("Administration.BlogManagement")]
        public async Task Update(UpdateBlogInput input)
        {
            var entity = await _manager.GetById(input.Id);

            if (entity == null) throw new UserFriendlyException($"Blog {input.Id} not found");

            entity.Update(input.Name);

            await _manager.Update(entity);
        }

        [AbpAuthorize("Administration.BlogManagement")]
        public async Task Delete(DeleteBlogInput input)
        {
            await _manager.Delete(input.Id);
        }

        public async Task<GetBlogOutput> GetById(GetBlogInput input)
        {
            var entity = await _manager.GetById(input.Id);

            if (entity == null) throw new UserFriendlyException($"Blog {input.Id} not found");

            return ObjectMapper.Map<GetBlogOutput>(entity);
        }
    }
}
