using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Entities
{
  public  class SliderItem:BaseEntity
    {
    
        public int OrderBy { get; set; }


        public string Title { get; set; }


        public string Slogan { get; set; }


        public string Image { get; set; }

        public string ActionText { get; set; }


        public string EndPoint { get; set; }
    }
}
