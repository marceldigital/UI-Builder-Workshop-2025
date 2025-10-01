using UIBuilderWorkshop.Data.Models;
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Security;
using Umbraco.UIBuilder.Events;

namespace UIBuilderWorkshop.Core.Handlers;

/// <summary>
/// Handles the <see cref="EntitySavingNotification"/> to set the <c>CreatedBy</c> property
/// on entities derived from <see cref="ModelBase"/> when they are created.
/// </summary>
internal class AddCreatedByOnSaveHandler : INotificationHandler<EntitySavingNotification>
{
    private readonly IBackOfficeSecurityAccessor _securityAccessor;

    /// <summary>
    /// Initializes a new instance of the <see cref="AddCreatedByOnSaveHandler"/> class.
    /// </summary>
    /// <param name="securityAccessor">Provides access to the current back office security context.</param>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="securityAccessor"/> is <c>null</c>.</exception>
    public AddCreatedByOnSaveHandler(IBackOfficeSecurityAccessor securityAccessor)
    {
        _securityAccessor = securityAccessor ?? throw new ArgumentNullException(nameof(securityAccessor));
    }

    /// <summary>
    /// Handles the entity saving notification. If the entity is being created and is of type <see cref="ModelBase"/>,
    /// sets its <c>CreatedBy</c> property to the current user's key.
    /// </summary>
    /// <param name="notification">The notification containing the entity being saved.</param>
    public void Handle(EntitySavingNotification notification)
    {
        // Only do this on create which we can check by seeing if there is a before state
        if (notification.Entity.Before is not null) return;

        // Only do this for entities which are of our base type
        if (notification.Entity.After is not ModelBase modelBase) return;

        var user = _securityAccessor.BackOfficeSecurity?.CurrentUser;
        if (user is null || user.Key == Guid.Empty)
            return;

        modelBase.CreatedBy = user.Key;
    }
}
