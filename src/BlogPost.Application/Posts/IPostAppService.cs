using Abp.Application.Services;
using BlogPost.Posts.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogPost.Posts
{
    public interface IPostAppService : IApplicationService
    {
        Task<IReadOnlyList<GetPostOutput>> ListAll();
        Task Create(CreatePostInput input);
        Task Update(UpdatePostInput input);
        Task Delete(DeletePostInput input);
        Task<GetPostOutput> GetById(GetPostInput input);
        Task<double> GetPostRating(GetPostInput input);
        Task<IReadOnlyList<GetTagOutput>> GetPostTags(GetPostInput input);
        Task<IReadOnlyList<GetPostOutput>> FindPosts(FindPostsInput input);

    }
}
