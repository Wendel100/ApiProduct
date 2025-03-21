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
    public IActionResult GetId(int id){
        var Id = _product.ListById(id);
        if (Id == null)
            return NotFound();

        return Ok(Id);
    }
    [HttpGet("{name}")]
    public IActionResult GetName(ProductModel name){
        _product.ListByName(name);
        return Ok(name);
    }
        [HttpPost]
        public IActionResult ToAdd(ProductModel product){
            _product.AddProduct(product);
            return Ok("Adcionadao com sucesso");
        }
    }
}