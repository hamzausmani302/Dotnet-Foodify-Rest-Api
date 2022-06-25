



using Dotnet.Models;
using Dotnet.DTOS;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using MongoDB.Driver;
using MongoDB.Bson;
namespace Dotnet.Service;

public class OrderRepository : OrderInterface {
    
    private readonly IMongoCollection<Order> ordersCollection;

    public OrderRepository(IOptions<MongoSettings> settings){
        var mongoclient = new MongoClient(settings.Value.ConnectionString);
        var mongoDB = mongoclient.GetDatabase(settings.Value.DatabaseName);
        
        ordersCollection = mongoDB.GetCollection<Order>(settings.Value.CollectionName[2]);

    }
    

    public async Task placeOrder(Order order){
           
                 await ordersCollection.InsertOneAsync(order);
           
    }
    public void getOrder(String orderId){

    }

    public void CancelOrder(String orderId){

    }


    
}