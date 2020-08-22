using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.UI;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPost.Posts
{
    public class PostManager : DomainService, IPostManager
    {
        private readonly IRepository<Post> _repository;

        public PostManager(IRepository<Post> repository)
        {
            _repository = repository;
        }

        public async Task AddTag(int postId, Tag tag)
        {
            var post = await _repository.FirstOrDefaultAsync(x => x.Id == postId);
            if (post == null) throw new UserFriendlyException($"Post {postId} not found");
            post.AssignTag(tag);
            await _repository.UpdateAsync(post);
        }

        public async Task<Post> Create(Post entity)
        {
            var post = await _repository.FirstOrDefaultAsync(x => x.Id == entity.Id);

            if (post != null) throw new UserFriendlyException($"Post {entity.Id} already exists");

            await _repository.InsertAsync(entity);

            return entity;
        }

        public async Task Delete(int id)
        {
            var post = await _repository.FirstOrDefaultAsync(x => x.Id == id);

            if (post == null) throw new UserFriendlyException($"Post {id} not found");

            await _repository.DeleteAsync(post);
        }

        public async Task<IEnumerable<Post>> GetAll()
        {
            return await _repository.GetAllIncluding(x => x.Tags).ToListAsync();
        }

        public async Task<IEnumerable<Post>> FindPosts(string tagName)
        {
            return await _repository.GetAllIncluding(x => x.Tags).Where(x => x.Tags.Any(t => t.Name.Contains(tagName))).ToListAsync();
        }

        public async Task<Post> GetById(int id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task Update(Post entity)
        {
            await _repository.UpdateAsync(entity);
        }
    }
}
