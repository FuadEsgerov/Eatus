using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Repository.Entities
{
   public class Department : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public string Image { get; set; }

        public ICollection<ProductBrand> Brands { get; set; }
    }
}
