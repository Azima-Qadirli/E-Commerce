using MiniE_Commerce.Domain.Entities.Common;
using MiniE_Commerce.Domain.Entities.Identity;

namespace MiniE_Commerce.Domain.Entities
{
    public class Basket : BaseEntity
    {
        public string UserId { get; set; }
        public Guid OrderId { get; set; }
        public AppUser User { get; set; }
        public Order Order { get; set; }
        public ICollection<BasketItem> BasketItems { get; set; }
    }
}
