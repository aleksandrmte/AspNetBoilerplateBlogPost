using Abp.Authorization;
using BlogPost.Authorization.Roles;
using BlogPost.Authorization.Users;

namespace BlogPost.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
