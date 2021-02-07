namespace Dynamic.Data.Models
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public interface IDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        ObjectId Id { get; set; }

        string Name { get; set; }

        [BsonExtraElements]
        public BsonDocument ExtraElements { get; set; }
    }
}
