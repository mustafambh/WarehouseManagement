using System.ComponentModel.DataAnnotations;

namespace WarehouseManagement.Core.Entities
{
    public class StockTransaction
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        [Required]
        public int? SupplierId {  get; set; }
        public Supplier? Supplier { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public string TransactionType { get; set; } // IN or OUT
        [Required]
        public DateTime CreatedAt { get; set; }

    }
}
