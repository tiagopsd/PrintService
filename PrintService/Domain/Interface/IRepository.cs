using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PrintService.Domain.Interface
{
    public interface IRepository
    {
        Task<T> GetById<T>(params object[] id) where T : class;
        Task<T> FirstOrDefault<T>(Expression<Func<T, bool>> predicate) where T : class;
        Task<List<T>> ToList<T>(Expression<Func<T, bool>> predicate) where T: class;
    }
}
