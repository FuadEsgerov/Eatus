using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Models.Pages
{
    public class SliderViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Statusu daxil edin...")]
        public bool Status { get; set; }
        [Required(ErrorMessage = "Basliq daxil edin...")]
        [MaxLength(50, ErrorMessage = "Maxsimum %0 xarekter ola biler...")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Texti daxil edin...")]
        [MaxLength(500, ErrorMessage = "Maksimum 500 xarekter ola biler")]
        public string Slogan { get; set; }
        public string Image { get; set; }
        [Required(ErrorMessage = "Action texti daxil edin daxil edin..."), StringLength(50, ErrorMessage = "Maxsimum 50 xarekter ola biler...")]
        public string ActionText { get; set; }
        [Required(ErrorMessage = "Url  daxil edin..."), StringLength(50, ErrorMessage = "Maxsimum 50 xarekter ola biler...")]
        public string EndPoint { get; set; }
    }
}
