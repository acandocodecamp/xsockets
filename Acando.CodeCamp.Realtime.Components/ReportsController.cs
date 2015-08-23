using System.Threading.Tasks;
using XSockets.Core.Common.Protocol;
using XSockets.Core.Common.Socket.Event.Interface;
using XSockets.Core.XSocket;
using XSockets.Core.XSocket.Helpers;
using XSockets.Core.XSocket.Model;

namespace Acando.CodeCamp.Realtime
{
    public class ReportsController : XSocketController
    {
        public ReportsController()
        {
        }

        public override Task OnOpened()
        {
            return Task.FromResult(true);
        }

        public override Task OnReopened()
        {
            this.OnlinePublish();
            return Task.FromResult(true);
        }

        public override Task OnClosed()
        {
            this.OfflineSubscribe("newReport");
            return Task.FromResult(true);
        }

        public void NewReport(ReportModel report)
        {
            this.Queue(DeliveryType.Rpc, new Message(null, report, "newReport", Alias));
            this.InvokeTo(x => x.PersistentId == PersistentId, report, "newReport");
            this.InvokeToAll( "hej", "newReport");
        }

        public override void OnMessage(IMessage message)
        {
            //
        }
    }
}
