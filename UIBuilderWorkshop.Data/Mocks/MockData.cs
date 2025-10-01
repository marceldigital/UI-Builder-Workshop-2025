using UIBuilderWorkshop.Data.Models;
using UIBuilderWorkshop.Data.Enums;

namespace UIBuilderWorkshop.Data.Mocks;

public static class MockData
{
    public static List<Speaker> Speakers =
    [
        new Speaker { Id = 1, FirstName = "Shannon", LastName = "Deminick", Bio = "Umbraco HQ CTO, core architect.", Company = "Umbraco HQ", TwitterHandle = "@shazwazza" },
        new Speaker { Id = 2, FirstName = "Niels", LastName = "Hartvig", Bio = "Founder of Umbraco.", Company = "Umbraco HQ", TwitterHandle = "@umbraco" },
        new Speaker { Id = 3, FirstName = "Emma", LastName = "Burstow", Bio = "Umbraco Community Team Lead.", Company = "Umbraco HQ", TwitterHandle = "@EmmaBurstow" },
        new Speaker { Id = 4, FirstName = "Callum", LastName = "Whyte", Bio = "Umbraco MVP, package developer.", Company = "Bump Digital", TwitterHandle = "@callumbwhyte" },
        new Speaker { Id = 5, FirstName = "Marcin", LastName = "Zajkowski", Bio = "Umbraco MVP, community leader.", Company = "Cogworks", TwitterHandle = "@marcinzajkowski" },
        new Speaker { Id = 6, FirstName = "Matt", LastName = "Brailsford", Bio = "Umbraco MVP, package creator.", Company = "Outfield Digital", TwitterHandle = "@mattbrailsford" },
        new Speaker { Id = 7, FirstName = "Jeavon", LastName = "Leopold", Bio = "Umbraco MVP, developer.", Company = "Crucial", TwitterHandle = "@crumpled_jeavon" },
        new Speaker { Id = 8, FirstName = "Warren", LastName = "Buckley", Bio = "Umbraco HQ, developer advocate.", Company = "Umbraco HQ", TwitterHandle = "@warrenbuckley" },
        new Speaker { Id = 9, FirstName = "Sofie", LastName = "Benedikte", Bio = "Umbraco HQ, documentation lead.", Company = "Umbraco HQ", TwitterHandle = "@sofie_benedikte" },
        new Speaker { Id = 10, FirstName = "Lotte", LastName = "Pitcher", Bio = "Umbraco MVP, community leader.", Company = "The Cogworks", TwitterHandle = "@lottepitcher" },
        new Speaker { Id = 11, FirstName = "Kevin", LastName = "Jump", Bio = "Umbraco MVP, package developer.", Company = "Jumoo", TwitterHandle = "@kevinjumbouk" },
        new Speaker { Id = 12, FirstName = "Nik", LastName = "R" , Bio = "Umbraco MVP, developer.", Company = "Umbraco HQ", TwitterHandle = "@nikr" },
        new Speaker { Id = 13, FirstName = "Paul", LastName = "Seal", Bio = "Umbraco MVP, blogger.", Company = "Moriyama", TwitterHandle = "@CodeSharePaul" },
        new Speaker { Id = 14, FirstName = "Lee", LastName = "Kelleher", Bio = "Umbraco MVP, package creator.", Company = "Umbrella Inc.", TwitterHandle = "@leekelleher" },
        new Speaker { Id = 15, FirstName = "Ismail", LastName = "Mayat", Bio = "Umbraco MVP, developer.", Company = "Mayatworks", TwitterHandle = "@ismailmayat" },
        new Speaker { Id = 16, FirstName = "Marc", LastName = "Goodson", Bio = "Umbraco MVP, community leader.", Company = "Moriyama", TwitterHandle = "@marcgoodson" },
        new Speaker { Id = 17, FirstName = "Carole", LastName = "Logan", Bio = "Umbraco MVP, speaker.", Company = "Equator", TwitterHandle = "@carolelogan" },
        new Speaker { Id = 18, FirstName = "Heather", LastName = "Floyd", Bio = "Umbraco MVP, developer.", Company = "Heather Floyd", TwitterHandle = "@heatherfloyd" },
        new Speaker { Id = 19, FirstName = "Matt", LastName = "Wise", Bio = "Umbraco MVP, developer.", Company = "Moriyama", TwitterHandle = "@mattwise" },
        new Speaker { Id = 20, FirstName = "Steve", LastName = "Temple", Bio = "Umbraco MVP, developer.", Company = "Bump Digital", TwitterHandle = "@stevetemple" },
        new Speaker { Id = 21, FirstName = "Jesper", LastName = "Bernhardt", Bio = "Umbraco HQ, developer.", Company = "Umbraco HQ", TwitterHandle = "@jesperbernhardt" },
        new Speaker { Id = 22, FirstName = "Kim", LastName = "Sneum Madsen", Bio = "Umbraco HQ, CEO.", Company = "Umbraco HQ", TwitterHandle = "@kimsmadsen" },
        new Speaker { Id = 23, FirstName = "Rune", LastName = "Strand", Bio = "Umbraco HQ, developer.", Company = "Umbraco HQ", TwitterHandle = "@runestrand" },
        new Speaker { Id = 24, FirstName = "Ilham", LastName = "Bachtiar", Bio = "Umbraco HQ, developer.", Company = "Umbraco HQ", TwitterHandle = "@ilham_bachtiar" },
        new Speaker { Id = 25, FirstName = "Anders", LastName = "Burchardt", Bio = "Umbraco HQ, developer.", Company = "Umbraco HQ", TwitterHandle = "@andersburchardt" },
        new Speaker { Id = 26, FirstName = "Sebastiaan", LastName = "Janssen", Bio = "Umbraco HQ, developer.", Company = "Umbraco HQ", TwitterHandle = "@cultiv" },
        new Speaker { Id = 27, FirstName = "Per", LastName = "Ploug", Bio = "Umbraco HQ, developer.", Company = "Umbraco HQ", TwitterHandle = "@perploug" },
        new Speaker { Id = 28, FirstName = "Simone", LastName = "Chiaretta", Bio = "Umbraco MVP, developer.", Company = "WebScience", TwitterHandle = "@simonechiaretta" },
        new Speaker { Id = 29, FirstName = "Dave", LastName = "Woestenborghs", Bio = "Umbraco MVP, developer.", Company = "Umbraco HQ", TwitterHandle = "@dawoe21" },
        new Speaker { Id = 30, FirstName = "Hendy", LastName = "Irawan", Bio = "Umbraco MVP, developer.", Company = "Umbraco HQ", TwitterHandle = "@ceefour" },
    ];

