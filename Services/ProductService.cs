using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcoApi.Controller.DB;
using EcoApi.Model;

namespace EcoApi.Services
{
    public class ProductService : IProductService
    {
          readonly ProductContext _product;
        public ProductService(ProductContext product){
            _product = product;
        }
        public ProductModel AddProduct(ProductModel product)
        {
            _product.Produtos.Add(product);
            _product.SaveChanges();
            return product;
        }
    }
}