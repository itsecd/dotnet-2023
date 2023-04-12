using RentalService.Domain;

namespace DataBase.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder
            .HasKey(client => client.Id);
        builder.HasMany(client => client.RentedCars)
            .WithOne(client => client.Client)
            .HasForeignKey(client => client.ClientId);
        builder
            .Property(client => client.LastName)
            .HasMaxLength(50);
        builder
            .Property(client => client.FirstName)
            .HasMaxLength(50);
        builder
            .Property(client => client.Patronymic)
            .HasMaxLength(50);
        builder
            .Property(client => client.Passport)
            .HasMaxLength(50);
    }
}