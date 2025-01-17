using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Posterr.Domain.Entities
{
    public class Repost : BaseEntity
    {
        public int RepostId { get; set; }
        public int RepostUserId { get; set; }
        public int OriginalPostId { get; set; }
        public DateTime RepostDate { get; set; }
    }
}
