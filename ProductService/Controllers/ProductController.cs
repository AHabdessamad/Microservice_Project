using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using ProductService.Data;
using ProductService.Dto;
using ProductService.Models;
using ZstdSharp.Unsafe;

namespace ProductService.Controllers
{
     [ApiController]
     [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        // Get api/Products
        // Post /api/Products 
        // Put  /api/Products
        // Delete /api/Products
        // Get /api/Products/GetProductById/{id}
        // Get /api/Products/GetProductByCatgory/{category}
        // Get /api/Products/GetProductByName/{Name}

       private readonly IMongoCollection<Product>? _products;

       public ProductController(ProductContext productContext)
       {
         _products = productContext.Database?.GetCollection<Product>("product");
       }

       [HttpGet]
       public  async Task<IEnumerable<Product>> Get()
       {
        return await _products.Find(FilterDefinition<Product>.Empty).ToListAsync();
       }

       [HttpGet("{id}")]
       public async Task<ActionResult<Product>> GetById(string id)
       {
            var filter = Builders<Product>.Filter.Eq(p => p.Id, id);
            var product = await _products.Find(filter).FirstOrDefaultAsync();
            return   product is not null ? Ok(product): NotFound();
       }
       [HttpPost]
       public async Task<ActionResult> Create(Product product)
       {
            await _products!.InsertOneAsync(product);
            return CreatedAtAction(nameof(GetById), new { Id = product.Id}, product);
       }

       [HttpDelete]
       public async Task<ActionResult> Delete(string id)
       {
            var filter = Builders<Product>.Filter.Eq(p => p.Id, id);
            await _products!.DeleteOneAsync(filter);
            return Ok();
       }

       [HttpPut]
       public async Task<ActionResult> Put(Product product)
       {
            var filter = Builders<Product>.Filter.Eq(p => p.Id, product.Id);
            await _products!.ReplaceOneAsync(filter, product);
            return Ok();
       }

       [Route("[action]/{name}")]
       [HttpGet]
       public async Task<ActionResult<ProductDto>> GetProductByName(string name)
       {
            var filter = Builders<Product>.Filter.Eq(p => p.Name, name);
            var products = await _products.Find(filter).FirstOrDefaultAsync();
            return   products is not null ? Ok(products): NotFound();
       }

    }
}