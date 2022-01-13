using DomainLayer.Model;

namespace InfrastructureLayer.Repositories.Interfaces;

public interface IBaseRepository<T> where T : BaseEntity
{
    IEnumerable<T> GetAll();
    T GetById(int id);
    void Insert(T entity);
    void Update(T entity);
    void Delete(T entity);
    void Remove(T entity);
    void SaveChanges();

}