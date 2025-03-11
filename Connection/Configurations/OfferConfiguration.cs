using App.Domain.Core.Sangaghak.Entities.Requests;
using App.Domain.Core.Sangaghak.Enum;
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



            //builder.HasData(new Offer()
            //{
            //    Id = 1,
            //    ExpertId = 1,
            //    RequestId = 1,
            //    OfferedPrice = 1,
            //    Description = "من از در سریع ترین زمان ممکن برای شما این کار را انجام میدهدم",
            //    Status=OfferStatusEnum.Pending,
            //    OfferedTime = DateTime.Parse("2025-04-10"),
            //    SetAt = DateTime.Parse("2024-09-01")
            //});
        }
    }
}
