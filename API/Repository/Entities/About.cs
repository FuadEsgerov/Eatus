using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Entities
{
   public class About: BaseEntity
    {
        public string Title { get; set; }
        public string Image { get; set; }
        public string Detail { get; set; }
    }
}
