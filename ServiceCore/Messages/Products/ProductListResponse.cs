using DomainCore.Products;
using ServiceCore.Messages.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCore.Messages.Products
{
    public class ProductListResponse : BaseResponse
    {
        public List<Product> Products { get; set; }
    }
}
