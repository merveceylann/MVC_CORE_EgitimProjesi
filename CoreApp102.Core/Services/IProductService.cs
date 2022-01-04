using CoreApp102.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp102.Core.Services
{
    public interface IProductService : IServices<Product>
    {
        //for ex. indirim uygulucam urunlerde
        Task<Product> GetWithIdAsync(int proId);
        //Product ile ilgili tanimlamam gereken ic metodlartim var ise onlari bu services katmaninda yazabilirim. 

    }
}
