using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using BlogPost.Authorization.Users;
using BlogPost.Posts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogPost.Blogs
{
    public class Blog : Entity, IHasCreationTime, IHasModificationTime
    {
        public Blog(string name, long userId)
        {
            Name = name;
            UserId = userId;
            CreationTime = DateTime.UtcNow;
        }

        [Required]
        public string Name { get; private set; }
        public DateTime CreationTime { get; set; }

        [ForeignKey("User")]
        public long UserId { get; private set; }
       
        public void Update(string name)
        {
            Name = name;
            LastModificationTime = DateTime.UtcNow;
        }

        public DateTime? LastModificationTime { get; set; }

        public List<Post> Posts { get; set; }
    }
}
