namespace Dynamic.Data.Repositories.Services
{
    using Dynamic.Data.Models;
    using Dynamic.Data.Repositories.Interfaces;
    using MongoDB.Bson;
    using MongoDB.Driver;
    using System.Threading.Tasks;

    public class Repository<TDocument>: IRepository<TDocument> where TDocument: class, IDocument
    {
        private readonly IMongoCollection<TDocument> collection;

        public Repository(Context dbContext)
        {
            collection = dbContext.Database.GetCollection<TDocument>(dbContext.DefaultCollectionName);
        }

        public async Task<TDocument> FindByIdAsync(string id)
        {
            var objectId = new ObjectId(id);
            var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, objectId);
            return await collection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task<TDocument> FindByNameAsync(string name)
        {
            var filter = Builders<TDocument>.Filter.Eq(doc => doc.Name, name);
            return await collection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task InsertOneAsync(TDocument document)
        {
            await collection.InsertOneAsync(document);
        }

        public async Task ReplaceOneAsync(TDocument document)
        {
            var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, document.Id);
            await collection.FindOneAndReplaceAsync(filter, document);
        }

        public async Task DeleteByIdAsync(string id)
        {
            var objectId = new ObjectId(id);
            var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, objectId);
            await collection.FindOneAndDeleteAsync(filter);
        }

        public async Task DeleteAllAsync()
        {
            await collection.DeleteManyAsync(Builders<TDocument>.Filter.Empty);
        }

    }
}
