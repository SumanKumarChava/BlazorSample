using System;
using EmployeeManagement.Models;
using EmployeeManagement.Models.Data;

namespace EmployeeManagement.Web.Services.Interfaces
{
	public interface IDepartmentService
	{
        public Task<Department> GetDepartment(int id);
    }
}

