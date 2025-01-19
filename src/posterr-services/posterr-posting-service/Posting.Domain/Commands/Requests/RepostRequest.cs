using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Posting.Domain.Commands.Requests
{
    public class RepostRequest
    {
        public int UserId { get; set; }
        public string PostId { get; set; }
    }
}
