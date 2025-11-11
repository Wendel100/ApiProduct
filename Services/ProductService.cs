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
        public List<ProductModel> ListByName(string name)
{
    return _product.Produtos
        .ToList() // força a execução no cliente (memória)
        .Where(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
        .ToList();
}

        public ProductModel AddProduct(ProductModel product)
        {
            if (product.ImagemUpload != null)
            {
                using (var stream = new MemoryStream())
                {
                    product.ImagemUpload.CopyTo(stream);
                    product.Dados = stream.ToArray();
                }
            }

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