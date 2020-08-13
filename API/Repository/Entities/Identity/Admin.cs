using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Repository.Entities.Identity
{
    public class Admin : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Fullname { get; set; }

        [Required]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        [MaxLength(100)]
        public string Password { get; set; }

        [MaxLength(50)]
        public string Token { get; set; }

        [MaxLength(50)]
        public string ForgetToken { get; set; }
    }
}
