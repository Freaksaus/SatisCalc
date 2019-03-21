using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    public class SatisContext : DbContext
    {
        public SatisContext(DbContextOptions<SatisContext> options) : base(options) { }

        public DbSet<Item> Items { get; set; }
    }
}
