using System;
using System.ComponentModel.DataAnnotations;

namespace Arbuz.Data.Entities
{
    public class Price
    {
        public int Id { get; set; }
        [Display(Name = "Дата начала цены")]
        public DateTime Date { get; set; }

        public int ProductId { get; set; }
        [Display(Name = "Товар/услуга")]
        public Product Product { get; set; }
        [Display(Name = "Цена")]
        public decimal Value { get; set; }
    }
}
