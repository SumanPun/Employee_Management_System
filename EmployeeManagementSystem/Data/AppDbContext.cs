using EmployeeManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {

        public DbSet<Employee> Employees { get; set; }

        //General Department / Department /Branch
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<GeneralDepartment> GeneralDepartments { get; set; }

        //Country / Town / City
        public DbSet<Country> Countries { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<City> Cities { get; set; }

        //Authentication / Role / System Role 
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<SystemRole> SystemRoles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<RefreshTokenInfo> RefreshTokensInfos { get; set; }

        //Other / Vacation / Sanction / Doctor / OverTime
        public DbSet<Vacations> Vacations { get; set; }
        public DbSet<VacationType> VacationTypes { get; set; }

        public DbSet<OverTime> OverTimes { get; set; }
        public DbSet<OverTimeType> OverTimeTypes { get; set; }

        public DbSet<Sanction> Sanctions { get; set; }
        public DbSet<SanctionType> SanctionTypes { get; set; }

        public DbSet<Doctor> Doctors { get; set; }
    }
}
