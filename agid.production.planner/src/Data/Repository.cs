using Microsoft.EntityFrameworkCore;

namespace Production.Planner.Data;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<T> _dbSet;

    public Repository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }

    public async Task AddRangeAsync(List<T> entities, int batchSize = 1000)
    {
         for (int i = 0; i < entities.Count; i += batchSize)
            {
                using (var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        // Your data access operations (Add, Update, Remove)
                        _context.ChangeTracker.Clear();

                        var batch = entities.Skip(i).Take(batchSize);
                        await _context.AddRangeAsync(batch);

                        await _context.SaveChangesAsync(); // Save changes within the transaction
                        transaction.Commit(); // Commit the transaction if successful
                    }
                    catch (Exception)
                    {
                        transaction.Rollback(); // Rollback on errors
                        throw; // Re-throw the exception for handling
                    }
                }
            }
    }
}