﻿using Microsoft.EntityFrameworkCore;
using MiniE_Commerce.Application.Abstractions.Services;
using MiniE_Commerce.Application.DTO.Order;
using MiniE_Commerce.Application.Repositories;
using MiniE_Commerce.Domain.Entities;

namespace MiniE_Commerce.Persistence.Services
{
    public class OrderService : IOrderService
    {
        readonly IOrderWriteRepository _orderWriteRepository;
        readonly IOrderReadRepository _orderReadRepository;
        readonly ICompletedOrderWriteRepository _completedOrderWriteRepository;
        readonly ICompletedOrderReadRepository _completedOrderReadRepository;
        public OrderService(IOrderWriteRepository orderWriteRepository, IOrderReadRepository orderReadRepository, ICompletedOrderWriteRepository completedOrderWriteRepository, ICompletedOrderReadRepository completedOrderReadRepository)
        {
            _orderWriteRepository = orderWriteRepository;
            _orderReadRepository = orderReadRepository;
            _completedOrderWriteRepository = completedOrderWriteRepository;
            _completedOrderReadRepository = completedOrderReadRepository;
        }

        public async Task CreateOrderAsync(CreateOrder order)
        {
            var orderCode = (new Random().NextDouble() * 100000).ToString();
            orderCode = orderCode.Substring(orderCode.IndexOf(".") + 1, orderCode.Length - orderCode.IndexOf('.') - 1);
            await _orderWriteRepository.AddAsync(new()
            {
                Address = order.Address,
                Id = Guid.Parse(order.BasketId),
                Description = order.Description,
                OrderCode = orderCode
            });
            await _orderWriteRepository.SaveAsync();
        }

        public async Task<ListOrder> GetAllOrdersAsync(int page, int size)
        {
            var query = _orderReadRepository.Table.Include(o => o.Basket)
                 .ThenInclude(b => b.User)
                 .Include(o => o.Basket)
                 .ThenInclude(b => b.BasketItems)
                 .ThenInclude(bi => bi.Product);

            var data = query.Skip(page * size).Take(size);

            var data2 = (from order in query
                         join completedOrder in _completedOrderReadRepository.Table
                         on order.Id equals completedOrder.OrderId into co
                         from _co in co.DefaultIfEmpty()
                         select new
                         {
                             Id = order.Id,
                             Basket = order.Basket,
                             CreatedDate = order.CreatedAt,
                             OrderCode = order.OrderCode,
                             Completed = _co != null ? true : false
                         });

            return new()
            {
                TotalOrderCount = await query.CountAsync(),
                Orders = await data2.Select(o => new
                {
                    Id = o.Id,
                    CreatedDate = o.CreatedDate,
                    OrderCode = o.OrderCode,
                    TotalPrice = o.Basket.BasketItems.Sum(bi => bi.Product.Price * bi.Quantity),
                    UserName = o.Basket.User.UserName,
                    o.Completed
                }).ToListAsync()
            };
        }

        public async Task<SingleOrder> GetOrderByIdAsync(string id)
        {
            var data = _orderReadRepository.Table
                .Include(o => o.Basket)
                .ThenInclude(b => b.BasketItems)
                .ThenInclude(bi => bi.Product);


            var data2 = await (from order in data
                               join completedOrder in _completedOrderReadRepository.Table
                               on order.Id equals completedOrder.OrderId into co
                               from _co in co.DefaultIfEmpty()
                               select new
                               {
                                   Id = order.Id,
                                   Basket = order.Basket,
                                   CreatedDate = order.CreatedAt,
                                   OrderCode = order.OrderCode,
                                   Completed = _co != null ? true : false,
                                   Address = order.Address,
                                   Description = order.Description
                               }).FirstOrDefaultAsync(o => o.Id == Guid.Parse(id));

            return new()
            {
                Id = data2.Id.ToString(),
                Address = data2.Address,
                CreatedDate = data2.CreatedDate,
                Description = data2.Description,
                OrderCode = data2.OrderCode,
                BasketItems = data2.Basket.BasketItems.Select(bi => new
                {
                    bi.Product.Name,
                    bi.Product.Price,
                    bi.Quantity
                }),
                Completed = data2.Completed
            };
        }

        public async Task<(bool, CompletedOrderDto)> CompleteOrderAsync(string id)
        {
            Order? order = await _orderReadRepository.Table
                .Include(o => o.Basket)
                .ThenInclude(b => b.User)
                .FirstOrDefaultAsync(o => o.Id == Guid.Parse(id));
            if (order != null)
            {
                await _completedOrderWriteRepository.AddAsync(new()
                {
                    OrderId = Guid.Parse(id)
                });
                return (await _completedOrderWriteRepository.SaveAsync() > 0, new()
                {
                    OrderCode = order.OrderCode,
                    OrderDate = order.CreatedAt,
                    UserName = order.Basket.User.UserName,
                    Email = order.Basket.User.Email
                });
            }
            return (false, null);
        }
    }
}
