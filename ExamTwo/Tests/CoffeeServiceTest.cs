using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExamTwo.Business;
using ExamTwo.Business.DTO;
using ExamTwo.Business.Interface;

[CoffeeServiceTest]
public class CoffeeServiceTest
{
    [TestMethod]
    public void TestBuyCoffee()
    {
        var coffeeService = new CoffeeService();

        var orderRequest = new OrderRequestDTO
        {
            Order = new Dictionary<string, int> { { "Espresso", 1 } },
            Payment = new PaymentDTO
            {
                TotalAmount = 5,
                Coins = new List<int> { 1, 1, 1, 1, 1 },
                Bills = new List<int>()
            }
        };
        ActionResult<string> result = coffeeService.BuyCoffee(orderRequest);

        assert.IsNotNull(result);
        assert.IsInstanceOfType(result, typeof(OkObjectResult));
    }
}