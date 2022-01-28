using Dotnet.Models;
namespace Dotnet.Service;
public interface InterfaceRepository
{
    public Task<List<User>> GetAllUsers();
    public Task<List<User>> GetUser(string firstname);
    public User createUser(User user);
    public Task<string> updateUser(string id, User user);

    public Task<string> deleteUser(string id);


}