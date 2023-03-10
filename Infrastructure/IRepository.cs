namespace CredensPet.Infrastructure;

public interface IRepository<T> where T : class
{
    Task AddAsync(T entity);

    Task DeleteAsync(T entity);

    IQueryable<T> FindAll();

    Task SaveChangesAsync();

    Task UpdateAsync(T entity);

}