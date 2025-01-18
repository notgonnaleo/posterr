using Microsoft.EntityFrameworkCore;
using Posting.Domain.Entities;
using Posting.Domain.Interfaces.Repositories;
using Posting.Infrastructure.Contexts;

namespace Posting.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;      
        }
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
