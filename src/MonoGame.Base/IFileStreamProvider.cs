using System.IO;

namespace Monogame.Base
{
    public interface IFileStreamProvider
    {
        Stream OpenStream(string content);

    }
}
