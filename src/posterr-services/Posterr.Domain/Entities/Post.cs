﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Posterr.Domain.Entities
{
    public class Post : BaseEntity
    {
        public int PostId { get; set; }
        public string PostContent { get; set; }
        public int UserId { get; set; }
    }
}
