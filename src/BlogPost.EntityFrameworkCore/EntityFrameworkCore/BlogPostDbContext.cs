using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using BlogPost.Authorization.Roles;
using BlogPost.Authorization.Users;
using BlogPost.Blogs;
using BlogPost.MultiTenancy;
using BlogPost.Posts;

namespace BlogPost.EntityFrameworkCore
{
    public class BlogPostDbContext : AbpZeroDbContext<Tenant, Role, User, BlogPostDbContext>
    {
        /* Define a DbSet for each entity of the application */

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        
        public BlogPostDbContext(DbContextOptions<BlogPostDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Post>().OwnsMany<Tag>("Tags", a =>
            {
                a.HasKey("PostId");
                a.Property(ca => ca.Name);
                a.HasKey("PostId", "Name");
            });

            //modelBuilder.Entity<Post>()
            //    .HasOne(x=>x.User)
            //        .WithMany()
            //        .HasForeignKey(x=>x.UserId)
            //        .OnDelete(DeleteBehavior.NoAction);

            //modelBuilder.Entity<Rating>()
            //    .HasOne(x => x.User)
            //    .WithMany()
            //    .HasForeignKey(x => x.UserId)
            //    .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
