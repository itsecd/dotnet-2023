using RentalService.Domain;

namespace DataBase.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class RentalInformationConfiguration : IEntityTypeConfiguration<RentalInformation>
{
    public void Configure(EntityTypeBuilder<RentalInformation> builder)
    {
        builder
            .HasKey(rentalInformation => rentalInformation.Id);
    }
}