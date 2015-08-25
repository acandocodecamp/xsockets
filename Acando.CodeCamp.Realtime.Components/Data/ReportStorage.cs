using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using XSockets.Plugin.Framework.Attributes;

namespace Acando.CodeCamp.Realtime.Data
{
    [Export(typeof(ReportStorage))]
    public class ReportStorage : IDisposable
    {
        private Database _database;
        private DocumentCollection _documentCollection;
        private DocumentClient _client;
        private bool _disposed;

        const string Uri = "<uri>";
        const string Key = "<key>";

        public ReportStorage()
        {
            InitClient().Wait();
        }

        private async Task InitClient()
        {
            _client = new DocumentClient(new Uri(Uri), Key);
            _database = await _client.GetDatabase("reportdb");
            _documentCollection = await _client.GetCollection(_database, "reports");

            if (HasReports() == false)
            {
                await CreateDummyReportsAsync();
            }
        }

        public virtual ReportModel[] GetReports()
        {
            return _client.CreateDocumentQuery<ReportModel>(_documentCollection.DocumentsLink).AsEnumerable().ToArray();
        }

        public virtual async Task UpsertAsync(ReportModel report)
        {
            await _client.UpsertAsync(_documentCollection, report);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool HasReports()
        {
            return _client.CreateDocumentQuery<ReportModel>(_documentCollection.DocumentsLink).AsEnumerable().Any();
        }

        private async Task CreateDummyReportsAsync()
        {
            foreach (var report in DummyData.Reports)
            {
                await UpsertAsync(report);
            }
        }

        private void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            _disposed = true;

            if (disposing)
            {
                _client?.Dispose();
            }
        }
    }
}