using Microsoft.EntityFrameworkCore;
using WebinarEF.Data;
using WebinarEF.Interfaces;

namespace WebinarEF.Repositories;

public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
{
    protected MyDbContext _context;

    public GenericRepository(MyDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _context.Set<TEntity>().ToListAsync();
    }

    async Task<TEntity> IRepository<TEntity>.GetByIdAsync(int id)
    {
        return await _context.Set<TEntity>().FindAsync(id);
    }

    public async Task AddAsync(TEntity entity)
    {
        await _context.Set<TEntity>().AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public void Update(TEntity entity)
    {
        _context.Set<TEntity>().Update(entity);
    }

    public void Delete(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
    }

    public void SetContext(MyDbContext context)
    {
        _context = context;
    }
}