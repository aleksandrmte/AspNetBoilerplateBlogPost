using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using BlogPost.EntityFrameworkCore;
using BlogPost.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace BlogPost.Web.Tests
{
    [DependsOn(
        typeof(BlogPostWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class BlogPostWebTestModule : AbpModule
    {
        public BlogPostWebTestModule(BlogPostEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BlogPostWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(BlogPostWebMvcModule).Assembly);
        }
    }
}