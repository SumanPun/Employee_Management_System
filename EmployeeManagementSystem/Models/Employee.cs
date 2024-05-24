using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Models
{
    public class Employee : BaseModel
    {
        [Required]
        public string CivilId { get; set; } = string.Empty;
        [Required]
        public string FileNumber { get; set; } = string.Empty;
        [Required]
        public string FullName { get; set; } = string.Empty;
        [Required]
        public string JobName { get; set; } = string.Empty;
        [Required]
        public string Address { get; set; } = string.Empty;
        [Required, DataType(DataType.PhoneNumber)]
        public string TelephoneNumber { get; set; } = string.Empty;
        [Required]
        public string Photo { get; set; } = string.Empty;
        public string? Other { get; set; }

        //Many to One relationship with branch
        public Branch? Branch { get; set; }
        public int BranchId { get; set; }
        public Town? Town { get; set; }
        public int? TownId { get; set; }
    }
}
