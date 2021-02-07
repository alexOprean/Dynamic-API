namespace Dynamic.Core.Services
{
    using Dynamic.Core.Interfaces;
    using Dynamic.Data;
    using Dynamic.Data.Models;
    using Dynamic.Data.Repositories.Interfaces;
    using Dynamic.Data.Repositories.Services;
    using System.Threading.Tasks;

    public class RepositoryService : IRepositoryService
    {
        private Context dBContext;

        public RepositoryService(Context dBContext)
        {
            this.dBContext = dBContext;
        }

        public async Task<IRepository<Document>> GetRepositoryAsync()
        {
            return await Task.FromResult(new Repository<Document>(this.dBContext));
        }
    }
}
