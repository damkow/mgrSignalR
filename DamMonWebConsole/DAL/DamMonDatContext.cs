using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using DamMonWebConsole.Models;

namespace DamMonWebConsole.DAL
{
    public class DamMonDatContext : DbContext
    {
        public DamMonDatContext() : base("DamMonDatContext") { }

        public DbSet<Pomiar> Pomiary { get; set; }
        public DbSet<Serwer> Serwery { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}