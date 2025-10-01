using System.ComponentModel.DataAnnotations;
using UIBuilderWorkshop.Data.Models;

namespace UIBuilderWorkshop.Core.Validators;

/// <summary>
/// Defines a contract for validating business rules on entities of type <typeparamref name="TEntityType"/>.
/// </summary>
/// <typeparam name="TEntityType">
/// The type of entity to validate. Must inherit from <see cref="ModelBase"/>.
/// </typeparam>
internal interface IBusinessRuleValidator<TEntityType> where TEntityType : ModelBase
{
    /// <summary>
    /// Validates the specified entity against business rules.
    /// </summary>
    /// <param name="entity">The entity to validate.</param>
    /// <returns>
    /// An <see cref="ValidationResult"/> indicating the result of the validation,
    /// including any validation messages.
    /// </returns>
    ValidationResult Validate(TEntityType entity);
}
