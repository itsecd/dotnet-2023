using DotNet2023.DataModel.Organization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNet2023.DataBase.EntityTypeConfigurations.OrganizationConfiguration;
public class HigherEducationInstitutionConfiguration : OrganizationConfiguration, IEntityTypeConfiguration<HigherEducationInstitution>
{
    public void Configure(EntityTypeBuilder<HigherEducationInstitution> builder)
    {
        builder
            .HasMany(x => x.Faculties)
            .WithOne(x => x.Institute)
            .HasForeignKey(x => x.IdInstitute);
        builder
            .HasMany(x => x.Departments)
            .WithOne(x => x.Institute)
            .HasForeignKey(x => x.IdInstitute);
    }
}
