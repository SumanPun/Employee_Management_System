using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Repositories.Contracts;
using EmployeeManagementSystem.Responses;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Repositories.Implementation
{
    public class EmployeeRepository(AppDbContext appDbContext) : IGenericRepositoryInterface<Employee>
    {
        public async Task<GeneralResponse> DeleteById(int id)
        {
            var emp = await appDbContext.Employees.FindAsync(id);
            if (emp is null) return NotFound();

            appDbContext.Employees.Remove(emp);
            await Commit();
            return Success();
        }

        public async Task<List<Employee>> GetAll() => await appDbContext.Employees.ToListAsync();

        public async Task<Employee> GetById(int id) => await appDbContext.Employees.FindAsync(id);

        public async Task<GeneralResponse> Insert(Employee item)
        {
            if (await CheckName(item.Name!) == true) return new GeneralResponse(false, "Employee already added");
            appDbContext.Employees.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(Employee item)
        {
            var emp = await appDbContext.Employees.FindAsync(item.Id);
            if (emp is null) return NotFound();
            emp.Name = item.Name;
            emp.TelephoneNumber = item.TelephoneNumber;
            emp.BranchId = item.BranchId;
            emp.TownId = item.TownId;
            emp.FileNumber = item.FileNumber;
            emp.CivilId = item.CivilId;
            emp.Address = item.Address;
            emp.JobName = item.JobName;
            emp.Photo = item.Photo;
            emp.Other = item.Other;
            await Commit();
            return Success();
        }

        private static GeneralResponse NotFound() => new(false, "Sorry Employee not found");
        private static GeneralResponse Success() => new(true, "Process completed");
        private async Task Commit() => await appDbContext.SaveChangesAsync();
        private async Task<bool> CheckName(string name)
        {
            var item = await appDbContext.Employees.FirstOrDefaultAsync(x => x.Name!.ToLower().Equals(name.ToLower()));
            if (item == null) return false;
            return true;
        }
    }
}
