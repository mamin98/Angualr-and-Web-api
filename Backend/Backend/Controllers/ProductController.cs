﻿using Backend.DTOs;
using Backend.Entities;
using Backend.Repository;
using Backend.Specification;
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
        public async Task<ActionResult<List<ProductDto>>> GetProducts() 
        {
            var spec = new ProductWithTypesAndBrandsSpecification();

            var products = await _product.ListAsync(spec);
            return products.Select(product => new ProductDto()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                PictureUrl = product.PictureUrl,
                Price = product.Price,
                ProductBrand = product.ProductBrand.Name,
                ProductType = product.ProductType.Name
            }).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProductById(int id)
        {
            var spec = new ProductWithTypesAndBrandsSpecification();

            var product = await _product.GetEntityWithSpec(spec);
            return new ProductDto()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                PictureUrl = product.PictureUrl,
                Price = product.Price,
                ProductBrand = product.ProductBrand.Name,
                ProductType = product.ProductType.Name
            };
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
