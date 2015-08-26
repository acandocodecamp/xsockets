using System;
using XSockets.Core.Common.Enterprise;
using XSockets.Core.Common.Socket;
using XSockets.Plugin.Framework;

namespace Acando.CodeCamp.Realtime
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var container = Composable.GetExport<IXSocketServerContainer>())
            {
                container.Start();

                Composable.GetExport<IXSocketsScaleOut>().AddScaleOut("ws://127.0.0.1:4503");

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
