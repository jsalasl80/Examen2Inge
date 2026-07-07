namespace ExamTwo.Business
{ 
    public class CoffeeService : ICoffeeService
    {
        private readonly ICoffeeRepository _repository;

        public ClienteBusiness(ICoffeeRepository repository)
        {
            _repository = repository;
        }

        public string BuyCoffee(OrderRequestDTO request)
        {
            var costoTotal = request.Order.Sum(o => _database.keyValues2.First(c => c.Key == o.Key).Value * o.Value);
            String result = "Dinero Insuficiente";

            if (request.Payment.TotalAmount < costoTotal)
            {
                return result;
            }

            foreach (var cafe in request.Order)
            {
                var currentCoffee = _database.keyValues.First(c => c.Key == cafe.Key).Key;

                if (cafe.Value > _database.keyValues[currentCoffee])
                {
                    result = "No hay suficientes {currentCoffee} en la máquina.";
                    return result;
                }

                _database.keyValues[currentCoffee] -= cafe.Value;
            }
        
            var change = request.Payment.TotalAmount - costoTotal;
            result = $"Su vuelto es de: {change} colones. Desglose:";
            if (change > 0)
            {
                foreach (var coin in _database.keyValues3.Keys.OrderByDescending(c => c))
                {
                    var count = Math.Min(change / coin, _db.keyValues3[coin]);
                    if (count > 0)
                    {
                        result += $" {count} moneda de {coin},  ";
                        change -= coin * count;
                    }
                }
                if (change > 0)
                {
                    return "No hay suficiente cambio en la máquina.";
                }
            }
            return result;
            
        }
    }
}
