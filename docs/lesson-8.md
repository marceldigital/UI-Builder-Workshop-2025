# Lesson 8: Creating a Custom Repository
Often times you don't have a choice in how you access the data. By default UI Builder uses NPOCO to access the database and give you the entites back.

Luckly UI Builder lets you swap out the engine which is quering the data by way of the `Repository<EntityType, IdType>` abstract class. To demonstrate this we will be making a Entity Framework flavor of this repository.

Let's create a class in `Core` at `Repositories/EntityFrameworkRepository.cs` and have it implement that class like so. 

```csharp
internal class EntityFrameworkRepository<TEntityType> : Repository<TEntityType, int>
{
    protected override void DeleteImpl(int id)
    {
        throw new NotImplementedException();
    }

    protected override IEnumerable<TEntityType> GetAllImpl(Expression<Func<TEntityType, bool>>? whereClause = null, Expression<Func<TEntityType, object>>? orderBy = null, SortDirection orderByDirection = SortDirection.Ascending)
    {
        throw new NotImplementedException();
    }

    protected override long GetCountImpl(Expression<Func<TEntityType, bool>> whereClause)
    {
        throw new NotImplementedException();
    }

    protected override int GetIdImpl(TEntityType entity)
    {
        throw new NotImplementedException();
    }

    protected override TEntityType GetImpl(int id)
    {
        throw new NotImplementedException();
    }

    protected override PagedResult<TEntityType> GetPagedImpl(int pageNumber, int pageSize, Expression<Func<TEntityType, bool>>? whereClause = null, Expression<Func<TEntityType, object>>? orderBy = null, SortDirection orderByDirection = SortDirection.Ascending)
    {
        throw new NotImplementedException();
    }

    protected override IEnumerable<TJunctionEntity> GetRelationsByParentIdImpl<TJunctionEntity>(int parentId, string relationAlias)
    {
        throw new NotImplementedException();
    }

    protected override TEntityType SaveImpl(TEntityType entity)
    {
        throw new NotImplementedException();
    }

    protected override TJunctionEntity SaveRelationImpl<TJunctionEntity>(TJunctionEntity entity)
    {
        throw new NotImplementedException();
    }
}

```

We will end up with something like the above which gives us the extension points we need to gather the data for the repository. Fill in the implementations with the following leveging the existing Entity Framework context from the `Data` project.

```csharp
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using UIBuilderWorkshop.Data.EntityFramework;
using UIBuilderWorkshop.Data.Models;
using Umbraco.Cms.Core.Models;
using Umbraco.UIBuilder;
using Umbraco.UIBuilder.Persistence;

namespace UIBuilderWorkshop.Core.Repositories;

/// <summary>
///     Implementation of the repository pattern using Entity Framework Core as the data access technology.
/// </summary>
internal class EntityFrameworkRepository<TEntityType> : Repository<TEntityType, int> where TEntityType : ModelBase
{
    private readonly EntityFrameworkContext _entityFrameworkContext;

    public EntityFrameworkRepository(RepositoryContext context, EntityFrameworkContext entityFrameworkContext) : base(context)
    {
        _entityFrameworkContext = entityFrameworkContext ?? throw new ArgumentNullException(nameof(entityFrameworkContext));
    }

    protected override void DeleteImpl(int id)
    {
        var entity = _entityFrameworkContext.Find<TEntityType>(id);

        if (entity is not null)
        {
            _entityFrameworkContext.Remove(entity);
            _entityFrameworkContext.SaveChanges();
        }
    }

    protected override IEnumerable<TEntityType> GetAllImpl(Expression<Func<TEntityType, bool>>? whereClause = null, Expression<Func<TEntityType, object>>? orderBy = null, SortDirection orderByDirection = SortDirection.Ascending)
    {
        var dbSet = _entityFrameworkContext.Set<TEntityType>();

        var query = dbSet.AsNoTracking().Where(whereClause ?? (e => true));
        if (orderBy is not null) query = orderByDirection == SortDirection.Ascending ? query.OrderBy(orderBy) : query.OrderByDescending(orderBy);

        return query.ToList();
    }

    protected override long GetCountImpl(Expression<Func<TEntityType, bool>> whereClause)
        => _entityFrameworkContext.Set<TEntityType>().AsNoTracking().Where(whereClause ?? (e => true)).LongCount();

    protected override int GetIdImpl(TEntityType entity)
        => entity.Id;

    protected override TEntityType GetImpl(int id)
    {
        var dbSet = _entityFrameworkContext.Set<TEntityType>();
        return dbSet.AsNoTracking().FirstOrDefault(x => x.Id == id);
    }

    protected override PagedResult<TEntityType> GetPagedImpl(int pageNumber, int pageSize, Expression<Func<TEntityType, bool>>? whereClause = null, Expression<Func<TEntityType, object>>? orderBy = null, SortDirection orderByDirection = SortDirection.Ascending)
    {
        var dbSet = _entityFrameworkContext.Set<TEntityType>();

        var query = dbSet.AsNoTracking().Where(whereClause ?? (e => true));
        if (orderBy is not null) query = orderByDirection == SortDirection.Ascending ? query.OrderBy(orderBy) : query.OrderByDescending(orderBy);


        query = query.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        var count = GetCountImpl(whereClause ?? (e => true));

        var pagedResult = new PagedResult<TEntityType>(count, pageNumber, pageSize)
        {
            Items = query.ToList()
        };

        return pagedResult;
    }

    protected override IEnumerable<TJunctionEntity> GetRelationsByParentIdImpl<TJunctionEntity>(int parentId, string relationAlias)
    {
        throw new NotImplementedException();
    }

    protected override TEntityType SaveImpl(TEntityType entity)
    {
        if (entity.Id == default)
        {
            _entityFrameworkContext.Add(entity);
        }
        else
        {
            _entityFrameworkContext.Update(entity);
        }

        _entityFrameworkContext.SaveChanges();

        return entity;
    }

    protected override TJunctionEntity SaveRelationImpl<TJunctionEntity>(TJunctionEntity entity)
    {
        throw new NotImplementedException();
    }
}

```

We have left some of the implementations blank as we are not using them in the current solution.

Now all we have to do to start using Entity Framework rather than NPOCO is to wire up the EF services

```csharp
public static IUmbracoBuilder AddWorkshopUIBuilder(this IUmbracoBuilder umbracoBuilder)
{
    ...
    // Add EF Core Repository for optional use
    umbracoBuilder.Services.AddDbContext<EntityFrameworkContext>(options => options.UseSqlServer(umbracoBuilder.Config.GetConnectionString("umbracoDbDSN")));
    ...
}
```

And then go to a collection and assign our new repository as the repository.

```csharp
collectionConfiguration.SetRepositoryType<EntityFrameworkRepository<Speaker>>();
```

That's all there is to it. The collection will now start using that repository for access and you can start using Entity Framwork with this project.