    public static List<Conference> Conferences =
    [
        new Conference { Id = 1, Name = "Codegarden 2025", Description = "The official Umbraco conference in Odense.", StartDate = new DateTime(2025, 6, 11), EndDate = new DateTime(2025, 6, 13) },
        new Conference { Id = 2, Name = "Umbraco UK Festival 2025", Description = "The UK's largest Umbraco event.", StartDate = new DateTime(2025, 11, 6), EndDate = new DateTime(2025, 11, 7) },
        new Conference { Id = 3, Name = "Umbraco US Summit 2025", Description = "The US Umbraco community event.", StartDate = new DateTime(2025, 10, 2), EndDate = new DateTime(2025, 10, 3) },
        new Conference { Id = 4, Name = "Umbraco DK Festival 2025", Description = "The Danish Umbraco festival.", StartDate = new DateTime(2025, 9, 18), EndDate = new DateTime(2025, 9, 19) },
        new Conference { Id = 5, Name = "Umbraco Poland Festival 2025", Description = "The Polish Umbraco festival.", StartDate = new DateTime(2025, 5, 15), EndDate = new DateTime(2025, 5, 16) },
        new Conference { Id = 6, Name = "Umbraco Sweden Festival 2025", Description = "The Swedish Umbraco festival.", StartDate = new DateTime(2025, 4, 24), EndDate = new DateTime(2025, 4, 25) },
        new Conference { Id = 7, Name = "Umbraco Down Under Festival 2025", Description = "The Australian Umbraco festival.", StartDate = new DateTime(2025, 3, 14), EndDate = new DateTime(2025, 3, 15) },
        new Conference { Id = 8, Name = "Umbraco Netherlands Festival 2025", Description = "The Dutch Umbraco festival.", StartDate = new DateTime(2025, 2, 20), EndDate = new DateTime(2025, 2, 21) },
        new Conference { Id = 9, Name = "Umbraco Norway Festival 2025", Description = "The Norwegian Umbraco festival.", StartDate = new DateTime(2025, 8, 28), EndDate = new DateTime(2025, 8, 29) },
        new Conference { Id = 10, Name = "Umbraco Germany Festival 2025", Description = "The German Umbraco festival.", StartDate = new DateTime(2025, 7, 10), EndDate = new DateTime(2025, 7, 11) },
    ];

