using System;
using EmployeeManagement.API.Data.Repository.Interfaces;
using EmployeeManagement.Models;
using EmployeeManagement.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.API.Data.Repository
{
	public class DepartmentRepository : IDepartmentRepository
	{
        public DepartmentRepository()
		{
            
		}

        public IEnumerable<Department> GetAllDepartments()
        {
            return ApiData.Departments;
        }

        public Department? GetDepartmentById(int departmentId)
        {
            return ApiData.Departments.FirstOrDefault(t => t.DepartmentId == departmentId);
        }
    }
}

