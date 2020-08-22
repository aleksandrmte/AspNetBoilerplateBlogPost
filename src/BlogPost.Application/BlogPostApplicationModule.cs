using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using BlogPost.Authorization;
using BlogPost.Blogs;
using BlogPost.Blogs.Dto;
using BlogPost.Posts;
using BlogPost.Posts.Dto;

namespace BlogPost
{
    [DependsOn(
        typeof(BlogPostCoreModule),
        typeof(AbpAutoMapperModule))]
    public class BlogPostApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<BlogPostAuthorizationProvider>();

            Configuration.Modules.AbpAutoMapper().Configurators.Add(mapper =>
                {
                    mapper.CreateMap<Blog, GetBlogOutput>().ReverseMap();
                    mapper.CreateMap<Post, GetPostOutput>().ReverseMap();
                    mapper.CreateMap<Tag, GetTagOutput>().ReverseMap();
                });
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(BlogPostApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
