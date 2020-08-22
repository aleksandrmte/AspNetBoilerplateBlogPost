using Abp.Application.Services;
using Abp.UI;
using BlogPost.Posts.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Authorization;

namespace BlogPost.Posts
{
    public class PostAppService : ApplicationService, IPostAppService
    {
        private readonly IPostManager _manager;
        private readonly IRatingManager _ratingManager;

        public PostAppService(IPostManager manager, IRatingManager ratingManager)
        {
            _manager = manager;
            _ratingManager = ratingManager;
        }

        public async Task<IReadOnlyList<GetPostOutput>> ListAll()
        {
            var list = await _manager.GetAll();
            return list.Select(ObjectMapper.Map<GetPostOutput>).ToList();
        }

        [AbpAuthorize("Administration.BlogManagement.Post")]
        public async Task Create(CreatePostInput input)
        {
            var entity = new Post(input.Name, input.Content, input.BlogId, AbpSession.UserId.Value);

            foreach (var inputTag in input.Tags)
                entity.AssignTag(new Tag(inputTag.Name));

            await _manager.Create(entity);
        }

        [AbpAuthorize("Administration.BlogManagement.Post")]
        public async Task Update(UpdatePostInput input)
        {
            var entity = await _manager.GetById(input.Id);

            if (entity == null) throw new UserFriendlyException($"Post {input.Id} not found");

            if (entity.UserId != AbpSession.UserId) throw new UserFriendlyException("Access denied");

            entity.Update(input.Name, input.Content);

            await _manager.Update(entity);
        }

        [AbpAuthorize("Administration.BlogManagement.Post")]
        public async Task Delete(DeletePostInput input)
        {
            var entity = await _manager.GetById(input.Id);

            if (entity == null) throw new UserFriendlyException($"Post {input.Id} not found");

            if (entity.UserId != AbpSession.UserId) throw new Exception("Access denied");

            await _manager.Delete(input.Id);
        }

        public async Task<GetPostOutput> GetById(GetPostInput input)
        {
            var entity = await _manager.GetById(input.Id);

            if (entity == null) throw new UserFriendlyException($"Post {input.Id} not found");

            return ObjectMapper.Map<GetPostOutput>(entity);
        }

        public async Task Rate(CreateRatingInput input)
        {
            try
            {

            

            var isAlreadyRate = await _ratingManager.IsUserAlreadyRatePost(AbpSession.UserId.Value, input.PostId);
            if (isAlreadyRate) throw new UserFriendlyException($"User {AbpSession.UserId} already rate post {input.PostId}");

            await _ratingManager.Create(new Rating(input.Value, input.PostId, AbpSession.UserId.Value));

            var post = await _manager.GetById(input.PostId);
            var averageRating = await _ratingManager.GetRatingAverage(input.PostId);
            post.SetAverageRating(averageRating);
            await _manager.Update(post);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<double> GetPostRating(GetPostInput input)
        {
            return (await _manager.GetById(input.Id))?.Rating ?? 0;
        }

        public async Task<IReadOnlyList<GetTagOutput>> GetPostTags(GetPostInput input)
        {
            var entity = await _manager.GetById(input.Id);

            if (entity == null) throw new UserFriendlyException($"Post {input.Id} not found");

            return entity.Tags.Select(ObjectMapper.Map<GetTagOutput>).ToList();
        }

        public async Task<IReadOnlyList<GetPostOutput>> FindPosts(FindPostsInput input)
        {
            var list = await _manager.FindPosts(input.TagName);
            return list.Select(ObjectMapper.Map<GetPostOutput>).ToList();
        }
    }
}
