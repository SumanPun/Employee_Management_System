namespace EmployeeManagementSystem.Models
{
    public class SanctionType : BaseModel
    {

        //many to one with Vacation
        public List<Sanction> Sanctions { get; set; }
    }
}
