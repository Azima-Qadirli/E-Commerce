﻿namespace MiniE_Commerce.Application.Features.Queries.Order.GetAllOrders
{
    public class GetAllOrderQueryResponse
    {
        public int TotalOrderCount { get; set; }
        public object Orders { get; set; }
    }
}
