using System.ComponentModel.DataAnnotations;

namespace Arbuz.Data.Entities
{
    public enum ServiceType
    {
        [Display(Name = "Фото")]
        Photo,
        [Display(Name = "Ксерокс")]
        Xerox,
        [Display(Name = "Печать")]
        Print,
        [Display(Name = "Ламинирование")]
        Lamination,
        [Display(Name = "Товары")]
        Goods
    }
}