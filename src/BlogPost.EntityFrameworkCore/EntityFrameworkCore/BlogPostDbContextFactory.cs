using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using BlogPost.Configuration;
using BlogPost.Web;

namespace BlogPost.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class BlogPostDbContextFactory : IDesignTimeDbContextFactory<BlogPostDbContext>
    {
        public BlogPostDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<BlogPostDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            BlogPostDbContextConfigurer.Configure(builder, configuration.GetConnectionString(BlogPostConsts.ConnectionStringName));

            return new BlogPostDbContext(builder.Options);
        }
    }
}
