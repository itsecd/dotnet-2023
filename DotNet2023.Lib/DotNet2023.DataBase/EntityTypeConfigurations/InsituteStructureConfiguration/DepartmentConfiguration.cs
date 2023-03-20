using DotNet2023.Domain.InstitutionStructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNet2023.DataBase.EntityTypeConfigurations.InsituteStructureConfiguration;
public class DepartmentConfiguration : BaseSectionConfiguration, IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder
            .HasMany(x => x.GroupOfStudents)
            .WithOne(x => x.Department)
            .HasForeignKey(x => x.IdDepartment);
    }
}
