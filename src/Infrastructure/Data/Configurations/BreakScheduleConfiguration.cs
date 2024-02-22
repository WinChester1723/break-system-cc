namespace Infrastructure.Data.Configurations;

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

/// <summary>
/// Configuration for the BreakSchedule entity.
/// </summary>
public class BreakScheduleConfiguration : IEntityTypeConfiguration<BreakSchedule>
{
    /// <summary>
    /// Configures the entity of type BreakRequest.
    /// </summary>
    /// <param name="builder">Provides a simple API for configuring the entity.</param>
    public void Configure(EntityTypeBuilder<BreakSchedule> builder)
    {
        builder.HasKey(bs => bs.Id);

        builder.Property(bs => bs.ScheduleDate).IsRequired();

        builder.HasMany(bs => bs.BreakRequests)
            .WithOne(br => br.BreakSchedule)
            .HasForeignKey(br => br.BreakScheduleId);
    }
}
