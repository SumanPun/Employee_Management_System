using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Models
{
    public class Doctor : OtherBaseModels
    {

        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string MedicalDiagnose { get; set; } = string.Empty;
        [Required]
        public string MedicalRecommendation { get; set; } = string.Empty ;
    }
}
