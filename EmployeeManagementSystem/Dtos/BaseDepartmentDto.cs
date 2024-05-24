using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Dtos
{
    public class BaseDepartmentDto
    {
        public int Id { get; set; }
        [Required, MinLength(3), MaxLength(50)]
        public string? Name { get; set; }
    }
}
