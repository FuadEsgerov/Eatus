using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Models.Shopping
{
    public class DashboardViewModel
    {
        public int products_count { get; set; }
        public int users_count { get; set; }
        public int orders_count { get; set; }
        public int restaurants_count { get; set; }
        public decimal orders_price{ get; set; }

    }
}
