using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Umbraco.UIBuilder.Configuration;
using Umbraco.UIBuilder.Services;
using Umbraco.UIBuilder.Web.Api.Management.Controllers.Entity;
using Umbraco.UIBuilder.Web.Models;

namespace UIBuilderWorkshop.Core.ActionFilters;

/// <summary>
///     Action filter which takes outputs which are of type <see cref="EntityEditModel"/> to swap out
///     the plural name for the formatted entity name which displays in the UI.
/// </summary>
internal class ModifyEntityEditModelNameActionFilter : IActionFilter
{
    private readonly UIBuilderConfig _uiBuilderConfig;
    private readonly EntityService _entityService;

    public ModifyEntityEditModelNameActionFilter(UIBuilderConfig uiBuilderConfig, EntityService entityService)
    {
        _uiBuilderConfig = uiBuilderConfig ?? throw new ArgumentNullException(nameof(uiBuilderConfig));
        _entityService = entityService ?? throw new ArgumentNullException(nameof(entityService));
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        // No changes needed before action executes
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        if (IsExpectedControllerAndAction(context)
            && context.Result is ObjectResult objectResult
            && objectResult.Value is EntityEditModel entityEditModel)
        {

            // Don't make the swap if there is a name property configured for the entity
            if (!entityEditModel.HasNameProperty)
            {
                var formattedName = GetFormattedName(context);

                if (!string.IsNullOrWhiteSpace(formattedName))
                {
                    entityEditModel.Name = formattedName;
                }
            }
        }
    }

    /// <summary>
    ///     Checks if the current action is the expected one for this filter.
    /// </summary>
    private bool IsExpectedControllerAndAction(ActionExecutedContext context)
        => context.Controller is GetByIdController
            && context.ActionDescriptor is ControllerActionDescriptor actionDescriptor
            && actionDescriptor.ActionName == nameof(GetByIdController.GetById);

    /// <summary>
    ///     Gets the formatted name for the entity based on the collection alias and id from the route data.
    /// </summary>
    private string GetFormattedName(ActionExecutedContext context)
    {
        var collectionAlias = context.RouteData.Values["collectionAlias"]!.ToString()!;
        var id = context.RouteData.Values["id"]!.ToString()!;

        var collection = _uiBuilderConfig.Collections[collectionAlias]
            ?? throw new ApplicationException($"Collection '{collectionAlias}' not found in UIBuilderConfig.");

        if (collection.NameFormat is null) return string.Empty;

        var entities = _entityService.GetEntitiesByIds(collection, [id]);
        var entity = entities.FirstOrDefault();

        return entity is null ? string.Empty : collection.NameFormat(entity);
    }
}
