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
    public class CategoryService : Service<Category>, ICategoryService
    {
        public CategoryService(IUnitOfWork unitOfWork, IRepository<Category> repo) : base(unitOfWork, repo)
        {

        }
        public async Task<Category> GetWithProductByIdAsync(int catId)
        {
            return await _UnitOfWork.category.GetWithProductByIdAsync(catId);
        }
    }
}
