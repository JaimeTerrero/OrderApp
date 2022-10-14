using Application.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.Client
{
    public class SaveClientViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del cliente es obligatorio")]
        [DataType(DataType.Text)]
        public string ClientName { get; set; }

        [Required(ErrorMessage = "El apellido del cliente es obligatorio")]
        [DataType(DataType.Text)]
        public string ClientLastName { get; set; }
    }
}
