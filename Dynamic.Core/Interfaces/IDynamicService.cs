namespace Dynamic.Core.Interfaces
{
    using Dynamic.Core.ViewModels;
    using System.Threading.Tasks;

    public interface IDynamicService
    {
        Task CreateDocumentAsync(DocumentViewModel entityViewModel);

        Task DeleteByIdAsync(string id);

        Task DeleteAllDocuments();

        Task<DocumentViewModel> GetByIdAsync(string id);

        Task<DocumentViewModel> GetByNameAsync(string name);
    }
}
