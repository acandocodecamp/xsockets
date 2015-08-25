using System.Threading.Tasks;
using Acando.CodeCamp.Realtime.Data;
using XSockets.Core.Common.Socket.Event.Interface;
using XSockets.Core.XSocket;
using XSockets.Core.XSocket.Helpers;
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

        public async Task SaveReport(ReportModel report)
        {
            report.Approved = true;
            await _reportStorage.UpsertAsync(report);
            await Task.Delay(5000);
            await this.Invoke(report, "approvedReport");
        }

        public override Task OnOpened()
        {
            ReportModel[] reports = _reportStorage.GetReports();
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

        public override void OnMessage(IMessage message)
        {
            //
        }
    }
}
