using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TracKing.Infrastructure.Aggregate;
using TracKing.Infrastructure.Repository;

namespace TracKing.Infrastructure.Query
{
    public class GetUsersQueryHandler : IQueryHandler<GetUsersQuery, IQueryable<User>>
    {
        private readonly IReadRepository<User> _readRepository;

        public GetUsersQueryHandler(IReadRepository<User> readRepository) 
        {
            _readRepository = readRepository;
        }

        public IQueryable<User> Query(GetUsersQuery query)
        {
            return _readRepository.GetAll(query.Predicate);
        }
    }
}
