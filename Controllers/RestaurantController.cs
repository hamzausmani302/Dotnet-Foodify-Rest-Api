
using Microsoft.AspNetCore.Mvc;
using Dotnet.Models;
using Dotnet.DTOS;
using Dotnet.Service;
using System.Text.Json;
using System.IO;
using System;
using System.Text;
namespace Dotnet.Controllers;

[ApiController]
[Route("restaurants")]
public class RestaurantController : ControllerBase{
     private readonly InterfaceRepository service;
        public RestaurantController(InterfaceRepository int_repo)
        {
            service = int_repo;
        }

    [HttpGet("all")]
    public async Task<IActionResult> getAllRestaurants(){
        List<Restaurant> restaurants = await service.GetRestaurants();       
        return Ok(restaurants);
    }
    [HttpPost("add")]
    public async Task<IActionResult> addRestaurant(CreateRestaurantDTO _restaurant){

         
        Restaurant restaurant = _restaurant.ToRestaurant();
        Boolean result =await service.addRestaurant(restaurant);
        
        if(result){
                
            return Ok(restaurant);
        }else{
            return NoContent();
        }
    }

    // public IActionResult editRestaurant(){
    //     return Ok("hello");
    // }
    // public IActionResult deleteRestaurant(){
    //     return Ok("hello");
    // }
}