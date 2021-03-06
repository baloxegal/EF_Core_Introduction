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
            _context = new LibraryContext();
            _table = _context.Set<T>();
        }

        public GenericRepository(DbContextOptions options)
        {
            _context = new DbContext((DbContextOptions<LibraryContext>)options);
            _table = _context.Set<T>();
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
        }
        public void InsertRange(params T[] obj)
        {

            foreach (var o in obj)
            {
                _table.Add(o);
            }
        }
        public void Update(T obj)
        {
            _table.Update(obj);
        }
        public bool Delete(int id)
        {
            T existing = _table.Find(id);
            if(existing != null)
            {
                _table.Remove(existing);
                return true;
            }
                return false;
        }
        public bool Delete(T obj)
        {
            if (obj != null)
            {
                _table.Remove(obj);
                return true;
            }
            return false;
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
