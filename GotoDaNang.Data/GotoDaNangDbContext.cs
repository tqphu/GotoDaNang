using GotoDaNang.Model.Model;
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

        protected override void OnModelCreating(DbModelBuilder builder)
        {

        }
    }
}
