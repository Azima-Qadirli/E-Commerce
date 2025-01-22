﻿using Microsoft.AspNetCore.Mvc;
using MiniE_Commerce.Application;

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
        public async void Get()
        {
            await _productWriteRepository.AddRangeAsync(new()
            {
                new() { Id = Guid.NewGuid(), Name = "Product 1", Price = 10, CreatedAt = DateTime.Now, Stock = 100},
                new() { Id = Guid.NewGuid(), Name = "Product 2", Price = 20, CreatedAt = DateTime.Now, Stock = 200},
                new() { Id = Guid.NewGuid(), Name = "Product 3", Price = 30, CreatedAt = DateTime.Now, Stock = 300},
            });
            await _productWriteRepository.SaveAsync();
        }
    }
}
