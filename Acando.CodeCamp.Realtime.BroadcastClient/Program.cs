using System;
using System.Runtime.Remoting.Channels;
using System.Threading.Tasks;
using XSockets.Client40;
using XSockets.Client40.Common.Interfaces;

namespace Acando.CodeCamp.Realtime
{
    class Program
    {
        static void Main(string[] args)
        {
            //Wait for server to start
            Task.Delay(10000).Wait();

            var connection = new XSocketClient("ws://localhost:4502", "http://localhost", "Notification");
            IController controller = connection.Controller("Notification");

            connection.OnConnected += (sender, eventArgs) => Console.WriteLine("Connected to host");
            connection.Open();
            
            controller.OnOpen += (sender, eventArgs) => Console.WriteLine("Ready to send messages!");
            controller.OnError += (sender, errorArgs) => Console.WriteLine("An error occured: " + errorArgs.Exception);
            string message = null;
            while (message != "q")
            {
                message = Console.ReadLine();
                controller.Invoke("sendmessage", message);
            }
        }
    }
}
