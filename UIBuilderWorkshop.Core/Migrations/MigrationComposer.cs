using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Core.Notifications;

namespace UIBuilderWorkshop.Core.Migrations;

/// <summary>
/// Registers the <see cref="RunDataMigration"/> handler to execute data migrations
/// when the Umbraco application is starting.
/// </summary>
public class MigrationComposer : IComposer
{
    /// <summary>
    /// Composes Umbraco services by adding the <see cref="RunDataMigration"/> notification handler.
    /// </summary>
    /// <param name="builder">The Umbraco builder.</param>
    public void Compose(IUmbracoBuilder builder)
    {
        builder.AddNotificationAsyncHandler<UmbracoApplicationStartingNotification, RunDataMigration>();
    }
}
