using EcoApi.Model;

namespace EcoApi.Services
{
    public interface IProductService
    {
        List<ProductModel> ListByName(string product);
        ProductModel ListById(int id);
        ProductModel AddProduct(ProductModel product);
        ProductModel DeleteProduct(int id);
        ProductModel ToUpdate(ProductModel id);
        List <ProductModel> GetAll();
    }
}