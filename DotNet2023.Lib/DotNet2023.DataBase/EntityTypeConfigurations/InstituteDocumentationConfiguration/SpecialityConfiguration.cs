using DotNet2023.DataModel.InstituteDocumentation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNet2023.DataBase.EntityTypeConfigurations.InstituteDocumentationConfiguration;
public class SpecialityConfiguration : IEntityTypeConfiguration<Speciality>
{
    public void Configure(EntityTypeBuilder<Speciality> builder)
    {
        builder
            .HasKey(x => x.Code);
        builder
            .Property(x => x.Title)
            .HasMaxLength(127);
    }
}
