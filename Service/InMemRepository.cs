using Dotnet.Models;
using System;
namespace Dotnet.Service;


public class UserService : InterfaceRepository{
    private List<User> users = new List<User>(){
        new User(){firstName="hamza",lastName="usmani",email="hamzausmani021@gmail.com",contactNumber="03300312321",password="dawdwa"},
        new User(){firstName="hamza1",lastName="usmani",email="hamzausmani021@gmail.com",contactNumber="03300312321",password="dawdwa"},
        new User(){firstName="hamza2",lastName="usmani",email="hamzausmani021@gmail.com",contactNumber="03300312321",password="dawdwa"},
        
    };

    public List<User> GetAllUsers(){
        return users;
    }
    public User GetUser(string firstname){
        for(int i=0;i<users.Count ; i++){
            if(users[i].firstName == firstname ){return users[i];}
        }
        return null;
    }
    public User createUser(User user){
        users.Add(user);
        return user;
    }
    
    public User updateUser(string firstname, User user){
       int index = users.FindIndex(usr=> usr.firstName==firstname);
        users[index]=user;
        return users[index];
    }

}
