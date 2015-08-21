using System;
using XSockets.Core.Common.Socket;
using XSockets.Plugin.Framework;

namespace Acando.CodeCamp.XSockets
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var container = Composable.GetExport<IXSocketServerContainer>())
            {
                container.Start();
                foreach (var server in container.Servers)
                {
                    Console.WriteLine(server.ConfigurationSetting.Endpoint);
                }
                Console.WriteLine("Server started, hit enter to quit");
                Console.ReadLine();
            }
        }
    }
}
