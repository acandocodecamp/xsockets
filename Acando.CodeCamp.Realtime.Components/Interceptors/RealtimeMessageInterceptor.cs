using System;
using XSockets.Core.Common.Interceptor;
using XSockets.Core.Common.Protocol;
using XSockets.Core.Common.Socket.Event.Interface;

namespace Acando.CodeCamp.Realtime.Interceptors
{
    public class RealtimeMessageInterceptor : IMessageInterceptor
    {
        public void OnIncomingMessage(IXSocketProtocol protocol, IMessage message)
        {
            Console.WriteLine("In {0}", message);
        }

        public void OnOutgoingMessage(IXSocketProtocol protocol, IMessage message)
        {
            Console.WriteLine("Out {0}", message);
        }
    }
}