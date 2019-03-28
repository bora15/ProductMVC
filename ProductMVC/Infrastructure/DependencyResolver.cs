using Ninject;
using RepositoryCore.Abstraction.Products;
using RepositoryCore.Implementation.Products;
using RepositoryCore.UnitOfWork.Abstraction;
using RepositoryCore.UnitOfWork.Implementation;
using ServiceCore.Abstraction.Products;
using ServiceCore.Implementation.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductMVC.Infrastructure
{
    public static class DependencyResolver
    {
        public static readonly IKernel Kernel;

        static DependencyResolver()
        {
            if(Kernel == null)
            {
                Kernel = new StandardKernel();

                Kernel.Bind<IProductRepository>().To<ProductRepository>();

                Kernel.Bind<IUnitOfWork>().To<UnitOfWork>();

                Kernel.Bind<IProductService>().To<ProductService>();


            }
        }
    }
}