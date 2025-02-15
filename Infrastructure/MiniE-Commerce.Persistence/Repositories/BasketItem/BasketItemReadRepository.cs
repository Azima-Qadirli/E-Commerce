﻿using MiniE_Commerce.Application.Repositories;
using MiniE_Commerce.Domain.Entities;
using MiniE_Commerce.Persistence.Contexts;

namespace MiniE_Commerce.Persistence.Repositories
{
    public class BasketItemReadRepository : ReadRepository<BasketItem>, IBasketItemReadRepository
    {
        public BasketItemReadRepository(MiniE_CommerceDbContext context) : base(context)
        {
        }
    }
}
