using RepositoryCore.Abstraction.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryCore.UnitOfWork.Abstraction
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository GetProductRepository();

        void Save();
    }
}
