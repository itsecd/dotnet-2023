using dotnet_2023.DataModel.Person;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dotnet_2023.DataBase.EntityTypeConfigurations.PersonConfiguration;
public class PersonConfiguration : IEntityTypeConfiguration<BasePerson>
{
    public void Configure(EntityTypeBuilder<BasePerson> builder)
    {
        builder
            .HasKey(x => x.Id);
        builder
            .Property(x => x.Id)
            .IsRequired();
        builder
            .Property(x => x.Name)
            .HasMaxLength(63);
        builder
            .Property(x => x.Surname)
            .HasMaxLength(63);
        builder
            .Property(x => x.Patronymic)
            .HasMaxLength(63);
        builder
            .Property(x => x.Phone)
            .HasMaxLength(15);
        builder
            .Property(x => x.Email)
            .HasMaxLength(63);
    }
}
