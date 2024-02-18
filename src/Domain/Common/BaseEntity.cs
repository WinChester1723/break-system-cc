
namespace Domain.Common;


/// <summary>
///  Represents a base entity with a generic identifier.
/// </summary>
public abstract class BaseEntity
{
    /// <summary>
    /// Gets or sets the entity identifier.
    /// </summary>
    public string Id { get; set; } = Guid.NewGuid().ToString();

}