using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TracKing.Infrastructure.Repository;
using TracKing.Infrastructure.Aggregate;

namespace TracKing.Infrastructure.Command
{
    internal class ChangeUserCommadHandler : ICommandHandler<ChangeUserCommand>
    {
        private readonly IWriteRepository<User> _writeRepository;
        private readonly IReadRepository<User> _readRepository;
        public ChangeUserCommadHandler(IReadRepository<User> readRepository, IWriteRepository<User> writeRepository) 
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository; 
        }
        public void Execute(ChangeUserCommand command)
        {
            if (command is null)
            {
                throw new ArgumentNullException("command");
            }

            var user = new User();

            user.Id = command.Id;

            _writeRepository.DetectUpdate(user);

            user.Name = command.Name;

            user.UserName = command.UserName;

            user.Share = command.Share;

            user.Balance = command.Balance;

            user.Password = command.Password;

            _writeRepository.Save();
        }
    }
}
