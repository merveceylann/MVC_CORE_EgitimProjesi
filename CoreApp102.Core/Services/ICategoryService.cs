using CoreApp102.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp102.Core.Services
{
    public interface ICategoryService : IServices<Category>
    {
        Task<Category> GetWithProductByIdAsync(int catId);
    }
}
