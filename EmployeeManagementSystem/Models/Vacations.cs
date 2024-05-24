using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Models
{
    public class Vacations : OtherBaseModels
    {

        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public int NumberOfDays { get; set; }
        public DateTime EndDate => StartDate.AddDays(NumberOfDays);

        //many to one with vacation type
        public VacationType? VacationType { get; set; }
        [Required]
        public int VacationTypeId { get; set; }
    }
}
