using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;

namespace Acando.CodeCamp.Realtime.Data
{
    public static class DocumentDbExtensions
    {
        public static async Task<Document> UpsertAsync<TDocument>(this DocumentClient client, DocumentCollection documentCollection, TDocument document)
            where TDocument : Document
        {
            var documentExists = false;

            try
            {
                return await client.CreateDocumentAsync(documentCollection.SelfLink, document);
            }
            catch (DocumentClientException ex)
            {
                if (ex.StatusCode != null && ex.StatusCode == HttpStatusCode.Conflict)
                {
                    documentExists = true;
                }
            }

            if (documentExists)
            {
                Document matchedDocument = client.CreateDocumentQuery<TDocument>(documentCollection.DocumentsLink).Where(d => d.Id == document.Id).AsEnumerable().FirstOrDefault();
                if (matchedDocument == null)
                {
                    return await UpsertAsync(client, documentCollection, document);
                }
                return await client.ReplaceDocumentAsync(matchedDocument.SelfLink, document);
            }
            return await Task.FromResult(new Document());
        }

        public static async Task<Database> GetDatabase(this DocumentClient client, string databaseName)
        {
            if (client.CreateDatabaseQuery().Where(db => db.Id == databaseName).AsEnumerable().Any())
            {
                return client.CreateDatabaseQuery().Where(db => db.Id == databaseName).AsEnumerable().FirstOrDefault();
            }
            return await client.CreateDatabaseAsync(new Database { Id = databaseName });
        }

        public static async Task<DocumentCollection> GetCollection(this DocumentClient client, Database database, string collectionName)
        {
            if (client.CreateDocumentCollectionQuery(database.SelfLink).Where(coll => coll.Id == collectionName).AsEnumerable().Any())
            {
                return client.CreateDocumentCollectionQuery(database.SelfLink).Where(coll => coll.Id == collectionName).AsEnumerable().FirstOrDefault();
            }
            return await client.CreateDocumentCollectionAsync(database.SelfLink, new DocumentCollection { Id = collectionName });
        }
    }
}
