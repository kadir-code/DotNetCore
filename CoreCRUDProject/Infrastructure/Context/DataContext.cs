using CoreCRUDProject.Infrastructure.EntityTypeConfigurations.Concrete;
using CoreCRUDProject.Models.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCRUDProject.Infrastructure.Context
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<AppUser> AppUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AppUserMap());
            base.OnModelCreating(modelBuilder);
        }

    }
}
