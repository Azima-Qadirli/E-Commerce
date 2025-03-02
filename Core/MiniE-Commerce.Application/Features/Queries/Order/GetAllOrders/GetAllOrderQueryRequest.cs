﻿using MediatR;

namespace MiniE_Commerce.Application.Features.Queries.Order.GetAllOrders
{
    public class GetAllOrderQueryRequest : IRequest<GetAllOrderQueryResponse>
    {
        public int Page { get; set; } = 0;
        public int Size { get; set; } = 5;
    }
}
