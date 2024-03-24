using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TracKing.Infrastructure.IoC
{
    public class SimpleContainer : IContainer
    {
        #region Constructor
        private static object _lock = new object();
        private static SimpleContainer _ioCResolver;
        public static SimpleContainer instance 
        { 
            get { 
                lock (_lock)
                {
                    if (_ioCResolver is null)
                    {
                        _ioCResolver = new SimpleContainer();
                    }
                }
                return _ioCResolver;
            } 
        }
        #endregion

        private readonly IList<RegistredObject> registredObjects = new List<RegistredObject>();
        public IList<RegistredObject> RegistredObjects { get { return instance.registredObjects; } }


        public void Register<TTypeToResolve, TConcreate>()
        {
            Register<TTypeToResolve, TConcreate>(LifeCycle.Singleton);
        }

        public void Register<TTypeToResolve, TConcreate>(LifeCycle lifeCycle)
        {
            RegistredObjects.Add(new RegistredObject(typeof(TTypeToResolve), typeof(TConcreate),lifeCycle));
        }

        public TTypeToResolve Resolve<TTypeToResolve>()
        {
            return (TTypeToResolve)ResolveObject(typeof(TTypeToResolve));
        }

        public object Resolve(Type typeToResolve)
        {
            return ResolveObject(typeToResolve);
        }

        private object ResolveObject(Type typeToResolve) 
        {
            var registredObject = RegistredObjects.FirstOrDefault(o => o.TypeToResolve == typeToResolve);

            if (registredObject is null)
            {
                throw new TypeNotRegistredException(string.Format("The type {0} has not been registred", typeToResolve.Name));
            }

            return GetInstance(registredObject);

        }

        private object GetInstance(RegistredObject registredObject) 
        {
            if (registredObject.Instance is null || registredObject.LifeCycle == LifeCycle.Transient)
            {
                IEnumerable<object> parameters = ResolveConstructorParamaters(registredObject);
                object[] paramArray = parameters.ToArray();
                registredObject.CreateInstance(paramArray);
            }
            return registredObject.Instance;
        }

        private IEnumerable<object> ResolveConstructorParamaters(RegistredObject registredObject) 
        {
            var constructionInfo = registredObject.ConreateType.GetConstructors().First();

            foreach (var parameter in constructionInfo.GetParameters())
            {
                yield return ResolveObject(parameter.ParameterType);
            }
        }

    }
}
