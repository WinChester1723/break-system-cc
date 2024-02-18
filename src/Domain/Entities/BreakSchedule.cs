
using Domain.Common;

namespace Domain.Entities;

/// <summary>
/// 
/// </summary>
public class BreakSchedule : BaseAuditableEntity
{
    /// <summary>
    /// 
    /// </summary>
    public BreakSchedule()
    {
        this.BreakRequests = new HashSet<BreakRequest>();
    }

    /// <summary>
    /// 
    /// </summary>
    public DateTime ScheduleDate { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public ICollection<BreakRequest> BreakRequests { get; set; }
}