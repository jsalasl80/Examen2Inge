using Microsoft.AspNetCore.Mvc;
using ExamTwo.Business.DTO;
using ExamTwo.Business.Interface;

namespace ExamTwo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CoffeeMachineController : ControllerBase
    {
        private readonly ICoffeeService _coffeeService;

        public CoffeeMachineController(ICoffeeService coffeeService)
        {
            _coffeeService = coffeeService;
        }

        [HttpPost("buyCoffee")]
        public ActionResult<string> BuyCoffee([FromBody] OrderRequestDTO request)
        {
            return _coffeeService.BuyCoffee(request);
        }
    }
}