using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController(IGenericRepositoryInterface<Branch> genericRepositoryInterface)
        : GenericController<Branch>(genericRepositoryInterface)
    {
    }
}
