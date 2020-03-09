using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrintService.Domain.Interface
{
    public interface IContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        int SaveChanges();
    }
}
