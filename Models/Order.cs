// userID
// restId
// items
// totalamount
// Address
// misc_instructions
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
namespace Dotnet.Models;


public record Order{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    
    public string? _id {get ; set;}

    [BsonRepresentation(BsonType.ObjectId)]
    [Required]
    public string? userId{get;set;}
    [BsonRepresentation(BsonType.ObjectId)]
    [Required]
    public string? restId{get;set;}
    [Required]
    public Item[]? items{get ;set;}
    [Required]
    public string? address{get;set;}
    [Required]
    public int totalamount{get;set;}
    public int status{get;set;}


}