    public static List<Session> Sessions =
    [
        // Codegarden 2025 (20 sessions)
        new Session { Id = 1, Title = "Keynote: The Future of Umbraco", Description = "Opening keynote on the future direction of Umbraco.", StartTime = new DateTime(2025, 6, 11, 9, 0, 0), EndTime = new DateTime(2025, 6, 11, 10, 0, 0), ConferenceId = 1, Level = (int)SessionLevel.Beginner },
        new Session { Id = 2, Title = "Umbraco Cloud Deep Dive", Description = "Explore the latest features and best practices for Umbraco Cloud.", StartTime = new DateTime(2025, 6, 11, 10, 30, 0), EndTime = new DateTime(2025, 6, 11, 11, 30, 0), ConferenceId = 1, Level = (int)SessionLevel.Intermediate },
        new Session { Id = 3, Title = "Composable DXP with Umbraco", Description = "How to build a composable digital experience platform using Umbraco.", StartTime = new DateTime(2025, 6, 11, 12, 0, 0), EndTime = new DateTime(2025, 6, 11, 13, 0, 0), ConferenceId = 1, Level = (int)SessionLevel.Advanced },
        new Session { Id = 4, Title = "Umbraco UI Builder Workshop", Description = "Hands-on workshop for building custom backoffice UIs.", StartTime = new DateTime(2025, 6, 11, 14, 0, 0), EndTime = new DateTime(2025, 6, 11, 16, 0, 0), ConferenceId = 1, Level = (int)SessionLevel.Beginner },
        new Session { Id = 5, Title = "Extending Umbraco with Packages", Description = "Best practices for creating and using Umbraco packages.", StartTime = new DateTime(2025, 6, 12, 9, 0, 0), EndTime = new DateTime(2025, 6, 12, 10, 0, 0), ConferenceId = 1, Level = (int)SessionLevel.Intermediate },
        new Session { Id = 6, Title = "Umbraco Heartcore in Action", Description = "Real-world use cases for Umbraco Heartcore headless CMS.", StartTime = new DateTime(2025, 6, 12, 10, 30, 0), EndTime = new DateTime(2025, 6, 12, 11, 30, 0), ConferenceId = 1, Level = (int)SessionLevel.Advanced },
        new Session { Id = 7, Title = "Security Best Practices in Umbraco", Description = "How to secure your Umbraco sites and backoffice.", StartTime = new DateTime(2025, 6, 12, 12, 0, 0), EndTime = new DateTime(2025, 6, 12, 13, 0, 0), ConferenceId = 1, Level = (int)SessionLevel.Beginner },
        new Session { Id = 8, Title = "Umbraco Community Panel", Description = "Panel discussion with Umbraco community leaders.", StartTime = new DateTime(2025, 6, 12, 13, 30, 0), EndTime = new DateTime(2025, 6, 12, 14, 30, 0), ConferenceId = 1, Level = (int)SessionLevel.Intermediate },
        new Session { Id = 9, Title = "Closing: Umbraco Awards & Wrap-up", Description = "Conference closing and Umbraco Awards ceremony.", StartTime = new DateTime(2025, 6, 13, 12, 0, 0), EndTime = new DateTime(2025, 6, 13, 13, 0, 0), ConferenceId = 1, Level = (int)SessionLevel.Advanced },
        new Session { Id = 10, Title = "Umbraco for Enterprise", Description = "Scaling Umbraco for large organizations.", StartTime = new DateTime(2025, 6, 12, 15, 0, 0), EndTime = new DateTime(2025, 6, 12, 16, 0, 0), ConferenceId = 1, Level = (int)SessionLevel.Beginner },
        new Session { Id = 11, Title = "Headless CMS Best Practices", Description = "How to use Umbraco Heartcore effectively.", StartTime = new DateTime(2025, 6, 13, 9, 0, 0), EndTime = new DateTime(2025, 6, 13, 10, 0, 0), ConferenceId = 1, Level = (int)SessionLevel.Intermediate },
        new Session { Id = 12, Title = "Umbraco Deploy Automation", Description = "Automating deployments with Umbraco Deploy.", StartTime = new DateTime(2025, 6, 13, 10, 30, 0), EndTime = new DateTime(2025, 6, 13, 11, 30, 0), ConferenceId = 1, Level = (int)SessionLevel.Advanced },
        new Session { Id = 13, Title = "Content Modeling Masterclass", Description = "Advanced content modeling in Umbraco.", StartTime = new DateTime(2025, 6, 12, 11, 30, 0), EndTime = new DateTime(2025, 6, 12, 12, 30, 0), ConferenceId = 1, Level = (int)SessionLevel.Beginner },
        new Session { Id = 14, Title = "Umbraco Accessibility", Description = "Making Umbraco sites accessible.", StartTime = new DateTime(2025, 6, 13, 14, 0, 0), EndTime = new DateTime(2025, 6, 13, 15, 0, 0), ConferenceId = 1, Level = (int)SessionLevel.Intermediate },
        new Session { Id = 15, Title = "Performance Tuning in Umbraco", Description = "Optimizing Umbraco for speed.", StartTime = new DateTime(2025, 6, 13, 15, 30, 0), EndTime = new DateTime(2025, 6, 13, 16, 30, 0), ConferenceId = 1, Level = (int)SessionLevel.Advanced },
        new Session { Id = 16, Title = "Umbraco vNext: What's Coming?", Description = "A look at the roadmap for future Umbraco releases.", StartTime = new DateTime(2025, 6, 11, 16, 0, 0), EndTime = new DateTime(2025, 6, 11, 17, 0, 0), ConferenceId = 1, Level = (int)SessionLevel.Beginner },
        new Session { Id = 17, Title = "Umbraco Package Development", Description = "How to create and distribute Umbraco packages.", StartTime = new DateTime(2025, 6, 12, 14, 30, 0), EndTime = new DateTime(2025, 6, 12, 15, 30, 0), ConferenceId = 1, Level = (int)SessionLevel.Intermediate },
        new Session { Id = 18, Title = "Integrating Umbraco with Azure", Description = "How to deploy and scale Umbraco on Azure.", StartTime = new DateTime(2025, 6, 13, 11, 30, 0), EndTime = new DateTime(2025, 6, 13, 12, 30, 0), ConferenceId = 1, Level = (int)SessionLevel.Advanced },
        new Session { Id = 19, Title = "Umbraco Security Deep Dive", Description = "Advanced security for Umbraco sites.", StartTime = new DateTime(2025, 6, 12, 16, 0, 0), EndTime = new DateTime(2025, 6, 12, 17, 0, 0), ConferenceId = 1, Level = (int)SessionLevel.Beginner },
        new Session { Id = 20, Title = "Umbraco Community Social", Description = "Networking and social event for the Umbraco community.", StartTime = new DateTime(2025, 6, 13, 17, 0, 0), EndTime = new DateTime(2025, 6, 13, 18, 0, 0), ConferenceId = 1, Level = (int)SessionLevel.Intermediate },
        // Umbraco UK Festival 2025 (15 sessions)
        new Session { Id = 21, Title = "UK Keynote: Umbraco in the Enterprise", Description = "Keynote on Umbraco's role in enterprise solutions.", StartTime = new DateTime(2025, 11, 6, 9, 0, 0), EndTime = new DateTime(2025, 11, 6, 10, 0, 0), ConferenceId = 2, Level = (int)SessionLevel.Advanced },
        new Session { Id = 22, Title = "Integrating Umbraco with Azure", Description = "How to deploy and scale Umbraco on Azure.", StartTime = new DateTime(2025, 11, 6, 10, 30, 0), EndTime = new DateTime(2025, 11, 6, 11, 30, 0), ConferenceId = 2, Level = (int)SessionLevel.Beginner },
        new Session { Id = 23, Title = "Umbraco Accessibility Workshop", Description = "Making your Umbraco sites accessible to all.", StartTime = new DateTime(2025, 11, 6, 12, 0, 0), EndTime = new DateTime(2025, 11, 6, 13, 0, 0), ConferenceId = 2, Level = (int)SessionLevel.Intermediate },
        new Session { Id = 24, Title = "Umbraco vNext: What's Coming?", Description = "A look at the roadmap for future Umbraco releases.", StartTime = new DateTime(2025, 11, 7, 9, 0, 0), EndTime = new DateTime(2025, 11, 7, 10, 0, 0), ConferenceId = 2, Level = (int)SessionLevel.Advanced },
        new Session { Id = 25, Title = "Content Modeling in Umbraco", Description = "Best practices for content modeling and document types.", StartTime = new DateTime(2025, 11, 7, 10, 30, 0), EndTime = new DateTime(2025, 11, 7, 11, 30, 0), ConferenceId = 2, Level = (int)SessionLevel.Beginner },
        new Session { Id = 26, Title = "Umbraco Package Development", Description = "How to create and distribute Umbraco packages.", StartTime = new DateTime(2025, 11, 7, 12, 0, 0), EndTime = new DateTime(2025, 11, 7, 13, 0, 0), ConferenceId = 2, Level = (int)SessionLevel.Intermediate },
        new Session { Id = 27, Title = "UK Community Roundtable", Description = "Discussion with UK-based Umbraco community members.", StartTime = new DateTime(2025, 11, 6, 14, 0, 0), EndTime = new DateTime(2025, 11, 6, 15, 0, 0), ConferenceId = 2, Level = (int)SessionLevel.Advanced },
        new Session { Id = 28, Title = "Umbraco in the Cloud", Description = "Deploying Umbraco solutions in the cloud.", StartTime = new DateTime(2025, 11, 6, 15, 30, 0), EndTime = new DateTime(2025, 11, 6, 16, 30, 0), ConferenceId = 2, Level = (int)SessionLevel.Beginner },
        new Session { Id = 29, Title = "Optimizing Umbraco for Mobile", Description = "Best practices for mobile-optimized Umbraco sites.", StartTime = new DateTime(2025, 11, 7, 10, 0, 0), EndTime = new DateTime(2025, 11, 7, 11, 0, 0), ConferenceId = 2, Level = (int)SessionLevel.Intermediate },
        new Session { Id = 30, Title = "Umbraco Deploy Best Practices", Description = "How to use Umbraco Deploy for smooth deployments.", StartTime = new DateTime(2025, 11, 7, 11, 30, 0), EndTime = new DateTime(2025, 11, 7, 12, 30, 0), ConferenceId = 2, Level = (int)SessionLevel.Advanced },
        // Umbraco US Summit 2025 (15 sessions)
        new Session { Id = 31, Title = "US Keynote: Umbraco in North America", Description = "Keynote on Umbraco's growth and adoption in the US.", StartTime = new DateTime(2025, 10, 2, 9, 0, 0), EndTime = new DateTime(2025, 10, 2, 10, 0, 0), ConferenceId = 3, Level = (int)SessionLevel.Beginner },
        new Session { Id = 32, Title = "Scaling Umbraco for High Traffic", Description = "Techniques for scaling Umbraco sites in the cloud.", StartTime = new DateTime(2025, 10, 2, 10, 30, 0), EndTime = new DateTime(2025, 10, 2, 11, 30, 0), ConferenceId = 3, Level = (int)SessionLevel.Intermediate },
        new Session { Id = 33, Title = "Umbraco Headless CMS", Description = "Building modern web apps with Umbraco Heartcore.", StartTime = new DateTime(2025, 10, 2, 12, 0, 0), EndTime = new DateTime(2025, 10, 2, 13, 0, 0), ConferenceId = 3, Level = (int)SessionLevel.Advanced },
        new Session { Id = 34, Title = "Migrating to Umbraco 10+", Description = "Best practices for upgrading legacy Umbraco sites.", StartTime = new DateTime(2025, 10, 3, 9, 0, 0), EndTime = new DateTime(2025, 10, 3, 10, 0, 0), ConferenceId = 3, Level = (int)SessionLevel.Beginner },
        new Session { Id = 35, Title = "US Community Roundtable", Description = "Discussion with US-based Umbraco community members.", StartTime = new DateTime(2025, 10, 3, 10, 30, 0), EndTime = new DateTime(2025, 10, 3, 11, 30, 0), ConferenceId = 3, Level = (int)SessionLevel.Intermediate },
        new Session { Id = 36, Title = "Advanced Umbraco Security", Description = "Deep dive into securing Umbraco installations.", StartTime = new DateTime(2025, 10, 2, 14, 0, 0), EndTime = new DateTime(2025, 10, 2, 15, 0, 0), ConferenceId = 3, Level = (int)SessionLevel.Advanced },
        new Session { Id = 37, Title = "Performance Optimization Tips", Description = "Improving the performance of your Umbraco site.", StartTime = new DateTime(2025, 10, 3, 12, 0, 0), EndTime = new DateTime(2025, 10, 3, 13, 0, 0), ConferenceId = 3, Level = (int)SessionLevel.Beginner },
        new Session { Id = 38, Title = "Umbraco in Enterprise Environments", Description = "Deploying Umbraco in large-scale enterprise environments.", StartTime = new DateTime(2025, 10, 2, 15, 30, 0), EndTime = new DateTime(2025, 10, 2, 16, 30, 0), ConferenceId = 3, Level = (int)SessionLevel.Intermediate },
        new Session { Id = 39, Title = "RESTful APIs with Umbraco", Description = "Creating and consuming RESTful APIs in Umbraco.", StartTime = new DateTime(2025, 10, 3, 14, 0, 0), EndTime = new DateTime(2025, 10, 3, 15, 0, 0), ConferenceId = 3, Level = (int)SessionLevel.Advanced },
        new Session { Id = 40, Title = "GraphQL with Umbraco", Description = "Leveraging GraphQL for flexible APIs in Umbraco.", StartTime = new DateTime(2025, 10, 3, 15, 30, 0), EndTime = new DateTime(2025, 10, 3, 16, 30, 0), ConferenceId = 3, Level = (int)SessionLevel.Beginner },
        // Umbraco DK Festival 2025 (10 sessions)
        new Session { Id = 41, Title = "DK Keynote: Umbraco in Denmark", Description = "Keynote on Umbraco's Danish roots and future.", StartTime = new DateTime(2025, 9, 18, 9, 0, 0), EndTime = new DateTime(2025, 9, 18, 10, 0, 0), ConferenceId = 4, Level = (int)SessionLevel.Intermediate },
        new Session { Id = 42, Title = "Umbraco and .NET 9", Description = "Leveraging the latest .NET features in Umbraco.", StartTime = new DateTime(2025, 9, 18, 10, 30, 0), EndTime = new DateTime(2025, 9, 18, 11, 30, 0), ConferenceId = 4, Level = (int)SessionLevel.Advanced },
        new Session { Id = 43, Title = "Umbraco Deploy Best Practices", Description = "How to use Umbraco Deploy for smooth deployments.", StartTime = new DateTime(2025, 9, 18, 12, 0, 0), EndTime = new DateTime(2025, 9, 18, 13, 0, 0), ConferenceId = 4, Level = (int)SessionLevel.Beginner },
        new Session { Id = 44, Title = "DK Community Q&A", Description = "Q&A with Danish Umbraco experts.", StartTime = new DateTime(2025, 9, 19, 9, 0, 0), EndTime = new DateTime(2025, 9, 19, 10, 0, 0), ConferenceId = 4, Level = (int)SessionLevel.Intermediate },
        // Umbraco Poland Festival 2025 (10 sessions)
        new Session { Id = 45, Title = "PL Keynote: Umbraco in Poland", Description = "Keynote on Umbraco's adoption in Poland.", StartTime = new DateTime(2025, 5, 15, 9, 0, 0), EndTime = new DateTime(2025, 5, 15, 10, 0, 0), ConferenceId = 5, Level = (int)SessionLevel.Advanced },
        new Session { Id = 46, Title = "Umbraco Multilingual Sites", Description = "Building multilingual sites with Umbraco.", StartTime = new DateTime(2025, 5, 15, 10, 30, 0), EndTime = new DateTime(2025, 5, 15, 11, 30, 0), ConferenceId = 5, Level = (int)SessionLevel.Beginner },
        new Session { Id = 47, Title = "Polish Community Panel", Description = "Panel with Polish Umbraco community leaders.", StartTime = new DateTime(2025, 5, 16, 9, 0, 0), EndTime = new DateTime(2025, 5, 16, 10, 0, 0), ConferenceId = 5, Level = (int)SessionLevel.Intermediate },
        // Umbraco Sweden Festival 2025 (10 sessions)
        new Session { Id = 48, Title = "SE Keynote: Umbraco in Sweden", Description = "Keynote on Umbraco's growth in Sweden.", StartTime = new DateTime(2025, 4, 24, 9, 0, 0), EndTime = new DateTime(2025, 4, 24, 10, 0, 0), ConferenceId = 6, Level = (int)SessionLevel.Advanced },
        new Session { Id = 49, Title = "Umbraco Performance Tuning", Description = "Tips for optimizing Umbraco site performance.", StartTime = new DateTime(2025, 4, 24, 10, 30, 0), EndTime = new DateTime(2025, 4, 24, 11, 30, 0), ConferenceId = 6, Level = (int)SessionLevel.Beginner },
        new Session { Id = 50, Title = "Swedish Community Meetup", Description = "Meetup for Swedish Umbraco users.", StartTime = new DateTime(2025, 4, 25, 9, 0, 0), EndTime = new DateTime(2025, 4, 25, 10, 0, 0), ConferenceId = 6, Level = (int)SessionLevel.Intermediate },
        // Umbraco Down Under Festival 2025 (10 sessions)
        new Session { Id = 51, Title = "AU Keynote: Umbraco Down Under", Description = "Keynote on Umbraco in Australia.", StartTime = new DateTime(2025, 3, 14, 9, 0, 0), EndTime = new DateTime(2025, 3, 14, 10, 0, 0), ConferenceId = 7, Level = (int)SessionLevel.Advanced },
        new Session { Id = 52, Title = "Umbraco Deploy Down Under", Description = "Deploying Umbraco sites in the Australian market.", StartTime = new DateTime(2025, 3, 14, 10, 30, 0), EndTime = new DateTime(2025, 3, 14, 11, 30, 0), ConferenceId = 7, Level = (int)SessionLevel.Beginner },
        new Session { Id = 53, Title = "Australian Community Panel", Description = "Panel with Australian Umbraco community members.", StartTime = new DateTime(2025, 3, 15, 9, 0, 0), EndTime = new DateTime(2025, 3, 15, 10, 0, 0), ConferenceId = 7, Level = (int)SessionLevel.Intermediate },
        // Umbraco Netherlands Festival 2025 (10 sessions)
        new Session { Id = 54, Title = "NL Keynote: Umbraco in the Netherlands", Description = "Keynote on Umbraco's Dutch community.", StartTime = new DateTime(2025, 2, 20, 9, 0, 0), EndTime = new DateTime(2025, 2, 20, 10, 0, 0), ConferenceId = 8, Level = (int)SessionLevel.Advanced },
        new Session { Id = 55, Title = "Dutch Community Meetup", Description = "Meetup for Dutch Umbraco users.", StartTime = new DateTime(2025, 2, 21, 9, 0, 0), EndTime = new DateTime(2025, 2, 21, 10, 0, 0), ConferenceId = 8, Level = (int)SessionLevel.Beginner },
        // Umbraco Norway Festival 2025 (10 sessions)
        new Session { Id = 56, Title = "NO Keynote: Umbraco in Norway", Description = "Keynote on Umbraco's Norwegian community.", StartTime = new DateTime(2025, 8, 28, 9, 0, 0), EndTime = new DateTime(2025, 8, 28, 10, 0, 0), ConferenceId = 9, Level = (int)SessionLevel.Intermediate },
        new Session { Id = 57, Title = "Norwegian Community Meetup", Description = "Meetup for Norwegian Umbraco users.", StartTime = new DateTime(2025, 8, 29, 9, 0, 0), EndTime = new DateTime(2025, 8, 29, 10, 0, 0), ConferenceId = 9, Level = (int)SessionLevel.Advanced },
        // Umbraco Germany Festival 2025 (10 sessions)
        new Session { Id = 58, Title = "DE Keynote: Umbraco in Germany", Description = "Keynote on Umbraco's German community.", StartTime = new DateTime(2025, 7, 10, 9, 0, 0), EndTime = new DateTime(2025, 7, 10, 10, 0, 0), ConferenceId = 10, Level = (int)SessionLevel.Beginner },
        new Session { Id = 59, Title = "German Community Meetup", Description = "Meetup for German Umbraco users.", StartTime = new DateTime(2025, 7, 11, 9, 0, 0), EndTime = new DateTime(2025, 7, 11, 10, 0, 0), ConferenceId = 10, Level = (int)SessionLevel.Intermediate }
    ];

