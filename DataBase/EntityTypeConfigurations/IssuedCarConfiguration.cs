using RentalService.Domain;

namespace DataBase.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class IssuedCarConfiguration : IEntityTypeConfiguration<IssuedCar>
{
    public void Configure(EntityTypeBuilder<IssuedCar> builder)
    {
        builder
            .HasKey(issuedCar => issuedCar.Id);
    }
}