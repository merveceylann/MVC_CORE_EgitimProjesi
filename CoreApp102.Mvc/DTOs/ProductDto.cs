using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp102.Mvc.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} alani gereklidir.")]
        public string Name { get; set; }
        [Range(1,Int32.MaxValue,ErrorMessage ="{0} alani sifirdan buyuk bir deger olmalidir.")] //kendi icinde required barindiriyo
        public int Stock { get; set; }
        [Range(1, double.MaxValue, ErrorMessage = "{0} alani sifirdan buyuk bir deger olmalidir.")]
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
