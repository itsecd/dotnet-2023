using dotnet_2023.DataModel.InstitutionStructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dotnet_2023.DataBase.EntityTypeConfigurations.InsituteStructureConfiguration;
public class FacultyConfiguration : BaseSectionConfiguration, IEntityTypeConfiguration<Faculty>
{
    public void Configure(EntityTypeBuilder<Faculty> builder)
    {
        builder
            .HasMany(x => x.Departments)
            .WithOne(x => x.Faculty)
            .HasForeignKey(x => x.IdFaculty);
    }
}
