using Dotnet.DTOS;
namespace Dotnet.Models
{
    public record User{
        public string? firstName {get;set;}
        public string? lastName {get;set;}
        public string? email {get;set;}
        public string? contactNumber {get;set;}
        public string? password {get;set;}
        public UserDTO AsDTO(){
            UserDTO dto = new(){
                firstName=this.firstName,
                lastName=this.lastName,
                email=this.email,
                contactNumber=this.contactNumber,
                password = this.password
            };
            return dto;
        }
    }
};

