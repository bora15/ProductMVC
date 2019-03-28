using DomainCore.Products;
using ServiceCore.Messages.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCore.Abstraction.Products
{
    public interface IProductService
    {
        ProductListResponse GetProducts();

        ProductResponse GetProduct(int Id);

        ProductResponse Create(Product product);
        ProductResponse Update(Product product);
        ProductResponse Delete(Product product);
    }
}
