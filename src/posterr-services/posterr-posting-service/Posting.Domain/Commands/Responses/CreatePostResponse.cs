using Posting.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Posting.Domain.Commands.Responses
{
    public class CreatePostResponse
    {
        public FeedItem Post { get; set; }
    }
}
