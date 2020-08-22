using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogPost.Posts
{
    public class Rating : Entity, IHasCreationTime
    {
        public Rating(int value, int postId, long userId)
        {
            Value = value;
            PostId = postId;
            UserId = userId;
            CreationTime = DateTime.UtcNow;
        }

        [Range(1, 5)]
        public int Value { get; private set; }

        
        public int PostId { get; private set; }
        public Post Post { get; private set; }


        [ForeignKey("User")]
        public long UserId { get; private set; }

        public DateTime CreationTime { get; set; }
    }
}
