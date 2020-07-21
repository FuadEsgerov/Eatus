using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Entities
{
    public class ProductBrand:BaseEntity
    {
        public string Name { get; set; }

        public string Image { get; set; }

        public string Address { get; set; }

        
    }
}
