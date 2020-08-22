using System.ComponentModel.DataAnnotations;
using Abp.Authorization.Users;

namespace BlogPost.Models.TokenAuth
{
    public class ExternalAuthenticateModel
    {
        [Required]
        [StringLength(UserLogin.MaxLoginProviderLength)]
        public string AuthProvider { get; set; }

        [Required]
        [StringLength(UserLogin.MaxProviderKeyLength)]
        public string ProviderKey { get; set; }

        [Required]
        public string ProviderAccessCode { get; set; }
    }
}
