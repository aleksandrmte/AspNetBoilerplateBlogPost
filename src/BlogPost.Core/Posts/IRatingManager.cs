using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogPost.Posts
{
    public interface IRatingManager
    {
        Task<IEnumerable<Rating>> GetAll();
        Task<Rating> GetById(int id);
        Task<Rating> Create(Rating entity);
        Task Update(Rating entity);
        Task Delete(int id);
        Task<bool> IsUserAlreadyRatePost(long userId, int postId);
        Task<double> GetRatingAverage(int postId);
    }
}
