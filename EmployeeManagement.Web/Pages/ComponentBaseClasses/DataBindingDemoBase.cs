using System;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagement.Web.Pages
{
	public class DataBindingDemoBase : ComponentBase
    {
		public string Name { get; set; } = "Suman";

		public string Description { get; set; } = string.Empty;
	}
}

