using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace BlogPost.Authorization
{
    public class BlogPostAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);

            var administration = context.CreatePermission("Administration");
            var blogManagement = administration.CreateChildPermission("Administration.BlogManagement");
            blogManagement.CreateChildPermission("Administration.BlogManagement.Post");
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, BlogPostConsts.LocalizationSourceName);
        }
    }
}
