﻿using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Repositories.Contracts;
using EmployeeManagementSystem.Responses;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Repositories.Implementation
{
    public class CountryRepository(AppDbContext appDbContext) : IGenericRepositoryInterface<Country>
    {
        public async Task<GeneralResponse> DeleteById(int id)
        {
            var country = await appDbContext.Countries.FindAsync(id);
            if (country is null) return NotFound();

            appDbContext.Countries.Remove(country);
            await Commit();
            return Success();
        }

        public async Task<List<Country>> GetAll() => await appDbContext.Countries.ToListAsync();
        public async Task<Country> GetById(int id) => await appDbContext.Countries.FindAsync(id);

        public async Task<GeneralResponse> Insert(Country item)
        {
            if (await CheckName(item.Name!) == true) return new GeneralResponse(false, "Country already added");
            appDbContext.Countries.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(Country item)
        {
            var country = await appDbContext.Countries.FindAsync(item.Id);
            if (country is null) return NotFound();
            country.Name = item.Name;
            await Commit();
            return Success();
        }

        private static GeneralResponse NotFound() => new(false, "Sorry Country not found");
        private static GeneralResponse Success() => new(true, "Process completed");
        private async Task Commit() => await appDbContext.SaveChangesAsync();
        private async Task<bool> CheckName(string name)
        {
            var item = await appDbContext.Countries.FirstOrDefaultAsync(x => x.Name!.ToLower().Equals(name.ToLower()));
            if (item == null) return false;
            return true;
        }
    }
}
