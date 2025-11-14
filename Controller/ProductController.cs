using EcoApi.Model;
using EcoApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace EcoApi.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController(IProductService service) : ControllerBase
    {
        private readonly IProductService _product = service;

        [HttpGet("item/{id}")]
        public IActionResult GetId(int id)
        {
            var item = _product.ListById(id);
            if (item == null)
                return NotFound();

            return Ok(item);
        }

        [HttpGet("name/{name}")]
        public IActionResult GetName(string name)
        {
            var products = _product.ListByName(name);
            return Ok(products);
        }

        [HttpGet("todos")]
        public IActionResult GetAll()
        {
            List<ProductModel> products = _product.GetAll();
            return Ok(products);
        }

        [HttpPost("add")]
        public IActionResult ToAdd([FromBody] ProductModel product)
        {
            _product.AddProduct(product);
            return Ok($"Adicionado com sucesso: {product.Name}");
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            _product.DeleteProduct(id);
            return Ok($"Produto apagado: {id}");
        }

        [HttpPut("update")]
        public IActionResult ToUpdate([FromBody] ProductModel product)
        {
            _product.ToUpdate(product);
            return Ok($"Produto atualizado: {product.Id}");
        }

        [HttpGet("image/{id}")]
        public IActionResult GetImage(int id)
        {
            var product = _product.ListById(id);
            if (product == null || product.Dados == null)
                return NotFound("Imagem não encontrada.");

            return File(product.Dados, "image/jpeg");
        }
    }
}