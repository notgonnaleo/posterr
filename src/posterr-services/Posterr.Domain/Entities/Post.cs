using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Posterr.Domain.Entities
{
    public class Post
    {
        public int PostId { get; set; }
        public string Description { get; set; }
        public int AuthorId { get; set; }
    }
}
