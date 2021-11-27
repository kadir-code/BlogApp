using BlogApp.Infrastructure.Context;
using BlogApp.Infrastructure.Repositories.Interface.BaseRepository;
using BlogApp.Model.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BlogApp.Infrastructure.Repositories.Abstract
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly DataContext _context;
        protected readonly DbSet<T> _table;

        public BaseRepository(DataContext dataContext)
        {
            this._context = dataContext;
            this._table = _context.Set<T>();
        }
        public void Create(T entity)
        {

            _table.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            entity.Status = Model.Enums.Status.Passive;
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            entity.Status = Model.Enums.Status.Modified;
            _context.SaveChanges();
        }
        public T GetDefault(Expression<Func<T, bool>> expression)
        {
            return _table.FirstOrDefault(expression);
        }

        public List<T> GetDefaults(Expression<Func<T, bool>> expression)
        {
            return _table.Where(expression).ToList();
        }
        public TResult GetByDefault<TResult>(Expression<Func<T, TResult>> selector,
                                             Expression<Func<T, bool>> expression,
                                             Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            IQueryable<T> query = _table;

            if (include != null)
            {
                query = include(query);
            }

            if (expression != null)
            {
                query = query.Where(expression);
            }

            return query.Select(selector).FirstOrDefault();
        }

        public List<TResult> GetByDefaults<TResult>(Expression<Func<T, TResult>> selector,
                                                    Expression<Func<T, bool>> expression,
                                                    Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
                                                    Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null)
        {
            IQueryable<T> query = _table;

            if (include != null)
            {
                query = include(query);
            }

            if (expression != null)
            {
                query = query.Where(expression);
            }
            if (orderby != null)
            {

                return orderby(query).Select(selector).ToList();
            }
            return query.Select(selector).ToList();
        }

        public bool Any(Expression<Func<T, bool>> expression)
        {
            return _table.Any(expression);
        }
    }
}
