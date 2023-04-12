using RentalService.Domain;

namespace DataBase.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class RefundInformationConfiguration : IEntityTypeConfiguration<RefundInformation>
{
    public void Configure(EntityTypeBuilder<RefundInformation> builder)
    {
        builder
            .HasKey(refundInformation => refundInformation.Id);
    }
}