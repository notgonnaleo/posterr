using Posterr.Domain.Entities;
using Posterr.Domain.Interfaces;
using Posterr.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Posterr.Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly AppDbContext _context;
        public PostRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Post>> GetPosts()
        {
            var response = await _context.Posts.ToListAsync();
            return response;
        }
    }
}
