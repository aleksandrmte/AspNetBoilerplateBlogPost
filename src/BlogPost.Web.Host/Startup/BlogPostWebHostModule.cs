using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using BlogPost.Configuration;

namespace BlogPost.Web.Host.Startup
{
    [DependsOn(
       typeof(BlogPostWebCoreModule))]
    public class BlogPostWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public BlogPostWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BlogPostWebHostModule).GetAssembly());
        }
    }
}
