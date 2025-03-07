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
        public ProductService(IProductReadRepository productReadRepository, IQrCodeService qrCodeService)
        {
            _productReadRepository = productReadRepository;
            _qrCodeService = qrCodeService;
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
    }
}
