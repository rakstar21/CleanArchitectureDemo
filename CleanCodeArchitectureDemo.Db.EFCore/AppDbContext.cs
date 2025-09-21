using CleanCodeArchitectureDemo.Db.EFCore.EntityConfigurations;
using CleanCodeArchitectureDemo.Domain.Modelling.Models.DbEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeArchitectureDemo.Db.EFCore
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(ConnectionSettings connectionSettings, bool isReadOnly)
        {
            string connectionString = string.Empty;
            if (string.IsNullOrEmpty(connectionSettings.UserName) || string.IsNullOrEmpty(connectionSettings.Password))
            {
                connectionString = $"Server={connectionSettings.ServerName};Database={connectionSettings.DataBase};Integrated Security=SSPI;";
            }
            else 
            {
                connectionString = $"Server={connectionSettings.ServerName};Database={connectionSettings.DataBase};User Id={ connectionSettings.UserName };Password={ connectionSettings.Password }";
            }

            if (isReadOnly) connectionString += "ApplicationIntent=ReadOnly;";

            this.OnConfiguring(new DbContextOptionsBuilder().UseSqlServer(connectionString));
        }
        public DbSet<CustomerEntity> Customers { get; set; }
        public DbSet<CustomerContactEntity> CustomerContacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerContactEntityConfig());
            modelBuilder.ApplyConfiguration(new CustomerContactEntityConfig());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
