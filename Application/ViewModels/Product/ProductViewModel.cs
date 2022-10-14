using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.Product
{
    public class ProductViewModel
    {
        public int Id { get; set; }


        public string ProductName { get; set; }


        public decimal Price { get; set; }
    }
}
