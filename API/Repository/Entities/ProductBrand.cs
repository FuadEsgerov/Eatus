using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Entities
{
    public class ProductBrand:BaseEntity
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }

        public string Image { get; set; }

        public string Address { get; set; }
        public Department Department { get; set; }
    
    }
}
