using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TracKing.Infrastructure.Repository
{
    public interface IReadRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetAll(Expression<Func<T,bool>> prediacte);

        T Get(Expression<Func<T,bool>> predicate);
        T GetById(Guid Id);
    }
}
