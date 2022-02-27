using Dotnet.Models;
namespace Dotnet.Service;
public interface InterfaceRepository
{
    //User Controller 
    public Task<List<User>> GetAllUsers();
    public Task<List<User>> GetUser(string firstname);
    public User createUser(User user);
    public Task<string> updateUser(string id, User user);

    public Task<string> deleteUser(string id);

    //Restaurant controllers
    public Task<List<Restaurant>> GetRestaurants();

    public Task<Boolean> addRestaurant(Restaurant restaurant);

    public Task<string> updateRestaurant(string id , Restaurant restaurant);

    public Task<string> deleteRestarant(string id);



}