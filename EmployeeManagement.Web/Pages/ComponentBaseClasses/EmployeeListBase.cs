using System;
using System.Collections.Generic;
using EmployeeManagement.Models;
using EmployeeManagement.Models.Data;
using EmployeeManagement.Web.Services;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagement.Web.Pages
{
	public class EmployeeListBase : ComponentBase
	{
        [Inject]
        public IEmployeeService EmployeeService { get; set; }

		public IEnumerable<Employee> Employees { get; set; }

        public int SelectedEmpCount { get; set; } = 0;

        public bool ShowFooter { get; set; } = true;

        protected override async Task OnInitializedAsync()
        {
            Employees = await EmployeeService.GetEmployees();
        }

        protected void EmployeeSelected(bool isSelected)
        {
            if (isSelected)
                SelectedEmpCount++;
            else
                SelectedEmpCount--;
        }
        
    }
}

