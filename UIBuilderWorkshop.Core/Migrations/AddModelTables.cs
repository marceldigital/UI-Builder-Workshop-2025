using UIBuilderWorkshop.Data.Models;
using Umbraco.Cms.Infrastructure.Migrations;

namespace UIBuilderWorkshop.Core.Migrations;

/// <summary>
/// Migration step to create the database tables for the domain models.
/// </summary>
public class AddModelTables : AsyncMigrationBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AddModelTables"/> class.
    /// </summary>
    /// <param name="context">The migration context.</param>
    public AddModelTables(IMigrationContext context) : base (context)
    {
    }

    /// <summary>
    /// Executes the migration to create tables if they do not already exist.
    /// </summary>
    /// <returns>A completed task.</returns>
    protected override Task MigrateAsync()
    {
        if (TableExists(nameof(Conference))) return Task.CompletedTask;

        Create.Table<Conference>().Do();
        Create.Table<Speaker>().Do();
        Create.Table<Session>().Do();
        Create.Table<SessionSpeaker>().Do();

        return Task.CompletedTask;
    }
}
