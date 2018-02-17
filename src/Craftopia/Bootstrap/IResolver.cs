using System.Collections.Generic;

namespace Craftopia.Bootstrap
{
    public interface IResolver
    {
        T Resolve<T>();
        IEnumerable<T> ResolveAll<T>();
    }
}
