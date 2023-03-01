using dotnet_2023.DataModel.Person;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dotnet_2023.DataBase.EntityTypeConfigurations.PersonConfiguration;
public class StudentConfiguration : PersonConfiguration, IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder
            .Property(x => x.IdSpeciality)
            .HasMaxLength(127);
    }
}
