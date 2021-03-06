﻿using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.AspNet.Identity.EntityFramework;
using MvcDataManager.Model;

namespace MvcUserManagement.data
{
    public class MvcUserManagementDbContext: IdentityDbContext<ApplicationUser>
    {
        public MvcUserManagementDbContext()
            : base("MvcUserManagementDbContext")
        {
            Database.SetInitializer<MvcUserManagementDbContext>(null);
            Configuration.LazyLoadingEnabled = true;
        }

        public DbSet<SecurityQuestion> SecurityQuestion { get; set; }
        public DbSet<Employee> Employee { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<IncludeMetadataConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
