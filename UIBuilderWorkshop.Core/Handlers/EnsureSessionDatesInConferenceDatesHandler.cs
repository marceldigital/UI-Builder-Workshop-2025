using Umbraco.Cms.Core.Events;
using Umbraco.UIBuilder.Events;
using Umbraco.UIBuilder.Persistence;
using UIBuilderWorkshop.Data.Models;

namespace UIBuilderWorkshop.Core.Handlers;

/// <summary>
/// Handles the validation to ensure that session dates are within the parent conference's date range
/// when saving a <see cref="Session"/> entity.
/// </summary>
internal class EnsureSessionDatesInConferenceDatesHandler : INotificationHandler<EntitySavingNotification>
{
    private readonly IRepositoryFactory _repositoryFactory;

    /// <summary>
    /// Initializes a new instance of the <see cref="EnsureSessionDatesInConferenceDatesHandler"/> class.
    /// </summary>
    /// <param name="repositoryFactory">The repository factory used to access data repositories.</param>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="repositoryFactory"/> is null.</exception>
    public EnsureSessionDatesInConferenceDatesHandler(IRepositoryFactory repositoryFactory)
    {
        _repositoryFactory = repositoryFactory ?? throw new ArgumentNullException(nameof(repositoryFactory));
    }

    /// <summary>
    /// Handles the <see cref="EntitySavingNotification"/> event to validate session dates.
    /// Cancels the operation if the session's start or end time is outside the conference's date range.
    /// </summary>
    /// <param name="notification">The notification containing the entity being saved.</param>
    public void Handle(EntitySavingNotification notification)
    {
        // Only run for sessions
        if (notification.Entity.After is not Session session) return;

        // Get the parent Conference
        var conferenceRepository = _repositoryFactory.GetRepository<Conference, int>();
        var result = conferenceRepository.Get(session.ConferenceId);

        if (!result.Success)
        {
            notification.CancelOperation(new EventMessage("Data Error", "Unable to retrieve conference for session.", EventMessageType.Error));
        }

        var conference = result.Model;

        if (session.StartTime.Date < conference.StartDate || session.StartTime.Date > conference.EndDate || session.EndTime.Date > conference.EndDate)
        {
            notification.CancelOperation(new EventMessage("Validation Error", $"Ensure the start end end of the session are between the conference start and end dates {conference.StartDate:d} - {conference.EndDate:d}", EventMessageType.Error));
        }
    }
}
