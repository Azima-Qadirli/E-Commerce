using MediatR;
using MiniE_Commerce.Application.Repositories;

namespace MiniE_Commerce.Application.Features.Commands.Product.RemoveProduct
{
    public class RemoveProductCommandHandler : IRequestHandler<RemoveProductCommandRequest, RemoveProductCommandResponse>
    {
        readonly IProductWriteRepository _writeRepository;

        public RemoveProductCommandHandler(IProductWriteRepository writeRepository)
        {
            _writeRepository = writeRepository;
        }

        public async Task<RemoveProductCommandResponse> Handle(RemoveProductCommandRequest request, CancellationToken cancellationToken)
        {
            await _writeRepository.RemoveAsync(request.Id);
            await _writeRepository.SaveAsync();
            return new();
        }
    }
}
