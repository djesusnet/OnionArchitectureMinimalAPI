using DomainLayer.Model;
using InfrastructureLayer.Context;
using InfrastructureLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureLayer.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    private readonly ApplicationDbContext _applicationDbContext;
    private DbSet<T> entities;

    public BaseRepository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
        entities = _applicationDbContext.Set<T>();
    }

    public void Delete(T entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException("entity");
        }
        entities.Remove(entity);
        _applicationDbContext.SaveChanges();
    }

    public T GetById(int id)
    {
        return entities.SingleOrDefault(c => c.Id == id);
    }

    public System.Collections.Generic.IEnumerable<T> GetAll()
    {
        return entities.AsEnumerable();
    }

    public void Insert(T entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException("entity");
        }
        entities.Add(entity);
        _applicationDbContext.SaveChanges();
    }

    public void Remove(T entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException("entity");
        }
        entities.Remove(entity);
    }

    public void SaveChanges()
    {
        _applicationDbContext.SaveChanges();
    }

    public void Update(T entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException("entity");
        }
        entities.Update(entity);
        _applicationDbContext.SaveChanges();
    }
}