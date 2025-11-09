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

        [HttpGet("/{id}")]
        public IActionResult GetId(int id)
        {
            var Id = _product.ListById(id);
            if (Id == null)
                return NotFound();

            return Ok(Id);
        }
    [HttpGet("{name}")]
public IActionResult GetName(string name)
{
    var products = _product.ListByName(name);
    return Ok(products);
}

    [HttpGet]
    public IActionResult GetAll(){
             List<ProductModel> products=_product.GetAll();
            return Ok(products);
    }
[HttpPost("/add")]
public IActionResult ToAdd(ProductModel product)
{
    _product.AddProduct(product);
    return Ok($"Adicionado com sucesso: {product.Name}");
}

        [HttpDelete("{id}")]
        public IActionResult Delete(int id){
            _product.DeleteProduct(id);
            return Ok($"Produto foi apagado {id}");

        }
        [HttpPut]
        public IActionResult ToUpdate(ProductModel id){
            _product.ToUpdate(id);
            return Ok($"Produto atualizado com sucesso {id}");
        }
    }
}