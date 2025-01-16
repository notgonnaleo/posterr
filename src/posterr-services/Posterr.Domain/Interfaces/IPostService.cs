using Posterr.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Posterr.Domain.Interfaces
{
    public interface IPostService
    {
        Task<IEnumerable<Post>> GetPosts();
    }
}
