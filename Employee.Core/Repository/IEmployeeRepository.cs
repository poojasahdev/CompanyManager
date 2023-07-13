using Company.Core.Models;

namespace Company.Core.Repository
{
    public interface IEmployeeRepository
    {
        public Task<bool> AddEmployee(AddEmployeeRequest employee);
        public Task<List<EmployeeResponse>> GetAllEmployees();

        public Task<bool> UpdateEmployee(int id, UpdateEmployeeRequest employee);

        public Task<bool> DeleteEmployee(int employeeId);

    }

}