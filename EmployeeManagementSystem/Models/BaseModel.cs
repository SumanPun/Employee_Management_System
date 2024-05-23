using System.Text.Json.Serialization;

namespace EmployeeManagementSystem.Models
{
    public class BaseModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        //One to Many
        [JsonIgnore]
        public List<Employee> Employees { get; set; }
    }
}
