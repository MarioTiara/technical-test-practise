namespace Production.Planner.Data;

public interface IRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task AddAsync(T entity);
    Task AddRangeAsync(List<T> entities, int batchSize = 1000);
    Task UpdateAsync(T entity);
    Task DeleteAsync(int id);
}