namespace Dynamic.Data.Repositories.Interfaces
{
    using Dynamic.Data.Models;
    using System.Threading.Tasks;

    public interface IRepository<TDocument> where TDocument: class, IDocument
    {
        Task<TDocument> FindByIdAsync(string id);

        Task<TDocument> FindByNameAsync(string name);

        Task InsertOneAsync(TDocument document);

        Task ReplaceOneAsync(TDocument document);

        Task DeleteAllAsync();

        Task DeleteByIdAsync(string id);
    }
}
