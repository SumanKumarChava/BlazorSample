using System;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagement.Web.Components
{
	public class EmployeeCardBase : ComponentBase
	{
		[Parameter]
		public Employee Employee { get; set; }

        [Parameter]
        public bool ShowFooter { get; set; }

		[Parameter]
		public EventCallback<bool> OnEmpployeeSelected { get; set; }

		protected async Task EmployeeCheckbox_Changed(ChangeEventArgs args)
		{
			await OnEmpployeeSelected.InvokeAsync((bool)args.Value);
		}
    }
}

