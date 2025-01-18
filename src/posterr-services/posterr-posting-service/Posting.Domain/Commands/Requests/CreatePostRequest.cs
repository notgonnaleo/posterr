using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Posting.Domain.Commands.Requests
{
    public class CreatePostRequest
    {
        public int AuthorId { get; set; }
        public string PostContent { get; set; }
    }
}
