using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Runtime.Validation;

namespace BlogPost.Posts.Dto
{
    public class CreatePostInput: ICustomValidate
    {
        public string Name { get; set; }
        public string Content { get; set; }
        public int BlogId { get; set; }

        public List<CreateTagInput> Tags { get; set; } = new List<CreateTagInput>();

        public void AddValidationErrors(CustomValidationContext context)
        {
            if (string.IsNullOrEmpty(Name)) context.Results.Add(new ValidationResult($"{nameof(Name)} is required"));
            if (string.IsNullOrEmpty(Content)) context.Results.Add(new ValidationResult($"{nameof(Content)} is required"));
            if (BlogId <= 0) context.Results.Add(new ValidationResult($"{nameof(BlogId)} is required"));
        }
    }
}
