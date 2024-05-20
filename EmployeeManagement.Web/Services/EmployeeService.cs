using System;
using EmployeeManagement.Models;

namespace EmployeeManagement.Web.Services
{
	public class EmployeeService : IEmployeeService
	{
        private readonly HttpClient _httpClient;
        public EmployeeService(HttpClient httpClient)
		{
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Employee>>("api/Employees");
        }

        public async Task<Employee> GetEmployee(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Employee>($"api/Employees/{id}");
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}

