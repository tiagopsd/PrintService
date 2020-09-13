using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace PrintService.Domain.Interface
{
    public interface IRepository
    {
        T GetById<T>(params object[] id) where T : class;
        T FirstOrDefault<T>(Expression<Func<T, bool>> predicate) where T : class;
        List<T> ToList<T>(Expression<Func<T, bool>> predicate) where T: class;
    }
}
