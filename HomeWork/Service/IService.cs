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
        void Delete(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetByLambdaExpression(Func<T, bool> lambda);
    }
}
