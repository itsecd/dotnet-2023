using dotnet_2023.DataModel.InstitutionStructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dotnet_2023.DataBase.EntityTypeConfigurations.InsituteStructureConfiguration;
public class GroupOfStudentsConfiguration : BaseSectionConfiguration, IEntityTypeConfiguration<GroupOfStudents>
{
    public void Configure(EntityTypeBuilder<GroupOfStudents> builder)
    {
        builder
            .HasMany(x => x.Students)
            .WithOne(x => x.Group)
            .HasForeignKey(x => x.IdGroup);
         
    }
}
