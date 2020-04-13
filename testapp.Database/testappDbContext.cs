using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using testapp.Core;

namespace testapp.Database
{
    public class testappDbContext : DbContext
    {
        public testappDbContext(DbContextOptions<testappDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Core.Attribute> Attributes { get; set; }
        public DbSet<ProductAttributes> ProductAttributes { get; set; }
    }
}
