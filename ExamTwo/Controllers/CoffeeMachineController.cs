using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamTwo.Controllers
{
    public class CoffeeMachineController : Controller
    {
        
        [HttpPost("buyCoffee")]
        public ActionResult<string> BuyCoffee(OrderRequestDTO request)
        {
            if (request.Order == null || request.Order.Count == 0)
                return BadRequest("Orden vacia.");

            if (request.Payment.TotalAmount <= 0)
                return BadRequest("Dinero insuficiente ");
            var result = _coffeeService.BuyCoffee(request);
            return result;
            
        }
    }

}
