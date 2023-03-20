using DotNet2023.Domain.Person;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNet2023.DataBase.EntityTypeConfigurations.PersonConfiguration;
public class EducationWorkerConfiguration : PersonConfiguration, IEntityTypeConfiguration<EducationWorker>
{
    public void Configure(EntityTypeBuilder<EducationWorker> builder)
    {
        builder
            .Property(x => x.Rank)
            .HasMaxLength(127);
        builder
            .Property(x => x.ScienceDegree)
            .HasMaxLength(127);
        builder
            .Property(x => x.JobTitle)
            .HasMaxLength(127);
    }
}
