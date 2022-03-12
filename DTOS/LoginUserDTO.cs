
using System.ComponentModel.DataAnnotations;
namespace Dotnet.DTOS;

public record LoginUserDTO{
    [Required]
    public string? contactNumber { get; set; }
    [Required]
    public string? password { get; set; }

}