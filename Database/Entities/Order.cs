using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime DeliveryDate { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }


        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
