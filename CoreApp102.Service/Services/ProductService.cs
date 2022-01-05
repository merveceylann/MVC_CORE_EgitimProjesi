using CoreApp102.Core.Models;
using CoreApp102.Core.Repository;
using CoreApp102.Core.Services;
using CoreApp102.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp102.Service.Services
{
    public class ProductService : Service<Product>, IProductService
    {
        public ProductService(IUnitOfWork unitOfWork, IRepository<Product> repo) : base(unitOfWork, repo)
        {

        }
        public async Task<Product> GetWithIdAsync(int proId)
        {
            return await _UnitOfWork.product.GetWithByIdAsync(proId);
        }
    }
}
