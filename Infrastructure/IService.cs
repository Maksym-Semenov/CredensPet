namespace CredensPet.Infrastructure;

public interface IService<T> where T : class
{
    //IQueryable<T> GetAllQ();
    IEnumerable<T> GetAll();
    Task Add(T entity);
    void Update(T entity);
    void Delete(T entity);
    Task SaveChangesAsync();
}