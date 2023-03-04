using dotnet_2023.DataModel.InstituteDocumentation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dotnet_2023.DataBase.EntityTypeConfigurations.InstituteDocumentationConfiguration;
public class InstituteSpecialityConfiguration : IEntityTypeConfiguration<InstituteSpeciality>
{
    public void Configure(EntityTypeBuilder<InstituteSpeciality> builder)
    {
        builder
            .HasKey(x => x.Key);

        builder
            .HasOne(x => x.HigherEducationInstitution)
            .WithMany(x => x.Specialties)
            .HasForeignKey(x => x.IdHigherEducationInstitution);
        builder
            .HasOne(x => x.Speciality)
            .WithMany(x => x.Institutes)
            .HasForeignKey(x => x.IdSpeciality);
    }
}
