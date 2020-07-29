using System.IO;

namespace Craftopia
{
    public interface IFileStreamProvider
    {
        Stream OpenStream(string content);

    }
}
