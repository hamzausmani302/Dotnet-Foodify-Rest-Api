using Microsoft.AspNetCore.Mvc;
using Dotnet.Service;
using Dotnet.Models;
namespace Dotnet.Controllers;

[ApiController]
[Route("order")]
public class OrderContoller : ControllerBase {

    private readonly OrderInterface service;
    public OrderContoller(OrderInterface order_service){
        service = order_service;
    }
    [HttpGet("test")]
    public IActionResult testConnectivity(){
        return Ok("hello");
    }
    [HttpPost("")]
    public  IActionResult addOrder(OrderDTO order){
        try{
            Order _order = new Order(){
               
            userId = order.userId,
             restId =    order.restId,
            items = order.items,
            address = order.address,
            totalamount = order.totalamount,
            status = 0
        };
            var result = service.placeOrder(_order);

            return Ok(_order);
        }catch(Exception e){
            return NoContent();
        }
        
    }
}
