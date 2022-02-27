using Dotnet.Models;
using Dotnet.DTOS;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using MongoDB.Driver;
using MongoDB.Bson;
namespace Dotnet.Service;

public class MongoRepository : InterfaceRepository
{
    private readonly IMongoCollection<User> usersCollection;
    

    private FilterDefinitionBuilder<User> filter = Builders<User>.Filter;
    private readonly IMongoCollection<Restaurant> restaurantsCollection;
    private FilterDefinitionBuilder<Restaurant> restaurantfilter = Builders<Restaurant>.Filter;

    public MongoRepository(IOptions<MongoSettings> settings)
    {
        var mongoclient = new MongoClient(settings.Value.ConnectionString);
        var mongoDB = mongoclient.GetDatabase(settings.Value.DatabaseName);
        usersCollection = mongoDB.GetCollection<User>(settings.Value.CollectionName[0]);
        restaurantsCollection = mongoDB.GetCollection<Restaurant>(settings.Value.CollectionName[1]);

    }
    public async Task<List<User>> GetAllUsers()
    {
        return await usersCollection.Find(_ => true).ToListAsync();
    }
    public async Task<List<User>> GetUser(string id)
    {
        return await usersCollection.Find(item => item._id == id).ToListAsync();



    }
    public User createUser(User user)
    {
        usersCollection.InsertOne(user);
        return new User();
    }
    public async Task<string> updateUser(string id, User user)
    {
        var result = await usersCollection.ReplaceOneAsync(filter.Eq(item => item._id, id), user);
        return result.ToString();
    }


    public async Task<string> deleteUser(string id)
    {
        var result = await usersCollection.DeleteOneAsync(filter.Eq(item => item._id, id));
        return result.ToString();
    }
    
     public async  Task<List<Restaurant>> GetRestaurants(){
         List<Restaurant>  result= await restaurantsCollection.Find(_=>true).ToListAsync(); 
         return result;
     }

    public async Task<Boolean> addRestaurant(Restaurant restaurant){
        
        try{
            restaurantsCollection.InsertOne(restaurant);
            return true;    
        }catch(Exception e){
            return false;
        }
    }

    public async  Task<string> updateRestaurant(string id , Restaurant restaurant){
        return null;
    }

    public async Task<string> deleteRestarant(string id){
        
        return null;
    }



}