using GotoDaNang.Model.Model;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GotoDaNang.Data
{
    public class GotoDaNangDbContext : DbContext
    {
        public GotoDaNangDbContext() : base("GotoDaNangConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Admin> Admins { set; get; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Error> Errors { get; set; }

        public static GotoDaNangDbContext Create()
        {
            return new GotoDaNangDbContext();
        }
        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Entity<IdentityUserRole>().HasKey(i => new { i.UserId, i.RoleId });
            builder.Entity<IdentityUserLogin>().HasKey(i => i.UserId);
        }
    }
}
