using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.UI;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPost.Blogs
{
    public class BlogManager : DomainService, IBlogManager
    {
        private readonly IRepository<Blog> _repository;

        public BlogManager(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Blog>> GetAllBlogsByActivity()
        {
            return await _repository.GetAllIncluding(x => x.Posts).OrderByDescending(x => x.Posts.Count).ToListAsync();
        }

        public async Task<Blog> Create(Blog entity)
        {
            var blog = await _repository.FirstOrDefaultAsync(x => x.Id == entity.Id);
            if (blog != null) throw new UserFriendlyException($"Blog {entity.Id} already exists");
            await _repository.InsertAsync(entity);
            return entity;
        }

        public async Task Delete(int id)
        {
            var blog = await _repository.FirstOrDefaultAsync(x => x.Id == id);
            if (blog == null) throw new UserFriendlyException($"Blog {id} not found");
            await _repository.DeleteAsync(blog);
        }

        public async Task<Blog> GetById(int id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task Update(Blog entity)
        {
            await _repository.UpdateAsync(entity);
        }
    }
}
