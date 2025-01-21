using MiniE_Commerce.Domain.Entities.Common;

namespace MiniE_Commerce.Domain.Entities
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
