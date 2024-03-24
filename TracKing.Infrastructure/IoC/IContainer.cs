using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TracKing.Infrastructure.IoC
{
    public interface IContainer
    {
        void Register<TTypeToResolve, TConcreate>();
        void Register<TTypeToResolve, TConcreate>(LifeCycle lifeCycle);

        TTypeToResolve Resolve<TTypeToResolve>();

        object Resolve(Type typeToResolve);
    }
}
