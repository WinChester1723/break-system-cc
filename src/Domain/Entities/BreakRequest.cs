
namespace Domain.Entities;

using Domain.Common;
using Domain.Enums;

/// <summary>
/// 
/// </summary>
public class BreakRequest : BaseAuditableEntity
{
    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public DateTime RequestTime { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public TimeSpan Duration { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public BreakRequestStatus Status { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public string? EmployeeId { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public Employee? Employee { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public string? BreakScheduleId { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public BreakSchedule? BreakSchedule { get; set; }

}