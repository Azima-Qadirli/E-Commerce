﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using MiniE_Commerce.Application.Repositories.ProductImageFile;

namespace MiniE_Commerce.Application.Features.Commands.ProductImageFile.ChangeShowCaseImage
{
    public class ChangeShowCaseImageCommandHandler : IRequestHandler<ChangeShowCaseImageCommandRequest, ChangeShowCaseImageCommandResponse>
    {
        readonly IProductImageFileWriteRepository _productImageFileWriteRepository;

        public ChangeShowCaseImageCommandHandler(IProductImageFileWriteRepository productImageFileWriteRepository)
        {
            _productImageFileWriteRepository = productImageFileWriteRepository;
        }

        public async Task<ChangeShowCaseImageCommandResponse> Handle(ChangeShowCaseImageCommandRequest request, CancellationToken cancellationToken)
        {
            var query = _productImageFileWriteRepository.Table
                .Include(p => p.Products)
                .SelectMany(p => p.Products, (pif, p) => new
                {
                    pif,
                    p
                });

            var data = await query.FirstOrDefaultAsync(p => p.p.Id == Guid.Parse(request.ProductId) && p.pif.ShowCase);
            if (data != null)
                data.pif.ShowCase = false;
            var image = await query.FirstOrDefaultAsync(p => p.p.Id == Guid.Parse(request.ImageId));
            if (image != null)
                image.pif.ShowCase = true;

            await _productImageFileWriteRepository.SaveAsync();
            return new();

        }
    }
}
