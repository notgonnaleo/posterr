using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Posting.Domain.Entities
{
    public class Post
    {
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string PostContent { get; set; }
        public int TotalReposts { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
