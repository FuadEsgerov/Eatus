using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Models.Shopping
{
    public class BrandViewModel
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public bool Status { get; set; }
        public string Name { get; set; }
        public DepartmentViewModel Department { get; set; }
    }
}
