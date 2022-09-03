using System.ComponentModel.DataAnnotations;

namespace CarDealerships.ViewModels
{
    public class InputCarViewModel
    {
        [StringLength(50,MinimumLength =3, ErrorMessage ="Длина сторки должна быть от 3 до 50 символов")]
        [Required(ErrorMessage = "Укажите марку машины")]
        public string Stamp { get; set; }

        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина сторки должна быть от 3 до 50 символов")]
        [Required(ErrorMessage = "Укажите цвет машины")]
        public string Color { get; set; }
    }
}
