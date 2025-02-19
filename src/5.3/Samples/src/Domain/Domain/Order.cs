﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Order : BaseEntity
    {
        public Guid UserId { get; set; }
        public User User { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
