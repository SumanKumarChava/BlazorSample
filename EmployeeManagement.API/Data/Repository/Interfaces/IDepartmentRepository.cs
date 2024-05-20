using System;
using EmployeeManagement.Models;
using EmployeeManagement.Models.Data;

namespace EmployeeManagement.API.Data.Repository.Interfaces
{
	public interface IDepartmentRepository
	{
        IEnumerable<Department> GetAllDepartments();

        Department? GetDepartmentById(int departmentId);

    }
}

