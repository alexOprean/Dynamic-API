namespace Dynamic.Api.Middleware
{
    using Dynamic.Core.ViewModels;
    using MongoDB.Bson;
    using MongoDB.Bson.IO;
    using MongoDB.Bson.Serialization;
    using System;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    public class BsonDocumentJsonConverter : JsonConverter<DocumentViewModel>
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DocumentViewModel);
        }

        public override DocumentViewModel Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using (var jsonDoc = JsonDocument.ParseValue(ref reader))
            {
                string docAsText = jsonDoc.RootElement.GetRawText();
                return BsonSerializer.Deserialize<DocumentViewModel>(docAsText);
            }
        }

        public override void Write(Utf8JsonWriter writer, DocumentViewModel value, JsonSerializerOptions options)
        {
            string docAsString = value.ToJson(new JsonWriterSettings { OutputMode = JsonOutputMode.RelaxedExtendedJson });
            JsonDocument jdoc = JsonDocument.Parse(docAsString);
            jdoc.WriteTo(writer);
        }
    }
}
