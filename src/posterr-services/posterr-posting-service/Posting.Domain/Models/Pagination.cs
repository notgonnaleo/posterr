using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Posting.Domain.Models
{
    public class Pagination
    {
        public int Take { get; set; } = 20;
        public int Skip { get; set; } = 0;
        public int TotalRowCount { get; set; } = 20;
    }
}
