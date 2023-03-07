﻿namespace CredensPet.Infrastructure;

public interface IRepository<T> where T : class
{
    //IQueryable<T> GetAllQ();
    IEnumerable<T> GetAll();
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
    //Task SaveChangesAsync();
    void SaveChanges();
    Task<T> FindAsync(int? id);

}