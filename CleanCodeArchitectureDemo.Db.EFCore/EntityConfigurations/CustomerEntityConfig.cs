using CleanCodeArchitectureDemo.Domain.Modelling.Models.DbEntities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeArchitectureDemo.Db.EFCore.EntityConfigurations
{
    public class CustomerEntityConfig : BaseEntityConfigFor<CustomerEntity>
    {
        public override void Configure(EntityTypeBuilder<CustomerEntity> builder)
        {
            base.Configure(builder);

            builder.Property(c => c.CustomerName).IsRequired().HasMaxLength(100);

            builder.HasMany(c => c.Contacts)
                   .WithOne(cc => cc.Customer) 
                   .HasForeignKey(cc => cc.CustomerId)
                   .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);
        }
    }
}
