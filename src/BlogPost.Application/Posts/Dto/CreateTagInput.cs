using System.ComponentModel.DataAnnotations;
using Abp.Runtime.Validation;

namespace BlogPost.Posts.Dto
{
    public class CreateTagInput: ICustomValidate
    {
        public string Name { get; set; }

        public void AddValidationErrors(CustomValidationContext context)
        {
            if (string.IsNullOrEmpty(Name)) context.Results.Add(new ValidationResult($"{nameof(Name)} is required"));
        }
    }
}
