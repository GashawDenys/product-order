using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;

namespace DAL.EF
{
    public class product_orderContext
        : DbContext
    {
        public DbSet<cart> Carts { get; set; }
        public DbSet<customer> Customers { get; set; }
        public DbSet<cartItem> CartItems { get; set; }
        public DbSet<storeOrder> StoreOrders { get; set; }
        public product_orderContext(DbContextOptions options)
            : base(options) { }
    }
}
