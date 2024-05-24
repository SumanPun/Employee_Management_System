using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController(IGenericRepositoryInterface<Country> genericRepositoryInterface)
        : GenericController<Country>(genericRepositoryInterface)
    {
    }
}
