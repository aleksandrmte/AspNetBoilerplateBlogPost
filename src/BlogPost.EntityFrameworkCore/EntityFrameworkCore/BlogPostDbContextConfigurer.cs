using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace BlogPost.EntityFrameworkCore
{
    public static class BlogPostDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<BlogPostDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<BlogPostDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
