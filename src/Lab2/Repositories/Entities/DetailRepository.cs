using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.AuxiliaryInterfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repositories.Entities;

public class DetailRepository<T> : IRepository<T>
    where T : IModel
{
    private Dictionary<string, T> _details = new();
    public T GetByName(string name)
    {
        return _details[name];
    }

    public void Add(T item)
    {
        _details.Add(item.Model, item);
    }

    public void Remove(T item)
    {
        _details.Remove(item.Model);
    }

    public void Update(T item)
    {
        _details[item.Model] = item;
    }
}