using System;
using EmployeeManagement.Models;
using EmployeeManagement.Models.Data;

namespace EmployeeManagement.API.Data.Repository.Interfaces
{
	public interface IEmployeeRepository
	{
		Task<IEnumerable<Employee>> GetAllEmployees();

		Task<Employee>? GetEmployeeById(int empId);

		Task<Employee> InsertEmployee(Employee emp);

		Task<Employee> UpdateEmployee(Employee emp);

		Task<bool> DeleteEmployee(int empId);

        Task<IEnumerable<Employee>> Search(string name, Gender? gender);
    }
}

