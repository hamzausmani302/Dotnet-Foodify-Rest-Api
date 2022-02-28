
using System.ComponentModel.DataAnnotations;
using Dotnet.Models;
namespace Dotnet.DTOS;

public record UpdateRestaurantDTO{

     [Required]
   
    public string? RestName {get;set;}
    public string? Address {get;set;}

    [Range(1, 5, ErrorMessage = "Rating between 1-5")]
    public double? rating {get;set;}

    public string? cuisines {get;set;}

    
    public Item[]? menu {get;set;}

    public Restaurant toRestaurant(){
        return new Restaurant(){
            RestName=this.RestName,
            Address = this.Address,
            rating = this.rating,
            cuisines = this.cuisines,
            menu = this.menu
        };
    }
}