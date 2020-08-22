using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogPost.Posts
{
    public interface IPostManager
    {
        Task<IEnumerable<Post>> GetAll();
        Task<Post> GetById(int id);
        Task<Post> Create(Post entity);
        Task Update(Post entity);
        Task Delete(int id);
        Task AddTag(int postId, Tag tag);
        Task<IEnumerable<Post>> FindPosts(string tagName);
    }
}
