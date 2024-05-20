using System;
using EmployeeManagement.Models;

namespace EmployeeManagement.Web.Services
{
	public interface IEmployeeService
	{
		public Task<IEnumerable<Employee>> GetEmployees();
		public Task<Employee> GetEmployee(int id);

    }
}

