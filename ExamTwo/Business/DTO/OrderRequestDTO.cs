using System.Collections.Generic;

namespace ExamTwo.Business.DTO
{
    public class OrderRequestDTO
    {
        public Dictionary<string, int> Order { get; set; }
        public PaymentDTO Payment { get; set; }
    }

    public class PaymentDTO
    {
        public int TotalAmount { get; set; }
        public List<int> Coins { get; set; }
        public List<int> Bills { get; set; }
    }
}