using MongoDB.Driver;
using sandbox.web.api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


/// <summary>
/// Class <DocumentService> - service for handling MongoDB generec interactions
/// https://developer.okta.com/blog/2020/01/02/mongodb-csharp-aspnet-datastore
/// </summary>


namespace sandbox.web.api.Services
{
    public class DocumentService
    {
        private readonly MongoClient _client;
        private Dictionary<string, List<string>> _databasesAndCollections;

        public DocumentService(DatabaseSettings settings)
        {
            _client = new MongoClient(settings.ConnectionString);
        }
        public async Task<Dictionary<string, List<string>>> GetDatabasesAndCollections()
        {
            if (_databasesAndCollections != null) 
                return _databasesAndCollections;

            _databasesAndCollections = new Dictionary<string, List<string>>();
            var databasesResult = _client.ListDatabaseNames();

            await databasesResult.ForEachAsync(async databaseName =>
            {
                var collectionNames = new List<string>();
                var database = _client.GetDatabase(databaseName);
                var collectionNamesResult = database.ListCollectionNames();
                await collectionNamesResult.ForEachAsync(
                    collectionName => { collectionNames.Add(collectionName); });
                _databasesAndCollections.Add(databaseName, collectionNames);
            });

            return _databasesAndCollections;
        }
    }
}
