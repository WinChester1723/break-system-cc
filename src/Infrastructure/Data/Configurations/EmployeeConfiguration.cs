namespace Infrastructure.Data.Configurations;

using Domain.Entities;
using Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

/// <summary>
/// Configuration class for the Employee entity to define database schema details using Fluent API.
/// </summary>
public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    /// <summary>
    /// Configures the Employee entity.
    /// </summary>
    /// <param name="builder">Provides a simple API for configuring an EntityType.</param>
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasKey(e => e.Id);

        // Configure a one-to-one relationship between ApplicationUser and Employee.
        builder.HasOne<ApplicationUser>()
            .WithOne()
            .HasForeignKey<Employee>(e => e.UserId)
            .IsRequired() // Make the foreign key as required.
            .OnDelete(DeleteBehavior.Cascade); // Configure cascade delete.

        // Ensure the Name property is required.
        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(50); ;
    }
}
