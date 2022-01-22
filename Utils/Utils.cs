using Dotnet.DTOS;
using Dotnet.Models;
using System;
namespace Dotnet.Utils{

    public  class UtilsService{
       
       public static List<UserDTO> ToUserDTO(List<User> user){
            List<UserDTO> userdtos = new List<UserDTO>(); 
            for(int i = 0 ; i < user.Count ; i++){
                userdtos.Add(
                    new UserDTO(){
                        firstName = user[i].firstName,
                        lastName = user[i].lastName,
                        email = user[i].email
                    }
                );
            }
            return userdtos;
        }

    }

}