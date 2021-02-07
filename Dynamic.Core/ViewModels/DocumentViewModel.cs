namespace Dynamic.Core.ViewModels
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class DocumentViewModel
    {
        
        public string Name { get; set; }

        [BsonExtraElements]
        public BsonDocument ExtraElements { get; set; }
    }
}
