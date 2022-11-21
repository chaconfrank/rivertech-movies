namespace Movies.API.Infraestructure.Repository;

using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Movies.API.Domain.Repository;

public class BaseRepository<TEntity, TContext> : IBaseRepository<TEntity>
    where TEntity : class
    where TContext : DbContext
{

    private readonly TContext _context;

    public BaseRepository(TContext context)
    {
        this._context = context;
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        
        _context.Set<TEntity>().Add(entity);
        await _context.SaveChangesAsync();
        return entity;
        
    }

    public async Task<TEntity?> DeleteAsync(object id)
    {
        var entity = await _context.Set<TEntity>().FindAsync(id);
        if (entity == null)
        {
            return entity;
        }

        _context.Set<TEntity>().Remove(entity);
        await _context.SaveChangesAsync();

        return entity;
    }

    public async Task<TEntity> DeleteAsync(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
        await _context.SaveChangesAsync();

        return entity;
    }

    public async Task<List<TEntity>> GetAllAsync()
    {
        return await _context.Set<TEntity>().AsQueryable().ToListAsync();
    }

    public async Task<TEntity> GetAsync(object? id)
    {
        return await _context.Set<TEntity>().FindAsync(id);
    }

    public async Task<List<TEntity>> GetFilteredAsync(Expression<Func<TEntity, bool>> filter)
    {
        return await _context.Set<TEntity>().Where(filter).ToListAsync();
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        
        _context.Entry(entity).State = EntityState.Modified; 
        await _context.SaveChangesAsync();
        return entity;
        
    }
}