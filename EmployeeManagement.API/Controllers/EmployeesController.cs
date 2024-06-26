﻿using System;
using EmployeeManagement.API.Data.Repository;
using EmployeeManagement.API.Data.Repository.Interfaces;
using EmployeeManagement.Models;
using EmployeeManagement.Models.Data;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
	{
		private readonly IEmployeeRepository _employeeRepository;
		private string errorRetreivingDbDataMessage = "Error retreiving data from DB :";

		public EmployeesController(IEmployeeRepository employeeRepository)
		{
			_employeeRepository = employeeRepository;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
		{
			try
			{
                var employees = await _employeeRepository.GetAllEmployees();
				return Ok(employees);

            }
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, string.Format("{0} : {1}", errorRetreivingDbDataMessage,ex));
			}
		}

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
		{
			try
			{
                Employee? employee = await _employeeRepository.GetEmployeeById(id);
				if(employee != null)
				{
					return Ok(employee);
				}
				return NotFound(employee);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, string.Format("{0} : {1}", errorRetreivingDbDataMessage, ex));
			}
		}

		[HttpPost]
		public async Task<ActionResult<Employee>> AddEmployee([FromBody] Employee emp)
		{
			try
			{
                if (emp == null || emp.EmployeeId <= 0)
                {
                    return BadRequest();
                }
                
                var employee = await _employeeRepository.InsertEmployee(emp);
                return CreatedAtAction(nameof(GetEmployee), new { id = employee.EmployeeId }, employee);
            }
            catch (Exception ex)
			{
                return StatusCode(StatusCodes.Status500InternalServerError, string.Format("{0} : {1}", errorRetreivingDbDataMessage, ex));
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Employee>> UpdateEmployee(int id, Employee employee)
        {
            try
            {
                if (id != employee.EmployeeId)
                    return BadRequest("Employee ID mismatch");

                var employeeToUpdate = _employeeRepository.GetEmployeeById(id);

                if (employeeToUpdate == null)
                    return NotFound($"Employee with Id = {id} not found");

                return await _employeeRepository.UpdateEmployee(employee);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<bool>> DeleteEmployee(int id)
        {
            try
            {
                var employeeToDelete = _employeeRepository.GetEmployeeById(id);

                if (employeeToDelete == null)
                {
                    return NotFound($"Employee with Id = {id} not found");
                }

                return await _employeeRepository.DeleteEmployee(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }

        [HttpGet("{search}")]
        public async Task<ActionResult<IEnumerable<Employee>>> Search(string name, Gender? gender)
        {
            try
            {
                var result = await _employeeRepository.Search(name, gender);

                if (result.Any())
                {
                    return Ok(result);
                }

                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
    }
}

