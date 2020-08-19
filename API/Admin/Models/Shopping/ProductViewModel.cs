using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Models.Shopping
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public bool Status { get; set; }
        public int ProductBrandId { get; set; }
        public int ProductTypeId { get; set; }
        public int DepartmentId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
    }
}
