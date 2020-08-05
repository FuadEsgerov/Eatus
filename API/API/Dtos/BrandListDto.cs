using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class BrandListDto
    {
        public BrandDto Brand { get; set; }
        public IEnumerable<ProductToReturnDto> Products { get; set; }
    }
}
