﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp102.Mvc.DTOs
{
    public class CategoryWithProductDto:CategoryDto
    {
        public IEnumerable<ProductDto> Products { get; set; }
    }
}
