using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcoApi.Model;

namespace EcoApi.Services
{
    public interface IProductService
    {
        
        ProductModel ListByName(ProductModel product);
        ProductModel ListById(int id);
        ProductModel AddProduct(ProductModel name);
        ProductModel DeleteProduct(int id);
        ProductModel ToUpdate(ProductModel id);
        List <ProductModel> GetAll();
    }
}