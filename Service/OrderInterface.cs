
namespace Dotnet.Service;
using Dotnet.Models;

public interface OrderInterface{
    public Task placeOrder(Order order);
    public void getOrder(String orderId);

    public void CancelOrder(String orderId);   


}