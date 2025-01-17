using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Posterr.Domain.Entities
{
    public class User : BaseEntity
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
    }
}
