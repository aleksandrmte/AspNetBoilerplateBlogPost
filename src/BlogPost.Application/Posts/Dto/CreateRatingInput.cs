using System.ComponentModel.DataAnnotations;
using Abp.Extensions;
using Abp.Runtime.Validation;

namespace BlogPost.Posts.Dto
{
    public class CreateRatingInput : ICustomValidate
    {
        public int Value { get; set; }
        public int PostId { get; set; }

        public void AddValidationErrors(CustomValidationContext context)
        {
            if (!Value.IsBetween(1, 5)) context.Results.Add(new ValidationResult($"{nameof(Value)} must between 1-5"));
            if (PostId <= 0) context.Results.Add(new ValidationResult($"{nameof(PostId)} is required"));
        }
    }
}
