using Application.ViewModels.Client;
using Application.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.Order
{
    public class OrderViewModel
    {
        public int Id { get; set; }

        public DateTime DeliveryDate { get; set; }


        public string ClientName { get; set; }

        public int Price { get; set; }

        public string ProductName { get; set; }


        public int ClientId { get; set; }
        public List<ClientViewModel> Clients { get; set; }


        public int ProductId { get; set; }
        public List<ProductViewModel> Products { get; set; }
    }
}
