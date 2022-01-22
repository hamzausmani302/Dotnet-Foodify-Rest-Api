using Dotnet.Service;
using Dotnet.Models;
public interface InterfaceRepository
{
    public List<User> GetAllUsers();
    public User GetUser(string firstname);
    public User createUser(User user);
    public User updateUser(string firstname,User user);
    

    
}