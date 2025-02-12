using MediatR;
using Microsoft.Extensions.Logging;
using MiniE_Commerce.Application.Repositories;
using P = MiniE_Commerce.Domain.Entities;
namespace MiniE_Commerce.Application.Features.Commands.Product.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
    {
        readonly IProductReadRepository _readRepository;
        readonly IProductWriteRepository _writeRepository;
        readonly ILogger<UpdateProductCommandHandler> _logger;
        public UpdateProductCommandHandler(IProductReadRepository readRepository, IProductWriteRepository writeRepository, ILogger<UpdateProductCommandHandler> logger)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
            _logger = logger;
        }

        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            P.Product product = await _readRepository.GetByIdAsync(request.Id);
            product.Name = request.Name;
            product.Price = request.Price;
            product.Stock = request.Stock;
            await _writeRepository.SaveAsync();
            _logger.LogInformation("Product is updated...");
            return new();
        }
    }
}
