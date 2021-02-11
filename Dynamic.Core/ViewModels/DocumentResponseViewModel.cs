namespace Dynamic.Core.ViewModels
{
    using Dynamic.Data.Models;
    using MongoDB.Bson;

    public class DocumentResponseViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public DocumentResponseViewModel(Document document)
        {
            Id = document.Id.ToString();
            Name = document.Name;
        }
    }
}
