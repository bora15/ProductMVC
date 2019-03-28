using DomainCore.Products;
using RepositoryCore.Abstraction.Products;
using RepositoryCore.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryCore.Implementation.Products
{
    public class ProductRepository : IProductRepository
    {
        string dbConnectionString;
        private ApplicationDbContext context;

        public ProductRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public List<Product> GetProducts()
        {
            return context.Product
                    .ToList();
        }

        public Product GetProduct(int id)
        {
            return context.Product
                .FirstOrDefault(x => x.Id == id);
        }

        public Product Create(Product product)
        {
            context.Product.Add(product);
            return product;
        }

        public Product Update(Product product)
        {
            var dbItem = context.Product.FirstOrDefault(x => x.Id == product.Id);
            if (dbItem != null)
            {
                dbItem.Name = product.Name;
                dbItem.Description = product.Description;
                dbItem.Category = product.Category;
                dbItem.Manufacturer = product.Manufacturer;
                dbItem.Supplier = product.Supplier;
                dbItem.Price = product.Price;
            }

            return product;
        }

        public Product Delete(int id)
        {
            var dbItem = context.Product.FirstOrDefault(x => x.Id == id);
            if (dbItem != null)
            {
                context.Product.Remove(dbItem);
            }

            return dbItem;
        }

    }
}
