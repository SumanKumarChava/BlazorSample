using System;
using EmployeeManagement.Models;
using EmployeeManagement.Web.Services;
using EmployeeManagement.Web.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace EmployeeManagement.Web.Pages
{
    public class EmployeeDetailsBase : ComponentBase
	{
		[Parameter]
		public string Id { get; set; }

		[Inject]
		public IEmployeeService EmployeeService { get; set; }

        [Inject]
        public IDepartmentService DepartmentService { get; set; }

        public Employee Employee { get; set; }

        public string DepartmentName { get; set; }

        public string HideFooterButton = "Hide Footer";
        public string CssClass = null;

        protected override async Task OnInitializedAsync()
        {
            Id = Id ?? "1";
            Employee = await EmployeeService.GetEmployee(Convert.ToInt32(Id));
            var department = await DepartmentService.GetDepartment(Convert.ToInt32(Employee.DepartmentId));
            DepartmentName = department.DepartmentName;
        }


        public void HideFooter_Click()
        {
            if(HideFooterButton == "Hide Footer")
            {
                HideFooterButton = "Show Footer";
                CssClass = "hidden";
            }
            else
            {
                HideFooterButton = "Hide Footer";
                CssClass = null;
            }
        }
    }
}

