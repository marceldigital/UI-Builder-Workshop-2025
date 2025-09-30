using NPoco;
using Umbraco.Cms.Infrastructure.Persistence.DatabaseAnnotations;

namespace UIBuilderWorkshop.Data.Models;

/// <summary>
/// Represents the base class for all data models, providing common properties such as identity, audit, and soft delete support.
/// </summary>
public abstract class ModelBase
{
    /// <summary>
    /// Gets or sets the unique identifier for the model.
    /// </summary>
    [PrimaryKeyColumn]
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the model was created.
    /// </summary>
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Gets or sets the date and time when the model was last updated.
    /// </summary>
    public DateTime UpdatedOn { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Gets or sets a value indicating whether the model is soft deleted.
    /// </summary>
    public bool SoftDelete { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the user who created the model.
    /// </summary>
    [NullSetting(NullSetting = NullSettings.Null)]
    public Guid? CreatedBy { get; set; }
}
