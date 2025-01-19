using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Posting.Domain.Entities
{
    public class Repost
    {
        public int RepostId { get; set; }
        public int RepostUserId { get; set; }
        public int ParentPostId { get; set; }
        public DateTime RepostDate { get; set; }
    }
}
