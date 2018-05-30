using System;

namespace Arbuz.Data.Entities
{
    public class Price
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Product Product { get; set; }
        public decimal Value { get; set; }
    }
}
