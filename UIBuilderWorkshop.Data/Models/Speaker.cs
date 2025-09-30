using NPoco;
using Umbraco.Cms.Infrastructure.Persistence.DatabaseAnnotations;

namespace UIBuilderWorkshop.Data.Models;

/// <summary>
/// Represents a speaker at a conference session, including personal and professional details.
/// </summary>
[TableName(nameof(Speaker))]
[PrimaryKey(nameof(Id), AutoIncrement = true)]
public class Speaker : ModelBase
{
    /// <summary>
    /// Gets or sets the first name of the speaker.
    /// </summary>
    public required string FirstName { get; set; }

    /// <summary>
    /// Gets or sets the last name of the speaker.
    /// </summary>
    public required string LastName { get; set; }

    /// <summary>
    /// Gets or sets the biography of the speaker.
    /// </summary>
    public required string Bio { get; set; }

    /// <summary>
    /// Gets or sets the company the speaker represents.
    /// </summary>
    public required string Company { get; set; }

    /// <summary>
    /// Gets or sets the Twitter handle of the speaker.
    /// </summary>
    [NullSetting(NullSetting = NullSettings.Null)]
    public string? TwitterHandle { get; set; }
}