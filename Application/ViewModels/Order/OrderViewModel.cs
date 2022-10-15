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
    public class OrderViewModel
    {
        public int Id { get; set; }

        
        [DataType(DataType.Date)]
        public DateTime DeliveryDate { get; set; }

        
        [DataType(DataType.Text)]
        public string ClientName { get; set; }

        [DataType(DataType.Text)]
        public string ClientDirection { get; set; }

        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        
        public int Amout { get; set; }


        [DataType(DataType.Text)]
        public string ProductName { get; set; }


        [Range(1, int.MaxValue)]
        public int ClientId { get; set; }
        public List<ClientViewModel> Clients { get; set; }


        [Range(1, int.MaxValue)]
        public int ProductId { get; set; }
        public List<ProductViewModel> Products { get; set; }
    }
}
