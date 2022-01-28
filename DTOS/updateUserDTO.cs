using System.ComponentModel.DataAnnotations;
namespace Dotnet.DTOS
{
    public record updateUserDTO
    {

        [Required(ErrorMessage = "password is required")]
        public string? password { get; set; }
    }
};

