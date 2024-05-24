namespace EmployeeManagementSystem.Models
{
    public class Town : BaseModel
    {

        //one to many with employee
        public List<Employee>? Employees { get; set; }

        //many to one relationship with city
        public City? City { get; set; }
        public int CityId { get; set; }
    }
}
