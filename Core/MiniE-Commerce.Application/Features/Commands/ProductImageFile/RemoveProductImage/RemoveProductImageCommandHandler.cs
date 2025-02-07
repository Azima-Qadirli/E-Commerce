using MediatR;
using Microsoft.EntityFrameworkCore;
using MiniE_Commerce.Application.Repositories;

namespace MiniE_Commerce.Application.Features.Commands.ProductImageFile.RemoveProductImage
{
    public class RemoveProductImageCommandHandler : IRequestHandler<RemoveProductImageCommandRequest, RemoveProductImageCommandResponse>
    {
        readonly IProductReadRepository _readRepository;
        readonly IProductWriteRepository _writeRepository;

        public RemoveProductImageCommandHandler(IProductReadRepository readRepository, IProductWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        public async Task<RemoveProductImageCommandResponse> Handle(RemoveProductImageCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Product? product = await _readRepository.Table.Include(p => p.ProductImageFiles)
               .FirstOrDefaultAsync(p => p.Id == Guid.Parse(request.Id));

            Domain.Entities.ProductImageFile? productImageFile = product?.ProductImageFiles.FirstOrDefault(p => p.Id == Guid.Parse(request.ImageId));

            if (productImageFile != null)
                product?.ProductImageFiles.Remove(productImageFile);

            await _writeRepository.SaveAsync();
            return new();
        }
    }
}
