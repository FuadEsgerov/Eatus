using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class BrandDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Image { get; set; }

        public string Address { get; set; }
        public DepartmentDto Department { get; set; }
    }
}
