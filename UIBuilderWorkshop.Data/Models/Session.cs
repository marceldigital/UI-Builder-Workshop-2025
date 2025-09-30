using NPoco;
using Umbraco.Cms.Infrastructure.Persistence.DatabaseAnnotations;

namespace UIBuilderWorkshop.Data.Models;

/// <summary>
/// Represents a session within a conference, including its title, description, speaker, and schedule.
/// </summary>
[TableName(nameof(Session))]
[PrimaryKey(nameof(Id), AutoIncrement = true)]
public class Session : ModelBase
{
    /// <summary>
    /// Gets or sets the title of the session.
    /// </summary>
    public required string Title { get; set; }

    /// <summary>
    /// Gets or sets the description of the session.
    /// </summary>
    public required string Description { get; set; }

    /// <summary>
    /// Gets or sets the start time of the session.
    /// </summary>
    public DateTime StartTime { get; set; }

    /// <summary>
    /// Gets or sets the end time of the session.
    /// </summary>
    public DateTime EndTime { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier for the conference.
    /// </summary>
    [ForeignKey(typeof(Conference))]
    public int ConferenceId { get; set; }
}
