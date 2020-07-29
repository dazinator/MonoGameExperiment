using System;

namespace Craftopia
{
    public interface IGame : IDisposable
    {
        void Run();
    }
}
