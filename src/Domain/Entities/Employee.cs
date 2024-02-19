
namespace Domain.Entities;

using Domain.Common;

/// <summary>
/// Represent an employee entity.
/// </summary>
public class Employee : BaseAuditableEntity
{
    /// <summary>
    /// 
    /// </summary>
    public Employee()
    {
        this.BreakRequests = new HashSet<BreakRequest>();
    }

    /// <summary>
    /// Gets or sets the user identifier associated with the employee.
    /// </summary>
    public required string UserId { get; set; }

    /// <summary>
    /// Get or set Name of employee.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Get or set Role of employee.
    /// </summary>
    /// <value></value>
    public string? Role { get; set; }

    /// <summary>
    /// Gets or sets employee's manager identifier.
    /// </summary>
    public string? ManagerId { get; set; }

    /// <summary>
    /// Gets or sets employee's manager.
    /// </summary>
    public Employee? Manager { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public ICollection<BreakRequest> BreakRequests { get; set; }
}
