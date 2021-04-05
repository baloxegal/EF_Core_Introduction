using System;
using System.Collections.Generic;

namespace EF_Core_Introduction
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> FindAll();
        IEnumerable<T> FindByPredicate(Func<T, bool> predicate);
        T FindById(int id);
        void Insert(T obj);
        void InsertRange(params T[] obj);
        void Update(T obj);
        bool Delete(int id);
        bool Delete(T obj);
        void Save();
    }
}
