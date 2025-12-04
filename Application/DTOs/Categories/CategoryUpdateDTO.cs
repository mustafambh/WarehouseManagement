using System.ComponentModel.DataAnnotations;

namespace WarehouseManagement.Application.DTOs.Categories
{
    public class CategoryUpdateDTO
    {
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(150)]
        public string? Description { get; set; }
    }
}
