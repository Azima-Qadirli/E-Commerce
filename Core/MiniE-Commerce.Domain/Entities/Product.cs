﻿using MiniE_Commerce.Domain.Entities.Common;

namespace MiniE_Commerce.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public float Price { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
