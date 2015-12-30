using Autofac;

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
    }
}
