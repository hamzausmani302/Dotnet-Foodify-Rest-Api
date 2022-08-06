
using Dotnet.Models;
using Microsoft.AspNetCore.Mvc;
using Dotnet.Service;
using System;
using Dotnet.Utils;
using Dotnet.DTOS;
namespace Dotnet.Controllers
{
    [ApiController]
    
    [Route("users")]
    public class UserController : ControllerBase
    {

        private readonly InterfaceRepository service;
        public UserController(InterfaceRepository int_repo)
        {
            service = int_repo;
        }


        [HttpGet("all")]
        public async Task<IEnumerable<UserDTO>> GetUsers()
        {
            UtilsService utils = new UtilsService();
            List<User> users = await service.GetAllUsers();
            return UtilsService.ToUserDTO(users);


        }

        [HttpPost("signup")]
        public ActionResult<UserDTO> AddUser(createUserDTO userd)
        {

            User user = new()
            {

                firstName = userd.firstName,
                lastName = userd.lastName,
                email = userd.email,
                contactNumber = userd.contactNumber,
                password = userd.password
            };
            service.createUser(user);
            return user.AsDTO();
        }

        [HttpPost("login")]
        public async Task<ActionResult<User>> Login(LoginUserDTO user){
            Console.Write(user.contactNumber + user.password);
            var result = await service.GetUserByData(user);
            // Console.Write(result.ToString());
            
            if(result != null){
                return result;
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUser(string id)
        {
            try
            {
                List<User> users = await service.GetUser(id);

                if (users.Count == 0)
                {
                    return NotFound();
                }


                return users[0].AsDTO();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<string> updateUser(string id, updateUserDTO dto)
        {

            List<User> user = await service.GetUser(id);
            if (user.Count == 0)
            {
                return "No such user exists";
            }
            User finaluser = new User()
            {
                _id = user[0]._id,
                firstName = user[0].firstName,
                lastName = user[0].lastName,
                email = user[0].email,
                password = dto.password,
                contactNumber = user[0].contactNumber
            };

            string result = await service.updateUser(id, finaluser);
            if (result == null) { return "error adding user"; }
            return "user added successfully";
        }

        [HttpGet("/")]
        public ActionResult<string> Default()
        {
            return "running";
        }
        [HttpDelete("/del/{id}")]
        public async Task<ActionResult<string>> DeleteUser(string id)
        {
            var result = await service.deleteUser(id);
            return NoContent();
        }
        

    }

}
