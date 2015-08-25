using System;
using XSockets.Core.Common.Interceptor;

namespace Acando.CodeCamp.Realtime.Interceptors
{
    public class RealtimeErrorInterceptor : IErrorInterceptor
    {
        public void OnError(Exception exception)
        {
            Console.WriteLine("An error occured {0}", exception);
        }
    }
}
