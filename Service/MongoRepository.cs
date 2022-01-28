using Dotnet.Models;
using Dotnet.DTOS;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;
namespace Dotnet.Service;

public class MongoRepository : InterfaceRepository
{
    private readonly IMongoCollection<User> usersCollection;
    private FilterDefinitionBuilder<User> filter = Builders<User>.Filter;
    public MongoRepository(IOptions<MongoSettings> settings)
    {
        var mongoclient = new MongoClient(settings.Value.ConnectionString);
        var mongoDB = mongoclient.GetDatabase(settings.Value.DatabaseName);
        usersCollection = mongoDB.GetCollection<User>(settings.Value.CollectionName);

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
}