namespace Dynamic.Data
{
    using MongoDB.Driver;

    public class Context
    {
        private string connectionString;
        private string databaseName;
        private string defaultCollectionName;

        private readonly IMongoClient client;
        private readonly IMongoDatabase database;

        public IMongoClient Client { get { return client; } }
        public IMongoDatabase Database { get { return database; } }
        public string DefaultCollectionName { get { return defaultCollectionName; } }

        public Context(string connectionString, string databaseName, string defaultCollectionName)
        {
            this.connectionString = connectionString;
            this.databaseName = databaseName;
            this.defaultCollectionName = defaultCollectionName;

            client = new MongoClient(connectionString);
            database = client.GetDatabase(databaseName);
            
        }
    }
}
