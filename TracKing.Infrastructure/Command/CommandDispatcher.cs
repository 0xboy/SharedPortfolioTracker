using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TracKing.Infrastructure.IoC;

namespace TracKing.Infrastructure.Command
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IContainer _container;

        public CommandDispatcher(IContainer container)
        {
            _container = container;
        }

        public void Execute<TCommand>(TCommand command) where TCommand : ICommand
        {
            if (command is null)
            {
                throw new ArgumentException();
            }

            var handler = _container.Resolve<ICommandHandler<TCommand>>();

            if (handler is null)
            {
                throw new CommandHandlerNotFoundException(typeof(TCommand));
            }

            handler.Execute(command);
        }
    }
}
