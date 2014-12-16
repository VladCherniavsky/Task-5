using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DbModelContainer _context;

        public GenericRepository(DbModelContainer dbContext)
        {
            _context = dbContext;
        }


        public IList<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public IList<T> GetList(Func<T, bool> whereFunc)
        {
            return _context.Set<T>().Where(whereFunc).ToList();
        }

        public T GetSingle(Func<T, bool> whereFunc)
        {
            return _context.Set<T>().FirstOrDefault(whereFunc);
        }

        public void Add(T item)
        {
            _context.Set<T>().Add(item);
            _context.SaveChanges();
        }

        public void Update(T item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int itemId)
        {
            T t = _context.Set<T>().Find(itemId);
            _context.Set<T>().Remove(t);
            _context.SaveChanges();
        }
    }
}
