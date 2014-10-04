using System;
using System.Collections.Generic;

namespace HomeWork.Repository
{
    public interface IRepository<T> : IDisposable
    {
        T GetById(int id);
        void Add(T t);
        void Update(T t);
        void Delete(T t);
        IEnumerable<T> GetAll();
    }
}