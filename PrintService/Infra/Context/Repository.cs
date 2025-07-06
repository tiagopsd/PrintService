using Microsoft.EntityFrameworkCore;
using PrintService.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PrintService.Infra
{
    public class Repository : IRepository
    {
        private readonly IContext _context;
        public Repository(IContext context)
        {
            _context = context;
        }

        public async Task<T> GetById<T>(params object[] id) where T : class
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> FirstOrDefault<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return await _context.Set<T>().FirstOrDefaultAsync(predicate);
        }

        public async Task<List<T>> ToList<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }

        public void Update<T>(params T[] entity) where T : class, IEntidade
        {
            _context.Set<T>().UpdateRange(entity);
        }
    }
}
