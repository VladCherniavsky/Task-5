using System;
using System.Collections.Generic;

namespace DAL.Repositories
{
    public interface IGenericRepository<T> where T :class
    {
        IList<T> GetAll();
        IList<T> GetList(Func<T, bool> whereaFunc);

        T GetSingle (Func<T, bool> whereFunc);
        void Add(T item);
        void Update(T item);
        void Delete(int itemId);

    }
}
