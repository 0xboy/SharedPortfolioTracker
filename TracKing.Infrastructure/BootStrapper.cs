using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TracKing.Infrastructure.Aggregate;
using TracKing.Infrastructure.Command;
using TracKing.Infrastructure.Context;
using TracKing.Infrastructure.IoC;
using TracKing.Infrastructure.Query;
using TracKing.Infrastructure.Repository;

namespace TracKing.Infrastructure
{
    public static class BootStrapper
    {
        public static void Configure(IContainer container) 
        {
            container.Register<IContainer,SimpleContainer>();

            container.Register<ICommandDispatcher, CommandDispatcher>();
            container.Register<ICommandHandler<CreateUserCommand>, CreateUserCommandHandler>();
            container.Register<ICommandHandler<ChangeUserCommand>, ChangeUserCommadHandler>();

            container.Register<IQueryDispatcher, QueryDispatcher>();
            container.Register<IQueryHandler<GetUsersQuery, IQueryable<User>>, GetUsersQueryHandler>();

            container.Register<BaseContext, UserContext>();
            container.Register<IReadRepository<User>, BaseRepository<User>>();
            container.Register<IWriteRepository<User>, BaseRepository<User>>();
        }
    }
}
