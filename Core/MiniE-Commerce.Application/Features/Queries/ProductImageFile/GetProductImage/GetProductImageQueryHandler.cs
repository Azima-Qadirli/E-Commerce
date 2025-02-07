using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MiniE_Commerce.Application.Repositories;

namespace MiniE_Commerce.Application.Features.Queries.ProductImageFile.GetProductImage
{
    public class GetProductImageQueryHandler : IRequestHandler<GetProductImageQueryRequest, List<GetProductImageQueryResponse>>
    {
        readonly IProductReadRepository _readRepository;
        readonly IConfiguration _configuration;

        public GetProductImageQueryHandler(IProductReadRepository readRepository, IConfiguration configuration)
        {
            _readRepository = readRepository;
            _configuration = configuration;
        }

        public async Task<List<GetProductImageQueryResponse>> Handle(GetProductImageQueryRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Product? product = await _readRepository.Table.Include(p => p.ProductImageFiles)
                  .FirstOrDefaultAsync(p => p.Id == Guid.Parse(request.Id));
            return product.ProductImageFiles.Select(p => new GetProductImageQueryResponse
            {
                Path = $"{_configuration["BaseStorageUrl"]}/{p.Path}",
                FileName = p.FileName,
                Id = p.Id
            }).ToList();
        }
    }
}
