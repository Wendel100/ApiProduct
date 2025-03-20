using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcoApi.Model;

namespace EcoApi.Services
{
    public interface IProductService
    {
        ProductModel AddProduct(ProductModel product);
    }
}