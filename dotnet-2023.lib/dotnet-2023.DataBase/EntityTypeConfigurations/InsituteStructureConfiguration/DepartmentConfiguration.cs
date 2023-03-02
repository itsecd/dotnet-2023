using dotnet_2023.DataModel.InstitutionStructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dotnet_2023.DataBase.EntityTypeConfigurations.InsituteStructureConfiguration;
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
