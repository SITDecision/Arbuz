using System;
using System.ComponentModel.DataAnnotations;

namespace Arbuz.Data.Entities
{
    public class Operation
    {
        public int Id { get; set; }
        [Display(Name = "Дата операции")]
        public DateTime Date { get; set; }
        public int ProductId { get; set; }
        [Display(Name = "Товар/услуга")]
        public Product Product { get; set; }
        [Display(Name = "Количество")]
        public int Quantity { get; set; }
    }
}