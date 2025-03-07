using MiniE_Commerce.Application.Abstractions.Services;
using MiniE_Commerce.Application.Repositories;
using MiniE_Commerce.Domain.Entities;
using System.Text.Json;

namespace MiniE_Commerce.Persistence.Services
{
    public class ProductService : IProductService
    {
        readonly IProductReadRepository _productReadRepository;
        readonly IQrCodeService _qrCodeService;
        readonly IProductWriteRepository _productWriteRepository;
        public ProductService(IProductReadRepository productReadRepository, IQrCodeService qrCodeService, IProductWriteRepository productWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _qrCodeService = qrCodeService;
            _productWriteRepository = productWriteRepository;
        }

        public async Task<byte[]> QrCodeToProductAsync(string productId)
        {
            Product product = await _productReadRepository.GetByIdAsync(productId);
            if (product == null)
                throw new Exception("Product not found");

            var plainObject = new
            {
                product.Id,
                product.Name,
                product.Price,
                product.Stock,
                product.CreatedAt
            };
            string plainText = JsonSerializer.Serialize(plainObject);
            return _qrCodeService.GenerateQrCode(plainText);
        }

        public async Task StockUpdateToProductAsync(string productId, int stock)
        {
            Product product = await _productReadRepository.GetByIdAsync(productId);
            if (product == null)
                throw new Exception("Product not found");
            product.Stock = stock;
            await _productWriteRepository.SaveAsync();
        }
    }
}
