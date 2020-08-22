using System.ComponentModel.DataAnnotations;
using Abp.Runtime.Validation;

namespace BlogPost.Posts.Dto
{
    public class DeletePostInput: ICustomValidate
    {
        public int Id { get; set; }

        public void AddValidationErrors(CustomValidationContext context)
        {
            if (Id <= 0) context.Results.Add(new ValidationResult($"{nameof(Id)} is required"));
        }
    }
}
