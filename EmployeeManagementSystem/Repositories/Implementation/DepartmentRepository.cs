using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Repositories.Contracts;
using EmployeeManagementSystem.Responses;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Repositories.Implementation
{
    public class DepartmentRepository(AppDbContext appDbContext) : IGenericRepositoryInterface<Department>
    {
        public async Task<GeneralResponse> DeleteById(int id)
        {
            var dep = await appDbContext.Departments.FindAsync(id);
            if (dep is null) return NotFound();

            appDbContext.Departments.Remove(dep);
            await Commit();
            return Success();
        }

        public async Task<List<Department>> GetAll() => await appDbContext.Departments.ToListAsync();

        public async Task<Department> GetById(int id) => await appDbContext.Departments.FindAsync(id);

        public async Task<GeneralResponse> Insert(Department item)
        {
            if (await CheckName(item.Name!) == true) return new GeneralResponse(false, "Department already added");
            appDbContext.Departments.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(Department item)
        {
            var dep = await appDbContext.Departments.FindAsync(item.Id);
            if (dep is null) return NotFound();
            dep.Name = item.Name;
            await Commit();
            return Success();
        }

        private static GeneralResponse NotFound() => new(false, "Sorry Department not found");
        private static GeneralResponse Success() => new(true, "Process completed");
        private async Task Commit() => await appDbContext.SaveChangesAsync();
        private async Task<bool> CheckName(string name)
        {
            var item = await appDbContext.Departments.FirstOrDefaultAsync(x => x.Name!.ToLower().Equals(name.ToLower()));
            if (item == null) return false;
            return true;
        }
    }
}
