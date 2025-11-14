using EcoApi.Model;
using EcoApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace EcoApi.Controller
{
    [ApiController]
    [Route("apiItem/[controller]")]
    public class ProductController(IProductService service) : ControllerBase
    {
        private readonly IProductService _product = service;

        [HttpGet("/item/{id}")]
        public IActionResult GetId(int id)
        {
            var Id = _product.ListById(id);
            if (Id == null)
                return NotFound();

            return Ok(Id);
        }
        [HttpGet("/itemName/{name}")]
        public IActionResult GetName(string name)
        {
            var products = _product.ListByName(name);
            return Ok(products);
        }

        [HttpGet("/todos")]
        public IActionResult GetAll()
        {
            List<ProductModel> products = _product.GetAll();
            return Ok(products);
        }
        [HttpPost("/add")]
        public IActionResult ToAdd(ProductModel product)
        {
            _product.AddProduct(product);
            return Ok($"Adicionado com sucesso: {product.Name}");
        }

        [HttpDelete("/delete/{id}")]
        public IActionResult Delete(int id)
        {
            _product.DeleteProduct(id);
            return Ok($"Produto foi apagado {id}");

        }
        [HttpPut]
        public IActionResult ToUpdate(ProductModel id)
        {
            _product.ToUpdate(id);
            return Ok($"Produto atualizado com sucesso {id}");
        }
        [HttpGet("/image/{id}")]
public IActionResult GetImage(int id)
{
    var product = _product.ListById(id);
    if (product == null || product.Dados == null)
        return NotFound("Imagem não encontrada.");

    // Retorna o conteúdo binário da imagem
    return File(product.Dados, "image/jpeg"); // ou "image/png" dependendo do tipo
}

    }
}