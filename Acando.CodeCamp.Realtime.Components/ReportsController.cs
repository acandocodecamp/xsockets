using System.Threading.Tasks;
using XSockets.Core.Common.Socket.Event.Interface;
using XSockets.Core.XSocket;
using XSockets.Core.XSocket.Helpers;
using XSockets.Core.XSocket.Model;
using XSockets.Plugin.Framework;

namespace Acando.CodeCamp.Realtime
{
    public class ReportsController : XSocketController
    {
        private readonly ReportStorage _reportStorage;

        public ReportsController()
        {
            _reportStorage = Composable.GetExport<ReportStorage>();
        }

        public override Task OnOpened()
        {
            ReportModel[] reports = _reportStorage.GetReports("some username");
            return this.Invoke(reports, "initialReports");
        }

        public override Task OnReopened()
        {
            this.OnlinePublish();
            return Task.FromResult(true);
        }

        public override Task OnClosed()
        {
            //this.OfflineSubscribe("newReport");
            return Task.FromResult(true);
        }

        //public void NewReport(ReportModel report)
        //{
        //    this.Queue(DeliveryType.Rpc, new Message(null, report, "newReport", Alias));
        //    this.InvokeTo(x => x.PersistentId == PersistentId, report, "newReport");
        //    this.InvokeToAll("hej", "newReport");
        //}

        public override void OnMessage(IMessage message)
        {
            //
        }
    }
}
