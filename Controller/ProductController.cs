using EcoApi.Model;
using EcoApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace EcoApi.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
    private readonly IProductService _product;

    public ProductController(IProductService service)
    {
        _product = service;
    }
        [HttpPost]
        public IActionResult ToAdd(ProductModel product){
            _product.AddProduct(product);
            return Ok("Adcionadao com sucesso");
        }
    }
}