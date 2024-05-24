namespace EmployeeManagementSystem.Models
{
    public class GeneralDepartment : BaseModel
    {

        //one to many departments
        public List<Department>? Departments { get; set; }
    }
}
