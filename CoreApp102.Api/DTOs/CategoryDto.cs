﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp102.Api.DTOs
{
    public class CategoryDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="{0} alani gereklidir.")]
        public string Name { get; set; }
    }
}
