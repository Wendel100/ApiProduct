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
        
        public ProductModel ListById(int id) => _product.Produtos.Find(id);
        public ProductModel ListByName(ProductModel name) => _product.Produtos.Find(name);
        public ProductModel AddProduct(ProductModel product)
        {
            _product.Produtos.Add(product);
            _product.SaveChanges();
            return product;
        }

    }
}