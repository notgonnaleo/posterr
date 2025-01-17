using Microsoft.EntityFrameworkCore;
using Posterr.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Posterr.Infrastructure.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Posts 
            modelBuilder.Entity<Post>()
                .HasKey(p => p.PostId);

            modelBuilder.Entity<Post>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(p => p.UserId)
                .IsRequired();

            modelBuilder.Entity<Post>()
                .Property(p => p.PostContent)
                .IsRequired();

            // Users
            modelBuilder.Entity<User>()
                .HasKey(p => p.UserId);

            modelBuilder.Entity<User>()
                .HasMany<Post>()
                .WithOne()
                .HasForeignKey(u => u.UserId)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.Username)
                .IsRequired();

            // Reposts
            modelBuilder.Entity<Repost>()
                .HasOne<Post>()
                .WithMany()
                .HasForeignKey(r => r.OriginalPostId); 

            modelBuilder.Entity<Repost>()
                .HasOne<User>() 
                .WithMany()  
                .HasForeignKey(r => r.RepostUserId);  

            modelBuilder.Entity<Repost>()
                .HasIndex(r => new { r.RepostUserId, r.OriginalPostId })
                .IsUnique();

        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Repost> Reposts { get; set; }
    }
}
