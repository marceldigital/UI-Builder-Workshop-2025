using System.ComponentModel.DataAnnotations;
using UIBuilderWorkshop.Data.Models;

namespace UIBuilderWorkshop.Core.Validators;

/// <summary>
/// Validates that the <see cref="Conference.StartDate"/> is on or before the <see cref="Conference.EndDate"/>.
/// </summary>
internal class EnsureConferenceStartDateBeforeEndValidator : IBusinessRuleValidator<Conference>
{
    /// <summary>
    /// Validates that the start date of the specified <paramref name="entity"/> is not after its end date.
    /// </summary>
    /// <param name="entity">The <see cref="Conference"/> entity to validate.</param>
    /// <returns>
    /// <see cref="ValidationResult.Success"/> if the start date is on or before the end date;
    /// otherwise, a <see cref="ValidationResult"/> with an error message.
    /// </returns>
    public ValidationResult Validate(Conference entity)
    {
        return entity.StartDate <= entity.EndDate
            ? ValidationResult.Success
            : new ValidationResult("The conference start date must be on or before the end date.", [nameof(entity.StartDate)]);
    }
}
