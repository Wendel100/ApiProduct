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
    }
}