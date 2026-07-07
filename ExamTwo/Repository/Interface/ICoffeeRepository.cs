using System.Collections.Generic;

namespace ExamTwo.Repository.Interface
{
    public interface ICoffeeRepository
    {
        int GetPrice(string productKey);
        int GetStock(string productKey);
        void DecreaseStock(string productKey, int amount);
        IDictionary<int, int> GetChangeInventory();
        void DecreaseChange(int coinValue, int count);
    }
}