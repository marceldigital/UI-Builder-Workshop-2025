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
