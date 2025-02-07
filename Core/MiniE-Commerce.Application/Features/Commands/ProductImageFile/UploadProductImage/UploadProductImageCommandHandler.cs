using MediatR;
using MiniE_Commerce.Application.Abstractions.Storage;
using MiniE_Commerce.Application.Repositories;
using MiniE_Commerce.Application.Repositories.ProductImageFile;

namespace MiniE_Commerce.Application.Features.Commands.ProductImageFile.UploadProductImage
{
    public class UploadProductImageCommandHandler : IRequestHandler<UploadProductImageCommandRequest, UploadProductImageCommandResponse>
    {
        readonly IProductReadRepository _readRepository;
        readonly IStorageService _storageService;
        readonly IProductImageFileWriteRepository _productImageFileWriteRepository;

        public UploadProductImageCommandHandler(IProductReadRepository readRepository, IStorageService storageService, IProductImageFileWriteRepository productImageFileWriteRepository)
        {
            _readRepository = readRepository;
            _storageService = storageService;
            _productImageFileWriteRepository = productImageFileWriteRepository;
        }

        public async Task<UploadProductImageCommandResponse> Handle(UploadProductImageCommandRequest request, CancellationToken cancellationToken)
        {
            List<(string fileName, string pathOrContainerName)> result = await _storageService.UploadAsync("photo-images", request.Files);


            Domain.Entities.Product product = await _readRepository.GetByIdAsync(request.Id);


            await _productImageFileWriteRepository.AddRangeAsync(result.Select(r => new Domain.Entities.ProductImageFile
            {
                FileName = r.fileName,
                Path = r.pathOrContainerName,
                Storage = _storageService.StorageName,
                Products = new List<Domain.Entities.Product>() { product }
            }).ToList());

            await _productImageFileWriteRepository.SaveAsync();
            return new();
        }
    }
}
