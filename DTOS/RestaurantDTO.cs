using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using Dotnet.Models;
namespace Dotnet.DTOS;

public record RestaurantDTO{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? _id {get;init;}
    [Required]
    public string? RestName {get;set;}
    public string? Address {get;set;}
    [Range(1, 5, ErrorMessage = "Rating between 1-5")]
    public double? rating {get;set;}

    public string? cuisines {get;set;}

    
    public Item[] menu {get;set;}


}