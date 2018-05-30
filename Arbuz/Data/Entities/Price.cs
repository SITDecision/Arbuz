using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace Arbuz.Data.Entities
{
    internal class Price
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Product Product { get; set; }
        public decimal Value { get; set; }
    }
}
