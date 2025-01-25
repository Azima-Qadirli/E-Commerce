using Microsoft.AspNetCore.Mvc;
using MiniE_Commerce.Application;
using MiniE_Commerce.Domain.Entities;

namespace MiniE_Commerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductReadRepository _productReadRepository;
        private readonly IProductWriteRepository _productWriteRepository;

        public ProductsController(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
        }
        [HttpGet]
        public async Task Get()
        {
            //await _productWriteRepository.AddRangeAsync(new()
            //{
            //    new() { Id = Guid.NewGuid(), Name = "Product 1", Price = 10, CreatedAt = DateTime.Now, Stock = 100},
            //    new() { Id = Guid.NewGuid(), Name = "Product 2", Price = 20, CreatedAt = DateTime.Now, Stock = 200},
            //    new() { Id = Guid.NewGuid(), Name = "Product 3", Price = 30, CreatedAt = DateTime.Now, Stock = 300},
            //});
            //var count = await _productWriteRepository.SaveAsync();
            Product p = await _productReadRepository.GetByIdAsync("F5B633E3-F118-4053-B86F-DA413D9D24F7", true);
            p.Name = "Mercedes CLE200";
            await _productWriteRepository.SaveAsync();
        }
        [HttpGet("id")]
        public async Task<IActionResult> Get(string id)
        {
            Product product = await _productReadRepository.GetByIdAsync(id);
            return Ok(product);
        }
    }
}
