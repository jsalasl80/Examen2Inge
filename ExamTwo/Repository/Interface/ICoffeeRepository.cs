namespace ExamTwo.Repository.Interface
{

    public interface ICoffeeRepository
    {
        public Dictionary<string, int> GetCoffeePrices();

        public Dictionary<string, int> GetCoffeePricesInCents();

        public Dictionary<string, int> GetQuantity();

    }
}