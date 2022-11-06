using Entities;
using Repositori.GenericRepository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositori.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly FilmDbContext _db;
        protected readonly DbSet<T> _table = null;
        public GenericRepository()
        {
            _db = new FilmDbContext();
            _table = _db.Set<T>();
        }
        public IEnumerable<T> SelectAll()
        {
            return _table.ToList();
        }
        public T SelectById(object id)
        {
            try
            {
                return _table.Find(id);
            }
            catch
            {
                return null;
            }
        }
        public void Insert(T obj)
        {
            _table.Add(obj);
        }
        public void Update(T obj)
        {
            _table.Attach(obj);
            _db.Entry(obj).State = EntityState.Modified;
        }
        public void Delete(object id)
        {
            T existing = _table.Find(id);
            _table.Remove(existing);
        }
        public void DeleteByItem(T obj)
        {
            _table.Remove(obj);
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
