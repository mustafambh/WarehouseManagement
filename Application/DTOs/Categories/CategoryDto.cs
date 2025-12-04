using System.ComponentModel.DataAnnotations;

namespace WarehouseManagement.Application.DTOs.Categories
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
