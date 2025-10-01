using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.DataAnnotations;
using UIBuilderWorkshop.Core.Validators;
using UIBuilderWorkshop.Data.Models;
using Umbraco.Cms.Core.Events;
using Umbraco.UIBuilder.Events;

namespace UIBuilderWorkshop.Core.Handlers;

/// <summary>
/// Handles business rule validation for entities during the saving process.
/// </summary>
internal class BusinessRuleHandler : INotificationHandler<EntitySavingNotification>
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    /// <summary>
    /// Initializes a new instance of the <see cref="BusinessRuleHandler"/> class.
    /// </summary>
    /// <param name="httpContextAccessor">The HTTP context accessor used to retrieve request services.</param>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="httpContextAccessor"/> is null.</exception>
    public BusinessRuleHandler(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
    }

    /// <summary>
    /// Handles the <see cref="EntitySavingNotification"/> by validating business rules for the entity being saved.
    /// Cancels the operation if any business rule validation fails.
    /// </summary>
    /// <param name="notification">The notification containing the entity to validate.</param>
    public void Handle(EntitySavingNotification notification)
    {
        if (notification.Entity.After is not ModelBase) return;

        var entityType = notification.Entity.After.GetType();

        var serviceProvider = _httpContextAccessor.HttpContext?.RequestServices;
        if (serviceProvider is null) return;

        var entityCreateServiceType = typeof(IBusinessRuleValidator<>).MakeGenericType(entityType);
        var entityCreateServices = serviceProvider.GetServices(entityCreateServiceType);

        var validationErrorResults = new List<ValidationResult>();
        foreach (var service in entityCreateServices)
        {
            if (service is null) continue;

            var validateMethod = service.GetType().GetMethod("Validate");
            if (validateMethod != null)
            {
                var result = (ValidationResult)validateMethod.Invoke(service, [notification.Entity.After]);
                if (result != ValidationResult.Success)
                {
                    notification.CancelOperation(new EventMessage("ValidationError", result.ErrorMessage, EventMessageType.Error));
                    return;
                }
            }
        }
    }
}
