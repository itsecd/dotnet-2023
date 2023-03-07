using DotNet2023.DataModel.Organization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNet2023.DataBase.EntityTypeConfigurations.OrganizationConfiguration;
public class OrganizationConfiguration : IEntityTypeConfiguration<Organization>
{
    public void Configure(EntityTypeBuilder<Organization> builder)
    {
        builder.HasKey(x => x.Id);
        builder
            .Property(x => x.Phone)
            .HasMaxLength(15);
        builder
            .Property(x => x.Email)
            .HasMaxLength(63);
        builder
            .Property(x => x.FullName)
            .HasMaxLength(127);
        builder
            .Property(x => x.LegalAddress)
            .HasMaxLength(127);
        builder
            .Property(x => x.Initials)
            .HasMaxLength(63);
        builder
            .Property(x => x.RegistrationNumber)
            .HasMaxLength(63);
    }
}
