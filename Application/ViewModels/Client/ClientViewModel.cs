using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.Client
{
    public class ClientViewModel
    {
        public int Id { get; set; }

        
        public string ClientName { get; set; }

        public string ClientDirection { get; set; }
    }
}
