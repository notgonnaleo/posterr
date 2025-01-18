using Microsoft.EntityFrameworkCore;
using Posting.Domain.Entities;
using Posting.Infrastructure.Seeds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Posting.Infrastructure.Contexts
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
                .Property(p => p.DateCreated);

            modelBuilder.Entity<Post>()
                .Property(p => p.PostContent)
                .HasMaxLength(777);

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
                .HasForeignKey(r => r.ParentPostId);

            modelBuilder.Entity<Repost>()
                .Property(r => r.RepostDate);

            modelBuilder.Entity<Repost>()
                .HasOne<User>() 
                .WithMany()  
                .HasForeignKey(r => r.RepostUserId);  

            modelBuilder.Entity<Repost>()
                .HasIndex(r => new { r.RepostUserId, r.ParentPostId })
                .IsUnique();

            // Mock
            new DatabaseSeed(modelBuilder);
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Repost> Reposts { get; set; }
    }
}
