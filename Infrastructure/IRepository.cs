namespace CredensPet.Infrastructure;

public interface IRepository<T> where T : class
{
    //IQueryable<T> GetAll();
    IEnumerable<T> GetAll();
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);

}