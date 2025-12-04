using System.ComponentModel.DataAnnotations;

namespace WarehouseManagement.Core.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required,MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(150)]
        public string? Description { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
