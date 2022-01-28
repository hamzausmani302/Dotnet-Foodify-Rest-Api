using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Dotnet.DTOS

{
    public record UserDTO
    {


        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? _id { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? email { get; set; }
        public string? contactNumber { get; set; }
        public string? password { get; set; }
    }
};

