namespace Itmo.ObjectOrientedProgramming.Lab2.Repositories.Entities;

public interface IRepository<T>
{
    T GetByName(string name);
    void Add(T item);
    void Remove(T item);
    void Update(T item);
}