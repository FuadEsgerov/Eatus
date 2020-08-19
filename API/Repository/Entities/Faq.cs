using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Repository.Entities
{
    public class Faq : BaseEntity
    {

        [Required]
        [MaxLength(100)]
        public string Question { get; set; }
        [Required]
        [MaxLength(400)]
        public string Answer { get; set; }

    }
}
