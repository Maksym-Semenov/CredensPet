namespace CredensPet.Infrastructure;

public interface IService<T> where T : class
{
    Task AddAsync(T entity);

    Task DeleteAsync(T entity);

    T Find(params object[] keys);

    IQueryable<T> FindAll();

    Task<T> FindAsync(params object[] keys);

    Task<T> FirstOrDefault(params object[] keys);

    IEnumerable<T> GetAll();

    void SaveChanges();
    Task SaveChangesAsync();

    Task UpdateAsync(T entity);

}