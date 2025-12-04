using System.ComponentModel.DataAnnotations;

namespace WarehouseManagement.Application.DTOs.Suppliers
{
    public class SupplierUpdateDto
    {
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public string Phone { get; set; }
        public string? Email { get; set; }
        [Required]
        public string Address { get; set; }
    }
}
