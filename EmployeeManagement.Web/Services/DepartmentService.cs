﻿using System;
using EmployeeManagement.Models;
using EmployeeManagement.Models.Data;
using EmployeeManagement.Web.Services.Interfaces;

namespace EmployeeManagement.Web.Services
{
	public class DepartmentService : IDepartmentService
	{
        private readonly HttpClient _httpClient;
        public DepartmentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Department> GetDepartment(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Department>($"api/department/{id}");
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}

