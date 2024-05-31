using System;
using EmployeeManagement.Models;
using EmployeeManagement.Models.Data;

namespace EmployeeManagement.API.Data.Repository.Interfaces
{
	public interface IDepartmentRepository
	{
        Task<IEnumerable<Department>> GetAllDepartments();

        Task<Department>? GetDepartmentById(int departmentId);

    }
}

