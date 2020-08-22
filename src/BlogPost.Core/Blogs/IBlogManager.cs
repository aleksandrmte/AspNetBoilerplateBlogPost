using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogPost.Blogs
{
    public interface IBlogManager
    {
        Task<IEnumerable<Blog>> GetAllBlogsByActivity();
        Task<Blog> GetById(int id);
        Task<Blog> Create(Blog entity);
        Task Update(Blog entity);
        Task Delete(int id);
    }
}
