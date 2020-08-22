using System.ComponentModel.DataAnnotations;
using Abp.Runtime.Validation;

namespace BlogPost.Blogs.Dto
{
    public class GetBlogInput: ICustomValidate
    {
        public int Id { get; set; }

        public void AddValidationErrors(CustomValidationContext context)
        {
            if (Id <= 0) context.Results.Add(new ValidationResult($"{nameof(Id)} is required"));
        }
    }
}
