using Company.Core.Models;

namespace Company.Core.Services
{
    public interface IEmployeeService
    {
        Task<List<EmployeeResponse>> GetAllEmployees();
        Task<bool> AddEmployee(AddEmployeeRequest employee);
        Task<bool> UpdateEmployee(int id, UpdateEmployeeRequest employee);
        Task<bool> DeleteEmployee(int employeeId);
    }
}
