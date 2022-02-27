using System.ComponentModel.DataAnnotations;
using System.Text.Json;
namespace Dotnet.Models;

public record Item{
    [Required]
    [StringLength(40, ErrorMessage = "Data too long for name ")] 
    public string itemName{get;set;}
    [Required]
    public int price{get;set;}
    [Required]
    [StringLength(80, ErrorMessage = "Too large description")] 
    public string description{get;set;}
    
    public string? image{get;set;}


}