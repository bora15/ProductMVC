using DomainCore.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryCore.Abstraction.Products
{
    public interface IProductRepository
    {
        List<Product> GetProducts();

        Product GetProduct(int Id);

        Product Create(Product product);
        Product Update(Product product);
        Product Delete(int id);
    }
}
