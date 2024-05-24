namespace EmployeeManagementSystem.Models
{
    public class Department : BaseModel
    {

        //many to one relations with general department
        public GeneralDepartment? GeneralDepartment { get; set; }
        public int GeneralDepartmentId { get; set; }

        //one to many relationship with branch
        public List<Branch>? Branches { get; set; }
    }
}
