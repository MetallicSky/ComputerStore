using CStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CStore
{
    public class Store : DbContext
    {
        //public DbSet<Product> Products { get; set; }
        //public DbSet<Client> Clients { get; set; }
        //public DbSet<Category> Categories { get; set; } 
        //public DbSet<Order> Orders { get; set; }

        public Store(DbContextOptions<Store> options)
            :base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
    }
}
