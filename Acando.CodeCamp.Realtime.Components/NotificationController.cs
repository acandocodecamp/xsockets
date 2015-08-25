using XSockets.Core.XSocket;
using XSockets.Core.XSocket.Helpers;

namespace Acando.CodeCamp.Realtime
{
    public class NotificationController : XSocketController
    {
        public void SendMessage(string message)
        {
            this.PublishToAll(message, "newMessage");
        }
    }
}
