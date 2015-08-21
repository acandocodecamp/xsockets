using System;
using XSockets.Core.Common.Socket.Event.Interface;
using XSockets.Core.XSocket;
using XSockets.Core.XSocket.Helpers;

namespace Acando.CodeCamp.Realtime
{
    public class ReportsController : XSocketController
    {
        public override void OnMessage(IMessage message)
        {
            Console.WriteLine(message.ToString());
            this.InvokeToAll(message);
        }
    }
}
