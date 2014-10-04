using System;
using System.Collections.Generic;

namespace HomeWork.Service
{
    public interface IService<T> : IDisposable
    {
        T GetById(int id);
        void Add(T t);
        void Update(T t);
        void Delete(T t);
        IEnumerable<T> GetAll();
    }
}
