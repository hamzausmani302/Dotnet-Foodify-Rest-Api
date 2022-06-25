using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace Dotnet.Models;

public record OrderDTO{
    // userID
// restId
// items
// totalamount
// Address
// misc_instructions


    
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


}