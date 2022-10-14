using Application.ViewModels.Client;
using Application.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.Order
{
    public class SaveOrderViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "La fecha de entrega es obligatoria")]
        [DataType(DataType.DateTime)]
        public DateTime DeliveryDate { get; set; }


        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Debe de seleccionar el cliente")]
        public int ClientId { get; set; }
        public List<ClientViewModel> Clients { get; set; }


        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Debe de seleccionar el producto")]
        public int ProductId { get; set; }
        public List<ProductViewModel> Products { get; set; }
    }
}
