using System.ComponentModel.DataAnnotations;

namespace Admin.Models.Account
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "E-poçt vacibdir")]
        [EmailAddress(ErrorMessage = "Düzgün e-poçt daxil edin")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Required(ErrorMessage = "Şifrə vacibdir")]
        [MinLength(6, ErrorMessage = "Şifrə ən azı 6 xarakter ola bilər")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        public bool RememberMe { get; set; }
    }
}