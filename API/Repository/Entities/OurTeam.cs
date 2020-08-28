using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Entities
{
    public class OurTeam : BaseEntity
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Detail { get; set; }
    }
}
