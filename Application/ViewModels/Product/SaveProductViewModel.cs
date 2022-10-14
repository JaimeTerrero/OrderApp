using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.Product
{
    public class SaveProductViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del producto es obligatario")]
        [DataType(DataType.Text)]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "El precio del producto es obligatorio")]
        [DataType(DataType.Currency)]
        public int Price { get; set; }
    }
}
