namespace CredensPet.Infrastructure;

public interface IService<T> where T : class
{
    void Add(T entity);

    void Delete(T entity);

    T Find(params object[] keys);

    IEnumerable<T> GetAll();

    void SaveChanges();

    void Update(T entity);

}