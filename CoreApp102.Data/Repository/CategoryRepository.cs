using CoreApp102.Core.Models;
using CoreApp102.Core.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp102.Data.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private AppDbContext appDbContext { get => _db as AppDbContext; }
        public CategoryRepository(AppDbContext db) : base(db)
        {

        }
        public async Task<Category> GetWithProductByIdAsync(int catId)
        {
            return await appDbContext.Categories.Include(s => s.Products).FirstOrDefaultAsync(s => s.Id == catId);
        }
    }
}
