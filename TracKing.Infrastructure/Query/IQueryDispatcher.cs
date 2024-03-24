using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TracKing.Infrastructure.Query
{
    public interface IQueryDispatcher
    {
        TResult Query<TQuery, TResult>(TQuery query) where TQuery : IQuery;
    }
}
