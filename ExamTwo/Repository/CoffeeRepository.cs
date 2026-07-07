namespace ExamTwo.Repository
{
    public class CoffeeRepository : IClienteRepository
    {
        private readonly Database _database;

        public CoffeeRepository(Database database)
        {
            _database = database;
        }

        public Dictionary<string, int> GetCoffeePrices()
        {
            return _database.keyValues;
        }
        public Dictionary<string, int> GetCoffeePricesInCents()
        {
            return _database.keyValues2;
        }

        public Dictionary<string, int> GetQuantity()
        {
            return _database.keyValues3;
        }
    }
}