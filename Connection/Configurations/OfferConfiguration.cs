using App.Domain.Core.Sangaghak.Entities.Requests;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Connection.Configurations
{
    public class OfferConfiguration : IEntityTypeConfiguration<Offer>
    {
        public void Configure(EntityTypeBuilder<Offer> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Expert)
                .WithMany(x => x.Offer)
                .HasForeignKey(x => x.ExpertId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Request)
                .WithMany(x => x.Offers)
                .HasForeignKey(x => x.RequestId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
