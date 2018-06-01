using System.ComponentModel.DataAnnotations;

namespace Arbuz.DTO
{
    public class OperationInfo
    {
        [Display(Name = "Товар/услуга")]
        public string ProductName { get; set; }
        [Display(Name = "Цена")]
        public decimal? Price { get; set; }
        [Display(Name = "Количество")]
        public int Quantity { get; set; }
        [Display(Name = "Сумма")]
        public decimal? Sum => Price.HasValue ? Price * Quantity : null;
        [Display(Name = "Дата")]
        public string Date { get; set; }
    }
}