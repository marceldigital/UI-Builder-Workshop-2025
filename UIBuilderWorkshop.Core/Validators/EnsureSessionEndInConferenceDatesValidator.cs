using System.ComponentModel.DataAnnotations;
using UIBuilderWorkshop.Data.Models;
using Umbraco.UIBuilder.Persistence;

namespace UIBuilderWorkshop.Core.Validators;

/// <summary>
/// Validates that the end time of a session falls within the start and end dates of its parent conference.
/// </summary>
internal class EnsureSessionEndInConferenceDatesValidator : IBusinessRuleValidator<Session>
{
    private readonly IRepositoryFactory _repositoryFactory;

    /// <summary>
    /// Initializes a new instance of the <see cref="EnsureSessionEndInConferenceDatesValidator"/> class.
    /// </summary>
    /// <param name="repositoryFactory">The repository factory used to access conference data.</param>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="repositoryFactory"/> is null.</exception>
    public EnsureSessionEndInConferenceDatesValidator(IRepositoryFactory repositoryFactory)
    {
        _repositoryFactory = repositoryFactory ?? throw new ArgumentNullException(nameof(repositoryFactory));
    }

    /// <summary>
    /// Validates that the session's end time is within the conference's start and end dates.
    /// </summary>
    /// <param name="session">The session to validate.</param>
    /// <returns>
    /// A <see cref="ValidationResult"/> indicating success if the session's end time is valid,
    /// or an error message if it is outside the conference's date range.
    /// </returns>
    public ValidationResult Validate(Session session)
    {
        // Get the parent Conference
        var conferenceRepository = _repositoryFactory.GetRepository<Conference, int>();
        var result = conferenceRepository.Get(session.ConferenceId);

        if (!result.Success)
        {
            return new ValidationResult("Unable to retrieve conference for session.", [nameof(session.ConferenceId)]);
        }

        var conference = result.Model;

        if (session.EndTime.Date < conference.StartDate || session.EndTime.Date > conference.EndDate)
        {
            return new ValidationResult(
                $"Ensure the end of the session is between the conference start and end dates {conference.StartDate:d} - {conference.EndDate:d}",
                [nameof(session.EndTime)]);
        }

        return ValidationResult.Success;
    }
}
