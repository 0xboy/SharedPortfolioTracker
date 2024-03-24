using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TracKing.Infrastructure.Repository;
using TracKing.Infrastructure.Aggregate;

namespace TracKing.Infrastructure.Command
{
    public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand>
    {
        private readonly IWriteRepository<User> _writeRepository;

        public CreateUserCommandHandler(IWriteRepository<User> writeRepository) 
        {
            _writeRepository = writeRepository;        
        }

        public void Execute(CreateUserCommand command)
        {
            if (command == null) 
            { 
                throw new ArgumentNullException(nameof(command)); 
            }

            var user = new User();

            user.UserName = command.UserName;

            user.Password = command.Password;

            user.Name = command.Name;

            user.Balance = command.Balance;

            user.Share = command.Share;

            _writeRepository.Add(user);

            _writeRepository.Save();
        }
    }
}
