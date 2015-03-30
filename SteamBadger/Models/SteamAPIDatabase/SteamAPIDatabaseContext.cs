using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace SteamBadger.Models.SteamAPIDatabase {
    public class SteamAPIDatabaseContext : DbContext {
        public SteamAPIDatabaseContext() : base("name=SteamAPIDatabase")
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    
        public DbSet<Achievement> Achievments { get; set; }
        public DbSet<SteamApp> SteamApps { get; set; }
    }
}