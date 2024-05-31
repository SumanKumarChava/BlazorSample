using System;
using EmployeeManagement.Api.Data;
using EmployeeManagement.API.Data.Repository.Interfaces;
using EmployeeManagement.Models;
using EmployeeManagement.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.API.Data.Repository
{
	public class EmployeeRepository : IEmployeeRepository
	{
		public EmployeeRepository()
		{
            
        }
        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            return await ApiData.GetEmployees();
        }

        public async Task<Employee>? GetEmployeeById(int empId)
        {
            return (await ApiData.GetEmployees()).FirstOrDefault(t => t.EmployeeId == empId);
        }

        public async Task<Employee> InsertEmployee(Employee emp)
        {
            (await ApiData.GetEmployees()).Add(emp);
            return emp;
        }

        public async Task<Employee> UpdateEmployee(Employee emp)
        {
            var employee = await GetEmployeeById(emp.EmployeeId) ?? new Employee();
            employee.DateOfBrith = emp.DateOfBrith;
            employee.DepartmentId = emp.DepartmentId;
            employee.Email = emp.Email;
            employee.FirstName = emp.FirstName;
            employee.Gender = emp.Gender;
            employee.LastName = emp.LastName;
            employee.PhotoPath = emp.PhotoPath;

            return employee;
        }

        public async Task<bool> DeleteEmployee(int empId)
        {
            var employee = await GetEmployeeById(empId);
            if(employee != null)
            {
                (await ApiData.GetEmployees()).Remove(employee);
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Employee>> Search(string name, Gender? gender)
        {
            var query = await ApiData.GetEmployees();

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(e => e.FirstName.Contains(name)
                            || e.LastName.Contains(name)).ToList();
            }

            if (gender != null)
            {
                query = query.Where(e => e.Gender == gender).ToList();
            }

            return query;
        }
    }
}

