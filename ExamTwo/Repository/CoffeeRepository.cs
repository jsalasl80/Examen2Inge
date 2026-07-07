using System;
using System.Collections.Generic;
using System.Linq;
using ExamTwo.Repository.Interface;

namespace ExamTwo.Repository //falta cambiar nombres de variables a mas significativas
{
    public class CoffeeRepository : ICoffeeRepository
    {
        private readonly Database _database;

        public CoffeeRepository(Database database)
        {
            _database = Database
        }

        public int GetPrice(string productKey)
        {
            if (!_database.keyValues2.ContainsKey(productKey))
                throw new ArgumentException($"Producto no encontrado: {productKey}");

            return _database.keyValues2[productKey];
        }

        public int GetStock(string productKey)
        {
            if (!_database.keyValues.ContainsKey(productKey))
                throw new ArgumentException($"Producto no encontrado: {productKey}");

            return _database.keyValues[productKey];
        }

        public void DecreaseStock(string productKey, int amount)
        {
            if (!_database.keyValues.ContainsKey(productKey))
                throw new ArgumentException($"Producto no encontrado: {productKey}");

            _database.keyValues[productKey] -= amount;
            if (_database.keyValues[productKey] < 0)
                _database.keyValues[productKey] = 0;
        }

        public IDictionary<int, int> GetChangeInventory()
        {
            return _database.keyValues3.ToDictionary(k => k.Key, v => v.Value);
        }

        public void DecreaseChange(int coinValue, int count)
        {
            if (!_database.keyValues3.ContainsKey(coinValue))
                throw new ArgumentException($"Moneda no encontrada: {coinValue}");

            _database.keyValues3[coinValue] = Math.Max(0, _database.keyValues3[coinValue] - count);
        }
    }
}