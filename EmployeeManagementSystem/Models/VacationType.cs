namespace EmployeeManagementSystem.Models
{
    public class VacationType : BaseModel
    {

        //one to many relation with vacation
        public List<Vacations>? Vacations { get; set; }
    }
}
