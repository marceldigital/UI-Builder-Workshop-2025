using Microsoft.Extensions.DependencyInjection;
using UIBuilderWorkshop.Core.ActionFilters;
using UIBuilderWorkshop.Core.Handlers;
using UIBuilderWorkshop.Core.Validators;
using UIBuilderWorkshop.Core.ValueMappers;
using UIBuilderWorkshop.Data.Enums;
using UIBuilderWorkshop.Data.Models;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.UIBuilder;
using Umbraco.UIBuilder.Events;
using Umbraco.UIBuilder.Extensions;

namespace UIBuilderWorkshop.Core.Configuration;

public static class UIBuilderExtensions
{
    public static IUmbracoBuilder AddWorkshopUIBuilder(this IUmbracoBuilder umbracoBuilder)
    {
        umbracoBuilder.AddNotificationHandler<EntitySavingNotification, AddCreatedByOnSaveHandler>();
        umbracoBuilder.AddNotificationHandler<EntitySavingNotification, BusinessRuleHandler>();

        umbracoBuilder.Services.AddSingleton<IBusinessRuleValidator<Conference>, EnsureConferenceStartDateBeforeEndValidator>();
        umbracoBuilder.Services.AddSingleton<IBusinessRuleValidator<Session>, EnsureSessionStartInConferenceDatesValidator>();
        umbracoBuilder.Services.AddSingleton<IBusinessRuleValidator<Session>, EnsureSessionEndInConferenceDatesValidator>();

        umbracoBuilder.Services.AddControllersWithViews(options => options.Filters.Add<ModifyEntityEditModelNameActionFilter>());

        umbracoBuilder.AddUIBuilder(configuration =>
        {
            configuration.AddSection("Conference Manager", sectionConfiguration =>
            {
                sectionConfiguration.Tree(treeConfiguration =>
                {
                    treeConfiguration.AddCollection<Conference>(x => x.Id,
                                                                "Conference",
                                                                "Conferences",
                                                                "A collection of conferences.",
                                                                "icon-company",
                                                                "icon-company",
                                                                collectionConfiguration =>
                                                                {
                                                                    collectionConfiguration.SetNameProperty(x => x.Name);

                                                                    // Define the default sorting
                                                                    collectionConfiguration.SetSortProperty(x => x.StartDate);

                                                                    // Define Data Views
                                                                    collectionConfiguration.AddDataView("Upcomming & Current", x => x.StartDate >= DateTime.Now.Date || DateTime.Now.Date <= x.EndDate);
                                                                    collectionConfiguration.AddAllDataView();

                                                                    // Define Searchable Properties
                                                                    collectionConfiguration.AddSearchableProperty(x => x.Name);
                                                                    collectionConfiguration.AddSearchableProperty(x => x.Description, SearchExpressionPattern.Contains);

                                                                    // Define the list view
                                                                    collectionConfiguration.ListView(listViewConfiguration =>
                                                                    {
                                                                        listViewConfiguration.AddField(x => x.StartDate).SetFormat(x => x.ToShortDateString());
                                                                        listViewConfiguration.AddField(x => x.EndDate).SetFormat(x => x.ToShortDateString());
                                                                        listViewConfiguration.AddField(x => x.Id).SetHeading("Length").SetView("ConferenceLength");
                                                                        //listViewConfiguration.AddField(x => x.CreatedBy).SetView("GuidToBackofficeUser");
                                                                    });

                                                                    // Define Operations
                                                                    collectionConfiguration.DisableCreate(context => !context.UserGroups.Any(x => x.Alias == "admin"));

                                                                    // Define Editing Experiance
                                                                    collectionConfiguration.Editor(editorConfiguration =>
                                                                    {
                                                                        editorConfiguration.AddTab("Details", tabConfigurtion =>
                                                                        {
                                                                            tabConfigurtion.AddFieldset("General", fieldsetConfiguration =>
                                                                            {
                                                                                fieldsetConfiguration.AddField(x => x.Description, fieldConfiguration =>
                                                                                {
                                                                                    fieldConfiguration.SetDataType("Textarea");
                                                                                    fieldConfiguration.SetDescription("A short description about the conference.");
                                                                                    fieldConfiguration.MakeRequired();
                                                                                });

                                                                                fieldsetConfiguration.AddField(x => x.StartDate, fieldConfiguration =>
                                                                                {
                                                                                    fieldConfiguration.SetDescription("The start date of the conference.");
                                                                                    fieldConfiguration.SetDefaultValue(DateTime.Now.Date);
                                                                                    fieldConfiguration.MakeRequired();
                                                                                });

                                                                                fieldsetConfiguration.AddField(x => x.EndDate, fieldConfiguration =>
                                                                                {
                                                                                    fieldConfiguration.SetDescription("The end date of the conference.");
                                                                                    fieldConfiguration.SetDefaultValue(DateTime.Now.Date);
                                                                                    fieldConfiguration.MakeRequired();
                                                                                });
                                                                            });
                                                                        });
                                                                    });

                                                                    // Define the Session Child Collection
                                                                    collectionConfiguration.AddChildCollection<Session>(x => x.Id,
                                                                                                                        x => x.ConferenceId,
                                                                                                                        "Session",
                                                                                                                        "Sessions",
                                                                                                                        "The sessions for a conference",
                                                                                                                        "icon-book",
                                                                                                                        "icon-book",
                                                                                                                        childCollectionConfiguration =>
                                                                                                                        {
                                                                                                                            childCollectionConfiguration.SetNameProperty(x => x.Title);

                                                                                                                            childCollectionConfiguration.SetSortProperty(x => x.StartTime);

                                                                                                                            childCollectionConfiguration.ListView(listViewConfiguration =>
                                                                                                                            {
                                                                                                                                listViewConfiguration.AddField(x => x.StartTime).SetFormat(x => $"{x:ddd} @ {x:hh:mm tt}");
                                                                                                                                listViewConfiguration.AddField(x => x.EndTime).SetFormat(x => $"{x:hh:mm tt}");
                                                                                                                                listViewConfiguration.AddField(x => x.Level).SetFormat(x => ((SessionLevel)x).ToString());
                                                                                                                            });

                                                                                                                            childCollectionConfiguration.Editor(editorConfiguration =>
                                                                                                                            {
                                                                                                                                editorConfiguration.AddTab("Details", tabConfigurtion =>
                                                                                                                                {
                                                                                                                                    tabConfigurtion.AddFieldset("General", fieldsetConfiguration =>
                                                                                                                                    {
                                                                                                                                        fieldsetConfiguration.AddField(x => x.Description, fieldConfiguration =>
                                                                                                                                        {
                                                                                                                                            fieldConfiguration.SetDataType("Richtext editor");
                                                                                                                                            fieldConfiguration.SetValueMapper<TipTapValueMapper>();
                                                                                                                                            fieldConfiguration.SetDescription("A description about the session.");
                                                                                                                                            fieldConfiguration.MakeRequired();
                                                                                                                                        });

                                                                                                                                        fieldsetConfiguration.AddField(x => x.Level, fieldConfiguration =>
                                                                                                                                        {
                                                                                                                                            fieldConfiguration.SetDataType("Session Level");
                                                                                                                                            fieldConfiguration.SetValueMapper<SingleEnumtoUmbracoDropdownValueMapper<SessionLevel>>();
                                                                                                                                            fieldConfiguration.SetDescription("The level of the session.");
                                                                                                                                            fieldConfiguration.SetDefaultValue((int)SessionLevel.Beginner);
                                                                                                                                            fieldConfiguration.MakeRequired();
                                                                                                                                        });

                                                                                                                                        fieldsetConfiguration.AddField(x => x.StartTime, fieldConfiguration =>
                                                                                                                                        {
                                                                                                                                            fieldConfiguration.SetDataType("Date Picker with time");
                                                                                                                                            fieldConfiguration.SetDescription("The start date and time of the session.");
                                                                                                                                            fieldConfiguration.SetDefaultValue(DateTime.Now.Date);
                                                                                                                                            fieldConfiguration.MakeRequired();
                                                                                                                                        });

                                                                                                                                        fieldsetConfiguration.AddField(x => x.EndTime, fieldConfiguration =>
                                                                                                                                        {
                                                                                                                                            fieldConfiguration.SetDataType("Date Picker with time");
                                                                                                                                            fieldConfiguration.SetDescription("The end date and time of the session.");
                                                                                                                                            fieldConfiguration.SetDefaultValue(DateTime.Now.Date);
                                                                                                                                            fieldConfiguration.MakeRequired();
                                                                                                                                        });
                                                                                                                                    });
                                                                                                                                });
                                                                                                                            });
                                                                                                                        });
                                                                });

                    treeConfiguration.AddCollection<Speaker>(x => x.Id,
                                                        "Speaker",
                                                        "Speakers",
                                                        "A collection of speakers.",
                                                        "icon-user",
                                                        "icon-user",
                                                        collectionConfiguration =>
                                                        {
                                                            collectionConfiguration.SetNameFormat(x => $"{x.LastName}, {x.FirstName}");
                                                            collectionConfiguration.SetSortProperty(x => x.LastName);
                                                            collectionConfiguration.AddAllDataView();
                                                            collectionConfiguration.AddSearchableProperty(x => x.LastName, SearchExpressionPattern.StartsWith);
                                                            collectionConfiguration.AddSearchableProperty(x => x.FirstName, SearchExpressionPattern.StartsWith);
                                                            collectionConfiguration.AddSearchableProperty(x => x.Bio, SearchExpressionPattern.Contains);
                                                            collectionConfiguration.ListView(listViewConfiguration =>
                                                            {
                                                                listViewConfiguration.AddField(x => x.Company);
                                                            });
                                                            collectionConfiguration.Editor(editorConfiguration =>
                                                            {
                                                                editorConfiguration.AddTab("Details", tabConfigurtion =>
                                                                {
                                                                    tabConfigurtion.AddFieldset("General", fieldsetConfiguration =>
                                                                    {
                                                                        fieldsetConfiguration.AddField(x => x.FirstName, fieldConfiguration =>
                                                                        {
                                                                            fieldConfiguration.SetDescription("The first name of the speaker.");
                                                                        });

                                                                        fieldsetConfiguration.AddField(x => x.LastName, fieldConfiguration =>
                                                                        {
                                                                            fieldConfiguration.SetDescription("The last name of the speaker.");
                                                                        });

                                                                        fieldsetConfiguration.AddField(x => x.Company, fieldConfiguration =>
                                                                        {
                                                                            fieldConfiguration.SetDescription("The company the speaker works for.");
                                                                        });
                                                                    });

                                                                    tabConfigurtion.AddFieldset("Additional Information", fieldsetConfiguration =>
                                                                    {
                                                                        fieldsetConfiguration.AddField(x => x.Bio, fieldConfiguration =>
                                                                        {
                                                                            fieldConfiguration.SetDataType("Richtext editor");
                                                                            fieldConfiguration.SetValueMapper<TipTapValueMapper>();
                                                                            fieldConfiguration.SetDescription("A short biography about the speaker.");
                                                                            fieldConfiguration.MakeRequired();
                                                                        });

                                                                        fieldsetConfiguration.AddField(x => x.TwitterHandle!, fieldConfiguration =>
                                                                        {
                                                                            fieldConfiguration.SetDescription("The Twitter handle of the speaker.");
                                                                        });
                                                                    });
                                                                });
                                                            });
                                                        });
                });
            });

        });

        return umbracoBuilder;
    }
}
