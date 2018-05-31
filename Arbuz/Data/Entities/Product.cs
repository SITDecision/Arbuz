using System.ComponentModel.DataAnnotations;

namespace Arbuz.Data.Entities
{
    public class Product
    {
        public int Id { get; set; }
        [Display(Name = "Тип операции")]
        public ServiceType ServiceType { get; set; }
        [Display(Name = "Название")]
        public string Name { get; set; }
    }
}