    public static List<SessionSpeaker> SessionSpeakers =
    [
        // Codegarden 2025 (Sessions 1-20)
        new SessionSpeaker { SessionId = 1, SpeakerId = 2 },
        new SessionSpeaker { SessionId = 2, SpeakerId = 5 },
        new SessionSpeaker { SessionId = 3, SpeakerId = 8 },
        new SessionSpeaker { SessionId = 4, SpeakerId = 1 },
        new SessionSpeaker { SessionId = 5, SpeakerId = 3 },
        new SessionSpeaker { SessionId = 6, SpeakerId = 6 },
        new SessionSpeaker { SessionId = 7, SpeakerId = 7 },
        new SessionSpeaker { SessionId = 8, SpeakerId = 10 },
        new SessionSpeaker { SessionId = 9, SpeakerId = 4 },
        new SessionSpeaker { SessionId = 10, SpeakerId = 9 },
        new SessionSpeaker { SessionId = 11, SpeakerId = 11 },
        new SessionSpeaker { SessionId = 12, SpeakerId = 12 },
        new SessionSpeaker { SessionId = 13, SpeakerId = 13 },
        new SessionSpeaker { SessionId = 14, SpeakerId = 14 },
        new SessionSpeaker { SessionId = 15, SpeakerId = 15 },
        new SessionSpeaker { SessionId = 16, SpeakerId = 16 },
        new SessionSpeaker { SessionId = 17, SpeakerId = 17 },
        new SessionSpeaker { SessionId = 18, SpeakerId = 18 },
        new SessionSpeaker { SessionId = 19, SpeakerId = 19 },
        new SessionSpeaker { SessionId = 20, SpeakerId = 20 },
        // Add a few double-speaker sessions for variety
        new SessionSpeaker { SessionId = 1, SpeakerId = 3 },
        new SessionSpeaker { SessionId = 5, SpeakerId = 7 },
        new SessionSpeaker { SessionId = 8, SpeakerId = 2 },
        new SessionSpeaker { SessionId = 12, SpeakerId = 4 },
        // Umbraco UK Festival 2025 (Sessions 21-30)
        new SessionSpeaker { SessionId = 21, SpeakerId = 21 },
        new SessionSpeaker { SessionId = 22, SpeakerId = 22 },
        new SessionSpeaker { SessionId = 23, SpeakerId = 23 },
        new SessionSpeaker { SessionId = 24, SpeakerId = 24 },
        new SessionSpeaker { SessionId = 25, SpeakerId = 25 },
        new SessionSpeaker { SessionId = 26, SpeakerId = 26 },
        new SessionSpeaker { SessionId = 27, SpeakerId = 27 },
        new SessionSpeaker { SessionId = 28, SpeakerId = 28 },
        new SessionSpeaker { SessionId = 29, SpeakerId = 29 },
        new SessionSpeaker { SessionId = 30, SpeakerId = 30 },
        new SessionSpeaker { SessionId = 21, SpeakerId = 22 },
        new SessionSpeaker { SessionId = 23, SpeakerId = 24 },
        // Umbraco US Summit 2025 (Sessions 31-40)
        new SessionSpeaker { SessionId = 31, SpeakerId = 1 },
        new SessionSpeaker { SessionId = 32, SpeakerId = 2 },
        new SessionSpeaker { SessionId = 33, SpeakerId = 3 },
        new SessionSpeaker { SessionId = 34, SpeakerId = 4 },
        new SessionSpeaker { SessionId = 35, SpeakerId = 5 },
        new SessionSpeaker { SessionId = 36, SpeakerId = 6 },
        new SessionSpeaker { SessionId = 37, SpeakerId = 7 },
        new SessionSpeaker { SessionId = 38, SpeakerId = 8 },
        new SessionSpeaker { SessionId = 39, SpeakerId = 9 },
        new SessionSpeaker { SessionId = 40, SpeakerId = 10 },
        new SessionSpeaker { SessionId = 31, SpeakerId = 11 },
        new SessionSpeaker { SessionId = 33, SpeakerId = 12 },
        // Umbraco DK Festival 2025 (Sessions 41-44)
        new SessionSpeaker { SessionId = 41, SpeakerId = 13 },
        new SessionSpeaker { SessionId = 42, SpeakerId = 14 },
        new SessionSpeaker { SessionId = 43, SpeakerId = 15 },
        new SessionSpeaker { SessionId = 44, SpeakerId = 16 },
        // Umbraco Poland Festival 2025 (Sessions 45-47)
        new SessionSpeaker { SessionId = 45, SpeakerId = 17 },
        new SessionSpeaker { SessionId = 46, SpeakerId = 18 },
        new SessionSpeaker { SessionId = 47, SpeakerId = 19 },
        // Umbraco Sweden Festival 2025 (Sessions 48-50)
        new SessionSpeaker { SessionId = 48, SpeakerId = 20 },
        new SessionSpeaker { SessionId = 49, SpeakerId = 21 },
        new SessionSpeaker { SessionId = 50, SpeakerId = 22 },
        // Umbraco Down Under Festival 2025 (Sessions 51-53)
        new SessionSpeaker { SessionId = 51, SpeakerId = 23 },
        new SessionSpeaker { SessionId = 52, SpeakerId = 24 },
        new SessionSpeaker { SessionId = 53, SpeakerId = 25 },
        // Umbraco Netherlands Festival 2025 (Sessions 54-55)
        new SessionSpeaker { SessionId = 54, SpeakerId = 26 },
        new SessionSpeaker { SessionId = 55, SpeakerId = 27 },
        // Umbraco Norway Festival 2025 (Sessions 56-57)
        new SessionSpeaker { SessionId = 56, SpeakerId = 28 },
        new SessionSpeaker { SessionId = 57, SpeakerId = 29 },
        // Umbraco Germany Festival 2025 (Sessions 58-59)
        new SessionSpeaker { SessionId = 58, SpeakerId = 30 },
        new SessionSpeaker { SessionId = 59, SpeakerId = 1 },
    ];
}
