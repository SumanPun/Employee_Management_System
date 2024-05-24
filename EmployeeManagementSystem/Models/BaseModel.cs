using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EmployeeManagementSystem.Models
{
    public class BaseModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;

        //One to Many
       // [JsonIgnore]
        //public List<Employee> Employees { get; set; }
    }
}
