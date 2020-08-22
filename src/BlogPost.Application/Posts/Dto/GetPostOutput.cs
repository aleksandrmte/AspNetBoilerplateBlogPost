using System;
using System.Collections.Generic;

namespace BlogPost.Posts.Dto
{
    public class GetPostOutput
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public int BlogId { get; set; }
        public long UserId { get; set; }
        public DateTime CreationTime { get; set; }
        public List<GetTagOutput> Tags { get; set; }
    }
}
