using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TracKing.Infrastructure.IoC
{
    public class RegistredObject
    {
        public Type TypeToResolve { get; private set; }
        public Type ConreateType { get; private set; }
        public LifeCycle LifeCycle { get; private set; }
        public object Instance { get; private set; }

        public RegistredObject(Type typeToResolve, Type concreateType, LifeCycle lifeCycle) 
        { 
            TypeToResolve = typeToResolve;
            ConreateType = concreateType;
            LifeCycle = lifeCycle;
        }

        public void CreateInstance(params object[] args) 
        {
            Instance = Activator.CreateInstance(ConreateType,args);
        }
    }
}
