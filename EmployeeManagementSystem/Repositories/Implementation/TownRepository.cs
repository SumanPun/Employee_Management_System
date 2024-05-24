using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Repositories.Contracts;
using EmployeeManagementSystem.Responses;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Repositories.Implementation
{
    public class TownRepository(AppDbContext appDbContext) : IGenericRepositoryInterface<Town>
    {
        public async Task<GeneralResponse> DeleteById(int id)
        {
            var town = await appDbContext.Towns.FindAsync(id);
            if (town is null) return NotFound();

            appDbContext.Towns.Remove(town);
            await Commit();
            return Success();
        }

        public async Task<List<Town>> GetAll() => await appDbContext.Towns.ToListAsync();

        public async Task<Town> GetById(int id) => await appDbContext.Towns.FindAsync(id);

        public async Task<GeneralResponse> Insert(Town item)
        {
            if (await CheckName(item.Name!) == true) return new GeneralResponse(false, "City already added");
            appDbContext.Towns.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(Town item)
        {
            var town = await appDbContext.Towns.FindAsync(item.Id);
            if (town is null) return NotFound();
            town.Name = item.Name;
            await Commit();
            return Success();
        }

        private static GeneralResponse NotFound() => new(false, "Sorry Town not found");
        private static GeneralResponse Success() => new(true, "Process completed");
        private async Task Commit() => await appDbContext.SaveChangesAsync();
        private async Task<bool> CheckName(string name)
        {
            var item = await appDbContext.Towns.FirstOrDefaultAsync(x => x.Name!.ToLower().Equals(name.ToLower()));
            if (item == null) return false;
            return true;
        }
    }
}
