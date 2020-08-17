using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Models.Shopping
{
    public class DepartmentViewModel
    {
        public int Id { get; set; }

        [Required]
        public bool Status { get; set; }

        [Required(ErrorMessage = "Şöbə adı vacibdir")]
        [MaxLength(50, ErrorMessage = "Şöbə adı maximum 50 xarakter ola bilər")]
        public string Name { get; set; }
        public string Image { get; set; }
    }
}
