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

        public async Task<IEnumerable<Department>> GetAllDepartments()
        {
            return await ApiData.GetDepartmemts();
        }

        public async Task<Department?> GetDepartmentById(int departmentId)
        {
            return (await ApiData.GetDepartmemts()).FirstOrDefault(t => t.DepartmentId == departmentId);
        }
    }
}

