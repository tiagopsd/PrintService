using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PrintService.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace PrintService.Infra
{
    public class Repository : IRepository
    {
        private IServiceProvider _serviceProvider;
        private IServiceScope _serviceScope;

        public Repository(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public T GetById<T>(params object[] id) where T : class
        {
            try
            {
                using var scope = _serviceProvider.CreateScope();
                var repository = scope.ServiceProvider.GetService<IContext>();
                return repository.Set<T>().Find(id);
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
                using var scope = _serviceProvider.CreateScope();
                var repository = scope.ServiceProvider.GetService<IContext>();
                return repository.Set<T>().FirstOrDefault(predicate);
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
                _serviceScope = _serviceProvider.CreateScope();
                var repository = _serviceScope.ServiceProvider.GetService<IContext>();
                return repository.Set<T>();
            }
            catch
            {
                return default;
            }
        }

        public void Dispose()
        {
            if (_serviceScope != null)
                _serviceScope.Dispose();
        }

        public List<T> ToList<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            try
            {
                using var scope = _serviceProvider.CreateScope();
                var repository = scope.ServiceProvider.GetService<IContext>();
                return repository.Set<T>().Where(predicate).ToList();
            }
            catch
            {
                return default;
            }
        }
    }
}
