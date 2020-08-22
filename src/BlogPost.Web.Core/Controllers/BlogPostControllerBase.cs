using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace BlogPost.Controllers
{
    public abstract class BlogPostControllerBase: AbpController
    {
        protected BlogPostControllerBase()
        {
            LocalizationSourceName = BlogPostConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
