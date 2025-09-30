using UIBuilderWorkshop.Data.Mocks;
using Umbraco.Cms.Infrastructure.Migrations;

namespace UIBuilderWorkshop.Core.Migrations;

/// <summary>
/// Migration step to insert initial data into the domain model tables.
/// </summary>
public class AddModelData : AsyncMigrationBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AddModelData"/> class.
    /// </summary>
    /// <param name="context">The migration context.</param>
    public AddModelData(IMigrationContext context) : base (context)
    {
    }

    /// <summary>
    /// Executes the migration to insert bulk mock data into the tables.
    /// </summary>
    /// <returns>A task representing the asynchronous operation.</returns>
    protected override async Task MigrateAsync()
    {
        await Database.InsertBulkAsync(MockData.Conferences);
        await Database.InsertBulkAsync(MockData.Speakers);
        await Database.InsertBulkAsync(MockData.Sessions);
        await Database.InsertBulkAsync(MockData.SessionSpeakers);
    }
}
