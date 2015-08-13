using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Review.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace Review.DAL
{
    public class AppContext : DbContext
    {
        public AppContext() : base("AppContext")
        {

        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Itemreview> Itemreviews { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Item>()
             .HasMany(c => c.Itemreviews);
        }
    }
}