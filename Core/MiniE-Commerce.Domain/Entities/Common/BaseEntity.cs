namespace MiniE_Commerce.Domain.Entities.Common
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        virtual public DateTime UpdatedAt { get; set; }
    }
}
