using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TracKing.Infrastructure.Command
{
    public class ChangeUserCommand : ICommand
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public decimal Balance { get; set; }
        public double Share { get; set; }
    }
}
