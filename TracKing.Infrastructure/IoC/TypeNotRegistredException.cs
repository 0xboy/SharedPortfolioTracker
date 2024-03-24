using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TracKing.Infrastructure.IoC
{
    public  class TypeNotRegistredException : Exception
    {
        public TypeNotRegistredException(string message) : base(message) { }
    }
}
