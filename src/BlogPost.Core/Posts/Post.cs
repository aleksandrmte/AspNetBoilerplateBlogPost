using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using BlogPost.Authorization.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace BlogPost.Posts
{
    public class Post : Entity, IHasCreationTime, IHasModificationTime
    {
        public Post(string name, string content, int blogId, long userId)
        {
            Name = name;
            Content = content;
            BlogId = blogId;
            UserId = userId;
            CreationTime = DateTime.Now;
        }

        [Required]
        public string Name { get; private set; }

        [Required]
        public string Content { get; private set; }

        [Range(1, 5)]
        public double Rating { get; private set; }

        public DateTime CreationTime { get; set; }
        public DateTime? LastModificationTime { get; set; }

        [ForeignKey("Blog")]
        public int BlogId { get; private set; }

        [ForeignKey("User")]
        public long UserId { get; private set; }

        private readonly List<Tag> _tags = new List<Tag>();
        public IEnumerable<Tag> Tags => _tags;

        public void Update(string name, string content)
        {
            Name = name;
            Content = content;
            LastModificationTime = DateTime.UtcNow;
        }

        public void SetAverageRating(double rating)
        {
            Rating = rating;
        }

        public void AssignTag(Tag tag)
        {
            var exists = Tags.Contains(tag);

            if (!exists)
            {
                _tags.Add(tag);
            }
        }

    }
}
