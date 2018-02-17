using System.Collections.Generic;
using Autofac;
using Autofac.Core;

namespace Craftopia.Bootstrap
{
    public class AutofacResolver : IResolver
    {

        private IContainer _IContainer;

        public AutofacResolver(IContainer container)
        {
            _IContainer = container;
        }

        public T Resolve<T>()
        {
            return _IContainer.Resolve<T>();
        }

        public IEnumerable<T> ResolveAll<T>()
        {
            return _IContainer.Resolve<IEnumerable<T>>();
        }

        //public IEnumerable<T> ResolveAllWithConstructorParam<T, TParam>(TParam param)
        //{
        //    return _IContainer.Resolve<IEnumerable<T>>(new ResolvedParameter(typeof(TParam), param));
        //}

        //public T ResolveWithConstructorParam<T, TParam>(TParam param)
        //{           
        //    return _IContainer.Resolve<T>(new TypedParameter(typeof(TParam), param));
        //}
    }
}
