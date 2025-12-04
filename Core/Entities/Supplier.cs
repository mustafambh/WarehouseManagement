using System.ComponentModel.DataAnnotations;

namespace WarehouseManagement.Core.Entities
{
    public class Supplier
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public string Phone { get; set; }
        public string? Email { get; set; }
        [Required]
        public string Address { get; set; }

        public ICollection<StockTransaction> StockTransactions { get; set; } = new List<StockTransaction>();

    }
}
