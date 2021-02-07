namespace Dynamic.Business.Services
{
    using AutoMapper;
    using Dynamic.Core.Interfaces;
    using Dynamic.Core.ViewModels;
    using Dynamic.Data.Models;
    using Dynamic.Data.Repositories.Interfaces;
    using MongoDB.Bson;
    using System.Threading.Tasks;

    public class DynamicService : IDynamicService
    {
        private IRepositoryService repositoryService;
        private IMapper mapper;
        public DynamicService(IRepositoryService repositoryService, IMapper mapper)
        {
            this.repositoryService = repositoryService;
            this.mapper = mapper;
        }

        public async Task CreateDocumentAsync(DocumentViewModel entityViewModel)
        {
            IRepository<Document> repository = await repositoryService.GetRepositoryAsync();

            Document existentDocument = await repository.FindByNameAsync(entityViewModel.Name);

            if(existentDocument != null)
            {
                await UpdateDocumentAsync(entityViewModel, existentDocument.Id);
                return;
            }

            Document doc = mapper.Map<Document>(entityViewModel);
            
            await repository.InsertOneAsync(doc);
        }

        public async Task DeleteByIdAsync(string id)
        {
            IRepository<Document> repository = await repositoryService.GetRepositoryAsync();

            await repository.DeleteByIdAsync(id);
        }

        public async Task DeleteAllDocuments()
        {
            IRepository<Document> repository = await repositoryService.GetRepositoryAsync();

            await repository.DeleteAllAsync();
        }

        private async Task UpdateDocumentAsync(DocumentViewModel entityViewModel, ObjectId id)
        {
            IRepository<Document> repository = await repositoryService.GetRepositoryAsync();

            Document doc = mapper.Map<Document>(entityViewModel);
            doc.Id = id;

            await repository.ReplaceOneAsync(doc);
        }

        public async Task<DocumentViewModel> GetByIdAsync(string id)
        {
            IRepository<Document> repository = await repositoryService.GetRepositoryAsync();

            Document doc = await repository.FindByIdAsync(id);

            return mapper.Map<DocumentViewModel>(doc);
        }

        public async Task<DocumentViewModel> GetByNameAsync(string name)
        {
            IRepository<Document> repository = await repositoryService.GetRepositoryAsync();

            Document doc = await repository.FindByNameAsync(name);

            return mapper.Map<DocumentViewModel>(doc);
        }
    }
}
