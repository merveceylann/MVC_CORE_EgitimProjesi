using CoreApp102.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp102.Api.UnitOfWork
{
    public interface IUnifOfWork
    {
        //readonly
        IProductRepository product { get; }
        ICategoryRepository category { get; }

        //commit:onaylama(gecebilirsin izin verdim)

        Task CommitAsync();
        void Commit();
    }
}
