using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Posterr.Domain.Models
{
    public class Feed
    {
        public int PostId { get; set; }
        public int? RepostId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int TotalLikes { get; set; }
        public int AuthorId { get; set; }
        public int OriginalAuthorId { get; set; }
    }
}
