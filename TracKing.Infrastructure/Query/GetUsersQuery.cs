using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TracKing.Infrastructure.Aggregate;

namespace TracKing.Infrastructure.Query
{
    public class GetUsersQuery : IQuery
    {
        public Expression<Func<User, bool>> Predicate { get; set; }
    }
}
