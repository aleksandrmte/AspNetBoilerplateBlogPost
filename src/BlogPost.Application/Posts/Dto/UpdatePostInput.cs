using System.ComponentModel.DataAnnotations;
using Abp.Runtime.Validation;

namespace BlogPost.Posts.Dto
{
    public class UpdatePostInput: ICustomValidate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }

        public void AddValidationErrors(CustomValidationContext context)
        {
            if (string.IsNullOrEmpty(Name)) context.Results.Add(new ValidationResult($"{nameof(Name)} is required"));
            if (string.IsNullOrEmpty(Content)) context.Results.Add(new ValidationResult($"{nameof(Content)} is required"));
            if (Id <= 0) context.Results.Add(new ValidationResult($"{nameof(Id)} is required"));
        }
    }
}
