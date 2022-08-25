using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using E_CommenceAPI.Models;
using E_CommenceAPI.Common;

namespace E_CommenceAPI.DAL
{
    public class ECommenceDBContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductOrder> ProductOrders { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ECommenceConfigurationManager.GetConnectionString("BetSoftwareConnection"));
        }
    }
}
