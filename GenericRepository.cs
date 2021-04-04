using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EF_Core_Introduction
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public DbContext _context;
        public DbSet<T> _table;

        public GenericRepository()
        {
                
        }

        public GenericRepository(DbContext context)
        {
            _context = context;
            _table = context.Set<T>();
        }
        public IEnumerable<T> FindAll()
        {
            return _table.AsNoTracking().ToList();
        }
        public IEnumerable<T> FindByPredicate(Func<T, bool> predicate)
        {
            return _table.AsNoTracking().Where(predicate).ToList();
        }
        public T FindById(int id)
        {
            return _table.Find(id);
        }
        public void Insert(T obj)
        {
            _table.Add(obj);
            _context.SaveChanges();
        }
        public void Update(T obj)
        {
            _table.Update(obj);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            T existing = _table.Find(id);
            _table.Remove(existing);
            _context.SaveChanges();
        }
        public void Delete(T obj)
        {
            _table.Remove(obj);
            _context.SaveChanges();
        }
    }
}
