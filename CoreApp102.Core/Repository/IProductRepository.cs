using CoreApp102.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp102.Core.Repository
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product> GetWithByIdAsync(int proId);
    }
}
