using System;
using EmployeeManagement.Models;
using EmployeeManagement.Models.Data;

namespace EmployeeManagement.API.Data.Repository.Interfaces
{
	public interface IEmployeeRepository
	{
		IEnumerable<Employee> GetAllEmployees();

		Employee? GetEmployeeById(int empId);

		Employee InsertEmployee(Employee emp);

		Employee UpdateEmployee(Employee emp);

		bool DeleteEmployee(int empId);

        IEnumerable<Employee> Search(string name, Gender? gender);
    }
}

