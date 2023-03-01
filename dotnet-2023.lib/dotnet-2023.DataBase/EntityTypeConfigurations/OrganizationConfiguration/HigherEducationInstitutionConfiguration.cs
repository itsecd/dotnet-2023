using dotnet_2023.DataModel.Organization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dotnet_2023.DataBase.EntityTypeConfigurations.OrganizationConfiguration;
public class HigherEducationInstitutionConfiguration : IEntityTypeConfiguration<HigherEducationInstitution>
{
    public void Configure(EntityTypeBuilder<HigherEducationInstitution> builder)
    {
        builder
            .HasKey(x => x.Id);
        builder
            .HasMany(x => x.Faculties)
            .WithOne(x => x.Institute)
            .HasForeignKey(x => x.IdInstitute);
        builder
            .HasMany(x => x.Departments)
            .WithOne(x => x.Institute)
            .HasForeignKey(x => x.IdInstitute);
        builder
            .Property(x => x.IdRector)
            .HasMaxLength(127);
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
