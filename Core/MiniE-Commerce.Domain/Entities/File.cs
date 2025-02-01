using MiniE_Commerce.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniE_Commerce.Domain.Entities
{
    public class File : BaseEntity
    {
        public string FileName { get; set; }
        public string Path { get; set; }
        [NotMapped]
        public override DateTime UpdatedAt { get => base.UpdatedAt; set => base.UpdatedAt = value; }
    }
}
