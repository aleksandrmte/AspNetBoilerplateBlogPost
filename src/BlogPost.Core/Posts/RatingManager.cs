using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.EntityFrameworkCore.Repositories;
using Abp.UI;
using Microsoft.EntityFrameworkCore;

namespace BlogPost.Posts
{
    public class RatingManager: DomainService, IRatingManager
    {
        private readonly IRepository<Rating> _repository;

        public RatingManager(IRepository<Rating> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Rating>> GetAll()
        {
            return await _repository.GetAllListAsync();
        }

        public async Task<Rating> GetById(int id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task<Rating> Create(Rating entity)
        {
            var rating = await _repository.FirstOrDefaultAsync(x => x.Id == entity.Id);
            if (rating != null) throw new UserFriendlyException($"Rating {entity.Id} already exists");
            await _repository.InsertAsync(entity);
            await _repository.GetDbContext().SaveChangesAsync();
            return entity;
        }

        public async Task Update(Rating entity)
        {
            await _repository.UpdateAsync(entity);
        }

        public async Task Delete(int id)
        {
            var rating = await _repository.FirstOrDefaultAsync(x => x.Id == id);
            if (rating == null) throw new UserFriendlyException($"Rating {id} not found");
            await _repository.DeleteAsync(rating);
        }

        public async Task<bool> IsUserAlreadyRatePost(long userId, int postId)
        {
            return await _repository.CountAsync(x => x.UserId == userId && x.PostId == postId) > 0;
        }

        public async Task<double> GetRatingAverage(int postId)
        {
            var items = await _repository.GetAllListAsync(x => x.PostId == postId);

            if (!items.Any()) return 0;

            return items.Average(x=>x.Value);
        }
    }
}
