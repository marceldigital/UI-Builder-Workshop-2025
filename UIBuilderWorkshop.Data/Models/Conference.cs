using NPoco;

namespace UIBuilderWorkshop.Data.Models;

/// <summary>
/// Represents a conference event with a name, description, and date range.
/// </summary>
[TableName(nameof(Conference))]
[PrimaryKey(nameof(Id), AutoIncrement = true)]
public class Conference : ModelBase
{
    /// <summary>
    /// Gets or sets the name of the conference.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Gets or sets the description of the conference.
    /// </summary>
    public required string Description { get; set; }

    /// <summary>
    /// Gets or sets the start date of the conference.
    /// </summary>
    public DateTime StartDate { get; set; }

    /// <summary>
    /// Gets or sets the end date of the conference.
    /// </summary>
    public DateTime EndDate { get; set; }
}
