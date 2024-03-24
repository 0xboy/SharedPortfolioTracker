using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TracKing.Infrastructure.IoC;

namespace TracKing.Infrastructure.Query
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly IContainer _container;

        public QueryDispatcher(IContainer container)
        {
            _container = container;
        }

        public TResult Query<TQuery, TResult>(TQuery query) where TQuery : IQuery
        {
            if (query is null)
            {
                throw new ArgumentNullException("query");
            }

            var handler = _container.Resolve<IQueryHandler<TQuery, TResult>>();

            if (handler is null)
            {
                throw new QueryHandlerNotFoundException(typeof(TQuery));
            }

            return handler.Query(query);
        }
    }
}
