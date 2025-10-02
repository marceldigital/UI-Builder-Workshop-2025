using Microsoft.EntityFrameworkCore;
using UIBuilderWorkshop.Data.Models;

namespace UIBuilderWorkshop.Data.EntityFramework;

/// <summary>
/// Represents the Entity Framework Core database context for the application,
/// providing access to conferences, sessions, and speakers.
/// </summary>
/// <param name="options">The options to be used by the <see cref="DbContext"/>.</param>
public class EntityFrameworkContext(DbContextOptions<EntityFrameworkContext> options) : DbContext(options)
{
    /// <summary>
    /// Gets or sets the <see cref="DbSet{TEntity}"/> for conferences.
    /// </summary>
    public DbSet<Conference> Conference { get; set; } = null!;

    /// <summary>
    /// Gets or sets the <see cref="DbSet{TEntity}"/> for sessions.
    /// </summary>
    public DbSet<Session> Session { get; set; } = null!;

    /// <summary>
    /// Gets or sets the <see cref="DbSet{TEntity}"/> for speakers.
    /// </summary>
    public DbSet<Speaker> Speaker { get; set; } = null!;
}
