using Movies.API.Domain.Entity;

namespace Movies.API.Domain.Repository;

using System.Linq.Expressions;

public interface IBaseRepository<T> where T : class
{
    Task<T> AddAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<T?> DeleteAsync(object id);
    Task<T> DeleteAsync(T entity);
    Task<T> GetAsync(object? id);
    Task<List<T>> GetAllAsync();
    Task<List<T>> GetFilteredAsync(Expression<Func<T, bool>> filter);
}