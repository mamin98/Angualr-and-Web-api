using Backend.Entities;
using Backend.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IGenericRepository<Product> _product;
        private readonly IGenericRepository<ProductType> _producttype;
        private readonly IGenericRepository<ProductBrand> _productbrand;

        public ProductController(IGenericRepository<Product> product,
            IGenericRepository<ProductBrand> productbrand,
            IGenericRepository<ProductType> producttype)
        {
            _product = product;
            _producttype = producttype;
            _productbrand = productbrand;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts() 
        {
            var products = await _product.ListAllAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Product>>> GetProductById(int id)
        {
            var product = await _product.GetByIdAsync(id);
            return Ok(product);
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            return Ok(await _product.ListAllAsync());
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return Ok(await _product.ListAllAsync());
        }
    }
}
