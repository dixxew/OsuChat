using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ChatWebServer.Models
{
    public class Message
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public uint FromId { get; set; }
        public bool IsInGroup { get; set; }
        public uint ToId { get; set; }
        public string MessageText { get; set; }
        public DateTime Time { get; set; }
    }
}
