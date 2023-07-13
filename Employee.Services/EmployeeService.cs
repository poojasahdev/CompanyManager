using Company.Core.Models;
using Company.Core.Repository;
using Company.Core.Services;

namespace Company.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<List<EmployeeResponse>> GetAllEmployees()
        {
            return await _employeeRepository.GetAllEmployees();
        }

        public async Task<bool> AddEmployee(AddEmployeeRequest employee)
        {
            return await _employeeRepository.AddEmployee(employee);
        }

        public async Task<bool> UpdateEmployee(int id, UpdateEmployeeRequest employee)
        {
            var updated = await _employeeRepository.UpdateEmployee(id, employee);
            if(!updated)
            {
                throw new Exception($"Employee with id {id} Does not exists");
            }
            return updated;
        }

        public async Task<bool> DeleteEmployee(int employeeId)
        {
            var deleted = await _employeeRepository.DeleteEmployee(employeeId);
            if (!deleted)
            {
                throw new Exception($"Employee with id {employeeId} Does not exists");
            }

            return deleted;
        }
    }

}