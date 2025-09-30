using NPoco;
using Umbraco.Cms.Infrastructure.Persistence.DatabaseAnnotations;

namespace UIBuilderWorkshop.Data.Models;

/// <summary>
/// Represents the association between a session and a speaker.
/// </summary>
[TableName(nameof(SessionSpeaker))]
[PrimaryKey([nameof(SessionId), nameof(SpeakerId)])]
public class SessionSpeaker
{
    /// <summary>
    /// Gets or sets the session ID.
    /// </summary>
    [ForeignKey(typeof(Session))]
    public int SessionId { get; set; }

    /// <summary>
    /// Gets or sets the speaker ID.
    /// </summary>
    [ForeignKey(typeof(Speaker))]
    public int SpeakerId { get; set; }
}
