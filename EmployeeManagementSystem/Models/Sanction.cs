using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Models
{
    public class Sanction : OtherBaseModels
    {
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string? Punishment { get; set; } = string.Empty;
        [Required]
        public DateTime PunishmentDate { get; set; }

        //many to one with vacation Type
        public SanctionType? SanctionType { get; set; }
    }
}
