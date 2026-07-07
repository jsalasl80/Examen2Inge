using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ExamTwo.Business.DTO;
using ExamTwo.Business.Interface;
using ExamTwo.Repository.Interface;

namespace ExamTwo.Business
{
    public class CoffeeService : ICoffeeService
    {
        private readonly ICoffeeRepository _repository;

        public CoffeeService(ICoffeeRepository repository)
        {
            _repository = repository;
        }

        public ActionResult<string> BuyCoffee(OrderRequestDTO request)
        {
            if (request == null || request.Order == null || request.Order.Count == 0)
                return new BadRequestObjectResult("Orden vacia.");

            if (request.Payment == null || request.Payment.TotalAmount <= 0)
                return new BadRequestObjectResult("Dinero insuficiente ");

            try
            {
                var costoTotal = request.Order.Sum(o => _repository.GetPrice(o.Key) * o.Value);

                if (request.Payment.TotalAmount < costoTotal)
                    return new BadRequestObjectResult("Dinero insuficiente ");

                foreach (var cafe in request.Order)
                {
                    var stock = _repository.GetStock(cafe.Key);
                    if (cafe.Value > stock)
                        return new BadRequestObjectResult($"No hay suficientes {cafe.Key} en la máquina.");

                    _repository.DecreaseStock(cafe.Key, cafe.Value);
                }

                var change = request.Payment.TotalAmount - costoTotal;
                string result = $"Su vuelto es de: {change} colones. Desglose:";

                var changeInventory = _repository.GetChangeInventory();
                foreach (var coin in changeInventory.OrderByDescending(c => c.Key))
                {
                    var count = Math.Min(change / coin.Key, coin.Value);
                    if (count > 0)
                    {
                        result += $" {count} moneda de {coin.Key},  ";
                        change -= coin.Key * count;
                        _repository.DecreaseChange(coin.Key, (int)count);
                    }
                }

                if (change > 0)
                    return new ObjectResult("No hay suficiente cambio en la máquina.") { StatusCode = 500 };

                return new OkObjectResult(result);
            }
            catch (ArgumentException ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
            catch (Exception ex)
            {
                return new ObjectResult(ex.Message) { StatusCode = 500 };
            }
        }
    }
}