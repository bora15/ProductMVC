using DomainCore.Products;
using ServiceCore.Messages.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCore.Messages.Products
{
    public class ProductResponse : BaseResponse
    {
        public Product Product { get; set; }
    }
}
