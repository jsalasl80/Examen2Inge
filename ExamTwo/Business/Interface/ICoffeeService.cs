using Microsoft.AspNetCore.Mvc;
using ExamTwo.Business.DTO;

namespace ExamTwo.Business.Interface
{
    public interface ICoffeeService
    {
        ActionResult<string> BuyCoffee(OrderRequestDTO request);
    }
}