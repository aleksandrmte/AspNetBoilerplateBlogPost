using System;

namespace BlogPost.Blogs.Dto
{
    public class GetBlogOutput
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationTime { get; set; }
        public long UserId { get; set; }
    }
}
