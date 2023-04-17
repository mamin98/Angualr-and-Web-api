using AutoMapper;
using Backend.DTOs;
using Backend.Entities;
using Backend.Repository;
using Backend.Specification;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseApiController
    {
        private readonly IGenericRepository<Product> _product;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<ProductType> _producttype;
        private readonly IGenericRepository<ProductBrand> _productbrand;

        public ProductController(IGenericRepository<Product> product,
            IMapper mapper,
            IGenericRepository<ProductBrand> productbrand,
            IGenericRepository<ProductType> producttype)
        {
            _product = product;
            _mapper = mapper;
            _producttype = producttype;
            _productbrand = productbrand;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductDto>>> GetProducts() 
        {
            var spec = new ProductWithTypesAndBrandsSpecification();

            var products = await _product.ListAsync(spec);
            //return products.Select(product => new ProductDto()
            //{
            //    Id = product.Id,
            //    Name = product.Name,
            //    Description = product.Description,
            //    PictureUrl = product.PictureUrl,
            //    Price = product.Price,
            //    ProductBrand = product.ProductBrand.Name,
            //    ProductType = product.ProductType.Name
            //}).ToList();

            return Ok(_mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductDto>>(products));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProductById(int id)
        {
            var spec = new ProductWithTypesAndBrandsSpecification();

            var product = await _product.GetEntityWithSpec(spec);
            //return new ProductDto()
            //{
            //    Id = product.Id,
            //    Name = product.Name,
            //    Description = product.Description,
            //    PictureUrl = product.PictureUrl,
            //    Price = product.Price,
            //    ProductBrand = product.ProductBrand.Name,
            //    ProductType = product.ProductType.Name
            //};

            return _mapper.Map<Product, ProductDto>(product);
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
