using CoreApp102.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp102.Data.Seed
{
    public class ProductSeed : IEntityTypeConfiguration<Product>
    {
        //dependency injection 
        private readonly int[] _ids;
        public ProductSeed(int[] ids)
        {
            _ids = ids;
        }

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product { Id = 1, Name = "Dolma Kalem", Price = 125.75m, Stock = 100, CategoryId = _ids[0]},
                new Product { Id = 2, Name = "Tukenmez Kalem", Price = 25.50m, Stock = 200, CategoryId = _ids[0]},
                new Product { Id = 3, Name = "Kursun Kalem", Price = 5.75m, Stock = 400, CategoryId = _ids[0]},
                new Product { Id = 4, Name = "Cizgili Defter", Price = 65.25m, Stock = 100, CategoryId = _ids[1]},
                new Product { Id = 5, Name = "Kareli Defter", Price = 65.25m, Stock = 100, CategoryId = _ids[1]},
                new Product { Id = 6, Name = "Dumduz Defter", Price = 65.25m, Stock = 100, CategoryId = _ids[1]}
                );
        }
    }
}
