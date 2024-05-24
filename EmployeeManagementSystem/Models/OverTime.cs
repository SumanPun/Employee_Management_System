using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Models
{
    public class OverTime : OtherBaseModels
    {

        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        public int NumberOfDays => (EndDate - StartDate).Days;

        //many to one with vacation type
        public OverTimeType? OverTimeType { get; set; }
        [Required]
        public int OverTimeTypeId { get; set; }
    }
}
