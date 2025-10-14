using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.Sangaghak.Entities.Requests;
using App.Domain.Core.Sangaghak.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Connection.Configurations
{
    public class RequestConfiguration : IEntityTypeConfiguration<Request>
    {
        public void Configure(EntityTypeBuilder<Request> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Customer)
                .WithMany(x => x.Requests)  
                .HasForeignKey(x => x.CustomerId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.City)
                .WithMany(x => x.Requests)
                .HasForeignKey(x => x.CityId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.AcceptedOffer)
                .WithOne(x => x.AcceptedRequest)
                .HasForeignKey<Request>(x => x.AcceptedOfferId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.ServicePackage)
                .WithMany(x => x.Requests)
                .HasForeignKey(x => x.ServicePackageId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasIndex(x => x.ServicePackageId);
        }
    }
}