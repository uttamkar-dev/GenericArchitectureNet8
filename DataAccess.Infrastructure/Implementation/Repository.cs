namespace DataAccess.Infrastructure.Repository.Implementation;
using DataAccess.Entity;
using DataAccess.Infrastructure.Repository.Interfaces;

public class Repository<T>(ApplicationDbContext dbContext) : IRepository<T> where T : BaseEntity
{
    private readonly ApplicationDbContext _dbContext = dbContext;

    public async Task<T> CreateAsync(T entity)
    {
        await _dbContext.Set<T>().AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public Task DeleteAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<T>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _dbContext.Set<T>().FindAsync(id);
    }

    public Task<T> UpdateAsync(T entity)
    {
        throw new NotImplementedException();
    }
}

