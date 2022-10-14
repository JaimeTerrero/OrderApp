using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string ClientName { get; set; }

        public List<Order> Orders { get; set; }
    }
}
