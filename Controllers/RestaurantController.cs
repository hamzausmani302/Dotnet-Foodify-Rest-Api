
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

    [HttpGet("{id}")]
    public async Task<IActionResult> getRestaurant(string id){
        var result = await service.GetRestaurant(id);
        return  Ok(result);

    }

    [HttpPut("edit")]
    public async Task<IActionResult> updateRestaurant(string id , UpdateRestaurantDTO _info){
        var result = await service.GetRestaurant(id);
        try{
            
            Console.WriteLine(result._id);
            Restaurant _restaurant = new Restaurant(){
                _id = result._id,
                RestName= _info.RestName != null ? _info.RestName : result.RestName,
                Address = _info.Address != null ? _info.Address : result.Address,
                rating = _info.rating != null ? _info.rating : result.rating,
                cuisines = _info.cuisines !=null ? _info.cuisines : result.cuisines,
                menu = _info.menu != null ? _info.menu : result.menu
 
            };
            var resultUpdate = await service.updateRestaurant(id , _restaurant);
            return Ok(resultUpdate);

        }catch(NullReferenceException err){
            return NotFound();
        }
        //var data = await service.updateRestaurant(id , _info.toRestaurant());
        
 
    }
    [HttpPut("edit/menu")]
    public async Task<IActionResult> updateMenu(string id , Item[] items){
        var _restaurant = await service.GetRestaurant(id);
        try{
            List<Item> _items = _restaurant.menu.ToList();
            //add to _items array
        
            foreach(Item item in items)
            {
                _items.Add(item);
            }
            var result = await service.updateMenu(id ,_items.ToArray());    
            return Ok(result);

        }catch(NullReferenceException err){
            return NotFound();
        }
    }

    
    // public IActionResult editRestaurant(){
    //     return Ok("hello");
    // }
    // public IActionResult deleteRestaurant(){
    //     return Ok("hello");
    // }
}