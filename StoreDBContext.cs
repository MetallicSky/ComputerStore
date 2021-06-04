using CStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CStore
{
    public class StoreDBContext : DbContext
    {
        public DbSet<Admin> Admins{ get; set; }
        public DbSet<BodyBox> BodyBoxes { get; set; }
        public DbSet<RAM> RAMs { get; set; }
        public DbSet<CPU> CPUs { get; set; }
        public DbSet<GPU> GPUs { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Motherboard> Motherboards { get; set; }
        public StoreDBContext(DbContextOptions<StoreDBContext> options)
            :base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
    }
}
