using Microsoft.EntityFrameworkCore;
using Posting.Domain.Entities;

namespace Posting.Infrastructure.Seeds
{
    public class DatabaseSeed
    {
        public DatabaseSeed(ModelBuilder modelBuilder)
        {
            SeedUsers(modelBuilder);
            SeedPosts(modelBuilder);
            SeedReposts(modelBuilder);
        }

        private static void SeedUsers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User { UserId = 1, Username = "leonardo_bruni" });
            modelBuilder.Entity<User>().HasData(new User { UserId = 2, Username = "sinuhe_huidobro" });
            modelBuilder.Entity<User>().HasData(new User { UserId = 3, Username = "petvisor" });
            modelBuilder.Entity<User>().HasData(new User { UserId = 4, Username = "strider_platform" });
        }

        private static void SeedPosts(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().HasData(new Post { UserId = 3, PostId = 1, PostContent = "Hey! I'm using Posterr, follow me for more pet care & vet posts.", DateCreated = DateTime.UtcNow.AddDays(-2) });
            modelBuilder.Entity<Post>().HasData(new Post { UserId = 4, PostId = 2, PostContent = "Looking for career tips? follow us and get to know more about our ways.", DateCreated = DateTime.UtcNow.AddDays(-5) });
            modelBuilder.Entity<Post>().HasData(new Post { UserId = 1, PostId = 3, PostContent = "Hello World!", DateCreated = DateTime.UtcNow.AddDays(-1) });
        }

        private static void SeedReposts(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Repost>().HasData(new Repost { RepostId = 1, ParentPostId = 1, ParentRepostId = null, RepostUserId = 2, RepostDate = DateTime.UtcNow.AddDays(-3) });
            modelBuilder.Entity<Repost>().HasData(new Repost { RepostId = 2, ParentPostId = 2, ParentRepostId = null, RepostUserId = 1, RepostDate = DateTime.UtcNow.AddDays(-1).AddHours(-1) });
            modelBuilder.Entity<Repost>().HasData(new Repost { RepostId = 3, ParentPostId = 1, ParentRepostId = 1, RepostUserId = 1, RepostDate = DateTime.UtcNow.AddDays(-1) });

        }
    }
}
