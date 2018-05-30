using System;

namespace Arbuz.Data.Entities
{
    internal class Operation
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}