using System;
using System.ComponentModel.DataAnnotations;
using Abp.Runtime.Validation;

namespace BlogPost.Blogs.Dto
{
    public class CreateBlogInput: ICustomValidate
    {
        public string Name { get; set; }

        public void AddValidationErrors(CustomValidationContext context)
        {
            if (string.IsNullOrEmpty(Name)) context.Results.Add(new ValidationResult($"{nameof(Name)} is required"));
        }
    }
}
