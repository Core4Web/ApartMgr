using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ApartMgr.Data
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> Table { get; }
        IEnumerable<T> GetAll();
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where);
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "");
        T GetById(long id);
        T GetById(string id);
        T Get(Expression<Func<T, bool>> where);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> where);
        void Save();
        bool Commit();
    }

    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private ApartMgrContext _context;
        private readonly DbSet<T> _dbset;

        public GenericRepository(ApartMgrContext context)
        {
            _context = context;
            _dbset = _context.Set<T>();
        }

        public virtual IQueryable<T> Table
        {
            get { return _dbset; }
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _dbset.ToList();
        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return _dbset.Where(where).ToList();
        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<T> query = _dbset;
            if (where != null)
            {
                query = query.Where(where);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
                return orderBy(query).ToList();
            else
                return query.ToList();
        }


        public virtual T GetById(long id)
        {
            return _dbset.Find(id);
        }

        public virtual T GetById(string id)
        {
            return _dbset.Find(id);
        }

        public virtual T Get(Expression<Func<T, bool>> where)
        {
            return _dbset.Where(where).FirstOrDefault<T>();
        }

        public virtual void Add(T entity)
        {
            _dbset.Add(entity);
        }

        public virtual void Update(T entity)
        {
            _dbset.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            _dbset.Remove(entity);
        }

        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = _dbset.Where(where).AsEnumerable<T>();
            foreach (T obj in objects)
                _dbset.Remove(obj);
        }

        public virtual void Save()
        {
            _context.SaveChanges();
        }
        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
