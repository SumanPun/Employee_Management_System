namespace EmployeeManagementSystem.Models
{
    public class Country : BaseModel
    {

        //one to many relationship with city
        public List<City>? Cities { get; set; }
    }
}
