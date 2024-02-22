namespace Infrastructure.Data.Configurations;

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

/// <summary>
/// Configuration for the BreakRequest entity.
/// </summary>
public class BreakRequestConfiguration : IEntityTypeConfiguration<BreakRequest>
{
    /// <summary>
    /// Configures the entity of type BreakRequest.
    /// </summary>
    /// <param name="builder">Provides a simple API for configuring the entity.</param>
    public void Configure(EntityTypeBuilder<BreakRequest> builder)
    {
        builder.HasKey(k => k.Id);

        builder.Property(br => br.RequestTime).IsRequired();
        builder.Property(br => br.Duration).IsRequired();
        builder.Property(br => br.Status).IsRequired();

        builder.HasOne(e => e.Employee)
            .WithMany(e => e.BreakRequests)
            .HasForeignKey(e => e.EmployeeId);

        builder.HasOne(br => br.BreakSchedule)
            .WithMany(bs => bs.BreakRequests)
            .HasForeignKey(br => br.BreakScheduleId);
    }
}
