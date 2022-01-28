using Dotnet.DTOS;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
namespace Dotnet.Models
{
    public record User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? _id { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string? email { get; set; }
        public string? contactNumber { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? password { get; set; }
        public UserDTO AsDTO()
        {
            UserDTO dto = new()
            {
                _id = this._id,
                firstName = this.firstName,
                lastName = this.lastName,
                email = this.email,
                contactNumber = this.contactNumber,
                password = this.password
            };
            return dto;
        }
    }
};

