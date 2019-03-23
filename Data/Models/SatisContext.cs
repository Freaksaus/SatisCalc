using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    public class SatisContext : DbContext
    {
        public SatisContext(DbContextOptions<SatisContext> options) : base(options) { }

        public DbSet<Building> Buildings { get; set; }
        public DbSet<Input> Inputs { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Output> Outputs { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
    }
}
