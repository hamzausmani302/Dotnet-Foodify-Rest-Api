using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using Dotnet.Models;
namespace Dotnet.DTOS;

public record CreateRestaurantDTO{
    [Required]
    public string? RestName {get;set;}
    [Required]
    public string? Address {get;set;}
    [Required]
    [Range(1, 5, ErrorMessage = "Rating between 1-5")]
    public double? rating {get;set;}
    [Required]
    public string? cuisines {get;set;}

    public Item[] menu {get;set;}
    public Restaurant ToRestaurant(){
        return new Restaurant(){
            RestName = this.RestName,
            Address=this.Address,
            rating = this.rating,
            cuisines = this.cuisines,
            menu = this.menu

        };
    }




};