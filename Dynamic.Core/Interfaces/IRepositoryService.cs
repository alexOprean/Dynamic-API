namespace Dynamic.Core.Interfaces
{
    using Dynamic.Data.Models;
    using Dynamic.Data.Repositories.Interfaces;
    using System.Threading.Tasks;
    public interface IRepositoryService
    {
        Task<IRepository<Document>> GetRepositoryAsync();
    }
}
