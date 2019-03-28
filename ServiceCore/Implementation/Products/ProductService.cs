using DomainCore.Products;
using RepositoryCore.Abstraction.Products;
using RepositoryCore.UnitOfWork.Abstraction;
using ServiceCore.Abstraction.Products;
using ServiceCore.Messages.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCore.Implementation.Products
{
    public class ProductService : IProductService
    {
        private IUnitOfWork unitOfWork;

        public ProductService(IUnitOfWork uow)
        {
            unitOfWork = uow;
        }

        public ProductListResponse GetProducts()
        {
            ProductListResponse response = new ProductListResponse();
            try
            {
                response.Products = unitOfWork.GetProductRepository().GetProducts();
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public ProductResponse GetProduct(int Id)
        {
            ProductResponse response = new ProductResponse();
            try
            {
                response.Product = unitOfWork.GetProductRepository().GetProduct(Id);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public ProductResponse Create(Product Product)
        {
            ProductResponse response = new ProductResponse();
            try
            {
                unitOfWork.GetProductRepository().Create(Product);
                unitOfWork.Save();
                response.Product = Product;
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public ProductResponse Update(Product Product)
        {
            ProductResponse response = new ProductResponse();
            try
            {
                unitOfWork.GetProductRepository().Update(Product);
                unitOfWork.Save();
                response.Product = Product;
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public ProductResponse Delete(Product Product)
        {
            ProductResponse response = new ProductResponse();
            try
            {
                var productFromDb = unitOfWork.GetProductRepository().GetProduct(Product.Id);
                if (productFromDb != null)
                {
                    unitOfWork.GetProductRepository().Delete(Product.Id);
                    unitOfWork.Save();
                }
                response.Product = productFromDb;
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
