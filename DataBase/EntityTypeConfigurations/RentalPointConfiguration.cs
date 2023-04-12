using RentalService.Domain;

namespace DataBase.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class RentalPointConfiguration : IEntityTypeConfiguration<RentalPoint>
{
    public void Configure(EntityTypeBuilder<RentalPoint> builder)
    {
        builder
            .HasKey(rentalPoint => rentalPoint.Id);
        builder.HasMany(rentalPoint => rentalPoint.RefundInformations)
            .WithOne(rentalPoint => rentalPoint.RentalPoint)
            .HasForeignKey(rentalPoint => rentalPoint.RentalPoint);
        builder.HasMany(rentalPoint => rentalPoint.RentalInformations)
            .WithOne(rentalPoint => rentalPoint.RentalPoint)
            .HasForeignKey(rentalPoint => rentalPoint.RentalPoint);
    }
}