using Microsoft.Xna.Framework;
using System.IO;

namespace Monogame.Base
{
    public class TitleContainerFileStreamProvider : IFileStreamProvider
    {
        public Stream OpenStream(string name)
        {
            var filePath = $"/Content/{name}";
            return TitleContainer.OpenStream(filePath);
        }
    }

}
