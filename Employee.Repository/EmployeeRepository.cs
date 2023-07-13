using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Company.Core.Models;
using Company.Core.Repository;
using Company.Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace Company.Repository;
public class EmployeeRepository : IEmployeeRepository
{
    private readonly EmployeeDbContext _dbContext;
    private readonly IMapper _mapper;

    public EmployeeRepository(EmployeeDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<bool> AddEmployee(AddEmployeeRequest employee)
    {
        var newEmployee = _mapper.Map<Employee>(employee);
        newEmployee.CreatedOn = DateTime.Now;
        var newRow = await _dbContext.Employees.AddAsync(newEmployee);
        await _dbContext.SaveChangesAsync();

        return newRow is not null;
    }

    public async Task<List<EmployeeResponse>> GetAllEmployees()
    {
        var data = await _dbContext.Employees.OrderBy(x=>x.FirstName).ToListAsync();
        var response = _mapper.Map<List<EmployeeResponse>>(data);
        return response;
    }

    public async Task<bool> UpdateEmployee(int id, UpdateEmployeeRequest employee)
    {
        var existingEmployee = await _dbContext.Employees.FindAsync(id);

        if (existingEmployee == null)
            return false;
        existingEmployee.FirstName = employee.FirstName;
        existingEmployee.LastName = employee.LastName;
        existingEmployee.DateOfBirth = employee.DateOfBirth;
        existingEmployee.LastModifiedOn = DateTime.Now;

        _dbContext.Entry(existingEmployee).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteEmployee(int employeeId)
    {
        var employee = _dbContext.Employees.FirstOrDefault(e => e.Id == employeeId);
        if (employee != null)
        {
            _dbContext.Employees.Remove(employee);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        return false;
    }
}
