using System;

namespace Craftopia
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            var programInstance = new CraftopiaGameProgram();
            programInstance.Run();          
        }
    }
}
