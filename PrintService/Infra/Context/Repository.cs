using Castle.Core.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PrintService.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace PrintService.Infra
{
    public class Repository : IRepository
    {
        private IContext _context;
        public Repository(IContext context)
        {
            _context = context;
        }

        public T GetById<T>(params object[] id) where T : class
        {
            try
            {
                return _context.Set<T>().Find(id);
            }
            catch
            {
                return default;
            }
        }

        public T FirstOrDefault<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            try
            {
                return _context.Set<T>().FirstOrDefault(predicate);
            }
            catch
            {
                return default;
            }
        }

        public DbSet<T> Inject<T>() where T : class
        {
            try
            {
                return _context.Set<T>();
            }
            catch
            {
                return default;
            }
        }

        public void Dispose()
        {
        }

        public List<T> ToList<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            try
            {
                return _context.Set<T>().Where(predicate).ToList();
            }
            catch
            {
                return default;
            }
        }

        public void Update<T>(T entity) where T : class, IEntidade
        {
            try
            {
                object id = entity.GetType().GetProperty("Id").GetValue(entity, null);
                var original = _context.Set<T>().Find(id);

                _context.Entry(original).State = EntityState.Modified;
                _context.Entry(original).OriginalValues.SetValues(entity);
                _context.Entry(original).CurrentValues.SetValues(entity);
            }
            catch
            {
            }
        }
    }
}
