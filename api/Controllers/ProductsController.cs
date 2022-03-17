using System;
using System.Threading.Tasks;
using Api.Controllers.Models;
using Api.Data.Entities;
using Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {

        public ProductsController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        private readonly IProductRepository productRepository;

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] AddProductModel model)
        {
            if (model == null)
            {
                return BadRequest(new { error = "No product to add!" });
            }

            var product = new Product
            {
                Id = Guid.NewGuid().ToString("N"),
                Name = model.Name,
                Price = model.Price
            };

            var addedProduct = await this.productRepository.UpsertProductAsync(product);

            return CreatedAtRoute("GetProduct", new { id = addedProduct.Id }, addedProduct);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductModel model)
        {
            if (model == null)
            {
                return BadRequest(new { error = "No product to update!" });
            }

            var product = new Product
            {
                Id = model.Id,
                Name = model.Name,
                Price = model.Price
            };

            var updatedProduct = await this.productRepository.UpsertProductAsync(product);

            return CreatedAtRoute("GetProduct", new { id = updatedProduct.Id }, updatedProduct);
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await this.productRepository.GetProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id}", Name = "GetProduct")]
        public async Task<IActionResult> GetProduct(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return BadRequest(new { error = "Product id not specified!" });
            }

            var product = await this.productRepository.GetProductAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }
    }
}