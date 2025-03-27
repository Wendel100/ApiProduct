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

        public ProductModel DeleteProduct(int id)
        { var Del =  _product.Produtos.Find(id);
           _product.Produtos.Remove(Del);
           _product.SaveChanges();
           return Del;
        }

        public ProductModel ToUpdate(ProductModel id)
        { var Del = ListById(id.Id);
        if (Del == null) throw new System.Exception("Erro ao atualizar os dados");;
        Del.Name = Del.Name;
        Del.Price = Del.Price;
        Del.Description =Del.Description;
        _product.Produtos.Update(Del);
        _product.SaveChanges();
        return Del;
        }

        public List<ProductModel> GetAll()
        {
            return _product.Produtos.ToList();
        }
    }
}