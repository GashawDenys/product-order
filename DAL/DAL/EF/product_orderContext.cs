using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;

namespace DAL.EF
{
    public class categoryContext
        : DbContext
    {
        public DbSet<cart> Carts { get; set; }
        public DbSet<customer> Customers { get; set; }
        public DbSet<cartItem> CartItems { get; set; }
        public DbSet<storeOrder> StoreOrders { get; set; }
        public categoryContext(DbContextOptions options)
            : base(options) { }
    }
}
