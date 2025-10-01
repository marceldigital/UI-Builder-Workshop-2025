using System.ComponentModel.DataAnnotations;
using UIBuilderWorkshop.Data.Models;
using Umbraco.UIBuilder.Persistence;

namespace UIBuilderWorkshop.Core.Validators;

/// <summary>
/// Validates that a session's start time falls within the start and end dates of its parent conference.
/// </summary>
/// <remarks>
/// This validator ensures business rules are enforced so that sessions cannot be scheduled outside the conference duration.
/// </remarks>
internal class EnsureSessionStartInConferenceDatesValidator : IBusinessRuleValidator<Session>
{
    private readonly IRepositoryFactory _repositoryFactory;

    /// <summary>
    /// Initializes a new instance of the <see cref="EnsureSessionStartInConferenceDatesValidator"/> class.
    /// </summary>
    /// <param name="repositoryFactory">The repository factory used to access conference data.</param>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="repositoryFactory"/> is null.</exception>
    public EnsureSessionStartInConferenceDatesValidator(IRepositoryFactory repositoryFactory)
    {
        _repositoryFactory = repositoryFactory ?? throw new ArgumentNullException(nameof(repositoryFactory));
    }

    /// <summary>
    /// Validates that the session's start time is within the parent conference's start and end dates.
    /// </summary>
    /// <param name="session">The session entity to validate.</param>
    /// <returns>
    /// A <see cref="ValidationResult"/> indicating success if the session's start time is valid;
    /// otherwise, a result with an error message.
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

        if (session.StartTime.Date < conference.StartDate || session.StartTime.Date > conference.EndDate)
        {
            return new ValidationResult(
                $"Ensure the start of the session is between the conference start and end dates {conference.StartDate:d} - {conference.EndDate:d}",
                [nameof(session.StartTime)]
            );
        }

        return ValidationResult.Success;
    }
}
