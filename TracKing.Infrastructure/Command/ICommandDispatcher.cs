using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TracKing.Infrastructure.Command
{
    public interface ICommandDispatcher
    {
        void Execute<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
