using CleanCodeArchitectureDemo.Domain.Modelling.Models.DbEntities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeArchitectureDemo.Db.EFCore.EntityConfigurations
{
    public class CustomerContactEntityConfig : BaseEntityConfigFor<CustomerContactEntity>
    {
        public override void Configure(EntityTypeBuilder<CustomerContactEntity> builder)
        {
            base.Configure(builder);

            builder.Property(c => c.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(c => c.LastName).IsRequired().HasMaxLength(50);
            builder.Property(c => c.Address).IsRequired().HasMaxLength(500);
            builder.Property(c => c.ContactNumber).IsRequired().HasMaxLength(25);

            builder.HasOne(c => c.Customer)
                   .WithMany(c => c.Contacts)
                   .HasForeignKey(c => c.CustomerId)
                   .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);
        }
    }
}
