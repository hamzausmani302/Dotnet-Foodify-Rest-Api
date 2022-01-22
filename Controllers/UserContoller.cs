
using Dotnet.Models;
using Microsoft.AspNetCore.Mvc;
using Dotnet.Service;
using System;
using Dotnet.Utils;
using Dotnet.DTOS;
namespace Dotnet.Controllers{
    [ApiController]
    [Route("users")]
    public class UserController : ControllerBase{
            
            private readonly InterfaceRepository service;
            public UserController(InterfaceRepository int_repo){
                service = int_repo;
            }

            [HttpGet("all")]
            public IEnumerable<UserDTO> GetUsers()
            {
                //UtilsService utils = new UtilsService();
                return UtilsService.ToUserDTO( service.GetAllUsers());   
            }

            [HttpPost("add")]
            public ActionResult<UserDTO> AddUser(createUserDTO userdto){
                
                User user = new(){
                    firstName=userdto.firstName,
                    lastName=userdto.lastName,
                    email=userdto.email,
                    contactNumber=userdto.contactNumber,
                    password=userdto.password
                };
                service.createUser(user);
                return user.AsDTO();
            }
            [HttpGet("{firstName}")]
            public ActionResult<UserDTO> GetUser(string firstName){
                
                User user =  service.GetUser(firstName);
                
                if(user == null){
                    return NotFound();
                }
                List<User> users = new List<User>();
                
                users.Add(user);
                
                return UtilsService.ToUserDTO( users)[0];
            }

            [HttpPut("{firstname}")]
            public ActionResult<string> updateUser(string firstname , updateUserDTO dto){
                User user = service.GetUser(firstname);
                if(user == null){
                    return NotFound();
                }
                User finaluser =  new User(){
                       firstName=user.firstName,
                       lastName=user.lastName,
                       email=user.email,
                       password=dto.password,
                       contactNumber=user.contactNumber
                };
                updateUser(firstname ,finaluser);
                return "user added successfully";
            }

            [HttpGet("/")]
            public ActionResult<string> Default()
            {
                return "running";
            }
        

    }


}
