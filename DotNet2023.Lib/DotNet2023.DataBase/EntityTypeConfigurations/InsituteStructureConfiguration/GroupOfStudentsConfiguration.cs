using DotNet2023.Domain.InstitutionStructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNet2023.DataBase.EntityTypeConfigurations.InsituteStructureConfiguration;
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
