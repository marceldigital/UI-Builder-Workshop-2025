using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Migrations;
using Umbraco.Cms.Core.Notifications;
using Umbraco.Cms.Core.Scoping;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Infrastructure.Migrations;
using Umbraco.Cms.Infrastructure.Migrations.Upgrade;

namespace UIBuilderWorkshop.Core.Migrations;

/// <summary>
/// Handles the <see cref="UmbracoApplicationStartingNotification"/> to run data migrations at application startup.
/// </summary>
public class RunDataMigration : INotificationAsyncHandler<UmbracoApplicationStartingNotification>
{
    private readonly IMigrationPlanExecutor _migrationPlanExecutor;
    private readonly ICoreScopeProvider _coreScopeProvider;
    private readonly IKeyValueService _keyValueService;
    private readonly IRuntimeState _runtimeState;

    /// <summary>
    /// Initializes a new instance of the <see cref="RunDataMigration"/> class.
    /// </summary>
    /// <param name="migrationPlanExecutor">The migration plan executor.</param>
    /// <param name="coreScopeProvider">The core scope provider.</param>
    /// <param name="keyValueService">The key value service.</param>
    /// <param name="runtimeState">The runtime state.</param>
    public RunDataMigration(
        IMigrationPlanExecutor migrationPlanExecutor,
        ICoreScopeProvider coreScopeProvider,
        IKeyValueService keyValueService,
        IRuntimeState runtimeState)
    {
        _migrationPlanExecutor = migrationPlanExecutor ?? throw new ArgumentNullException(nameof(migrationPlanExecutor));
        _coreScopeProvider = coreScopeProvider ?? throw new ArgumentNullException(nameof(coreScopeProvider));
        _keyValueService = keyValueService ?? throw new ArgumentNullException(nameof(keyValueService));
        _runtimeState = runtimeState ?? throw new ArgumentNullException(nameof(runtimeState));
    }

    /// <summary>
    /// Handles the notification to execute the migration plan if the runtime level is sufficient.
    /// </summary>
    /// <param name="notification">The application starting notification.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    public async Task HandleAsync(UmbracoApplicationStartingNotification notification, CancellationToken cancellationToken)
    {
        if (_runtimeState.Level < RuntimeLevel.Run)
        {
            return;
        }

        var migrationPlan = new MigrationPlan(nameof(RunDataMigration));

        migrationPlan.From(string.Empty)
            .To<AddModelTables>(nameof(AddModelTables))
            .To<AddModelData>(nameof(AddModelData));

        var upgrader = new Upgrader(migrationPlan);
        await upgrader.ExecuteAsync(_migrationPlanExecutor,
                                    _coreScopeProvider,
                                    _keyValueService);
    }
}
