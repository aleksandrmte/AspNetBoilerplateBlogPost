using System.ComponentModel.DataAnnotations;
using Abp.Runtime.Validation;

namespace BlogPost.Blogs.Dto
{
    public class UpdateBlogInput: ICustomValidate
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void AddValidationErrors(CustomValidationContext context)
        {
            if (string.IsNullOrEmpty(Name)) context.Results.Add(new ValidationResult($"{nameof(Name)} is required"));
            if (Id <= 0) context.Results.Add(new ValidationResult($"{nameof(Id)} is required"));
        }
    }
}
