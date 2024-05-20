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
        public IEnumerable<Employee> GetAllEmployees()
        {
            return ApiData.Employees;
        }

        public Employee? GetEmployeeById(int empId)
        {
            return ApiData.Employees.FirstOrDefault(t => t.EmployeeId == empId);
        }

        public Employee InsertEmployee(Employee emp)
        {
            ApiData.Employees.Add(emp);
            return emp;
        }

        public Employee UpdateEmployee(Employee emp)
        {
            var employee = GetEmployeeById(emp.EmployeeId) ?? new Employee();
            employee.DateOfBrith = emp.DateOfBrith;
            employee.DepartmentId = emp.DepartmentId;
            employee.Email = emp.Email;
            employee.FirstName = emp.FirstName;
            employee.Gender = emp.Gender;
            employee.LastName = emp.LastName;
            employee.PhotoPath = emp.PhotoPath;

            return employee;
        }

        public bool DeleteEmployee(int empId)
        {
            var employee = GetEmployeeById(empId);
            if(employee != null)
            {
                ApiData.Employees.Remove(employee);
                return true;
            }
            return false;
        }

        public IEnumerable<Employee> Search(string name, Gender? gender)
        {
            var query = ApiData.Employees;

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

