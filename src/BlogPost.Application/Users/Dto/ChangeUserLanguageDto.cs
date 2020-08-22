using System.ComponentModel.DataAnnotations;

namespace BlogPost.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}