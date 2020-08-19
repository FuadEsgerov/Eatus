using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Models.Shopping
{
    public class OrderViewModel
    {
        public string BuyerEmail { get; set; }
        public decimal Subtotal { get; set; }
        public AddressViewModel shipToAddress { get; set; }
    }
}
