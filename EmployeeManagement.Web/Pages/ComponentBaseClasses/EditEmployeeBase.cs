using System;
using EmployeeManagement.Models;
using EmployeeManagement.Models.Data;
using EmployeeManagement.Web.Services;
using EmployeeManagement.Web.Services.Interfaces;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagement.Web.Pages.ComponentBaseClasses
{
	public class EditEmployeeBase : ComponentBase
	{
        public Employee Employee { get; set; } = new Employee();
        public IEnumerable<Department> Departments { get; set; } = new List<Department>();

        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        [Inject]
        public IDepartmentService DepartmentService { get; set; }

		[Parameter]
		public string Id { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Employee = await EmployeeService.GetEmployee(Convert.ToInt32(Id));
            Departments = await DepartmentService.GetDepartments();
        }
    }
}

