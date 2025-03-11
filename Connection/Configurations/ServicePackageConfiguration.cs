using App.Domain.Core.Sangaghak.Entities.ServicePackages;
using App.Domain.Core.Sangaghak.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Connection.Configurations
{
    public class ServicePackageConfiguration : IEntityTypeConfiguration<ServicePackage>
    {
        public void Configure(EntityTypeBuilder<ServicePackage> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.SubCategory)
                .WithMany(x => x.Packages)
                .HasForeignKey(x => x.SubCategoryId)
                .OnDelete(deleteBehavior: DeleteBehavior.NoAction);

            builder.HasMany(x => x.Requests)
                .WithOne(x => x.ServicePackage)
                .HasForeignKey(x => x.ServicePackageId)
                .OnDelete(deleteBehavior: DeleteBehavior.NoAction);
        }
    }
}
