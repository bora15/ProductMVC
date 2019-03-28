using RepositoryCore.Abstraction.Products;
using RepositoryCore.Context;
using RepositoryCore.Implementation.Products;
using RepositoryCore.UnitOfWork.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryCore.UnitOfWork.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        IProductRepository productRepository;

        public ApplicationDbContext context;

        public UnitOfWork()
        {
            context = new ApplicationDbContext();
        }

        public IProductRepository GetProductRepository()
        {
            if (productRepository == null)
                productRepository = new ProductRepository(context);

            return productRepository;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
