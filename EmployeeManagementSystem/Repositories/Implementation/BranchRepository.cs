using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Repositories.Contracts;
using EmployeeManagementSystem.Responses;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Repositories.Implementation
{
    public class BranchRepository(AppDbContext appDbContext) : IGenericRepositoryInterface<Branch>
    {
        public async Task<GeneralResponse> DeleteById(int id)
        {
            var branch = await appDbContext.Branches.FindAsync(id);
            if (branch is null) return NotFound();

            appDbContext.Branches.Remove(branch);
            await Commit();
            return Success();
        }

        public async Task<List<Branch>> GetAll() => await appDbContext.Branches.ToListAsync();

        public async Task<Branch> GetById(int id) => await appDbContext.Branches.FindAsync(id);

        public async Task<GeneralResponse> Insert(Branch item)
        {
            if (await CheckName(item.Name!) == true) return new GeneralResponse(false, "Branch already added");
            appDbContext.Branches.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(Branch item)
        {
            var branch = await appDbContext.Branches.FindAsync(item.Id);
            if (branch is null) return NotFound();
            branch.Name = item.Name;
            await Commit();
            return Success();
        }

        private static GeneralResponse NotFound() => new(false, "Sorry branch not found");
        private static GeneralResponse Success() => new(true, "Process completed");
        private async Task Commit() => await appDbContext.SaveChangesAsync();
        private async Task<bool> CheckName(string name)
        {
            var item = await appDbContext.Branches.FirstOrDefaultAsync(x => x.Name!.ToLower().Equals(name.ToLower()));
            if (item == null) return false;
            return true;
        }
    }
}
