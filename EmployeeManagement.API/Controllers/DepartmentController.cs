using System;
using EmployeeManagement.API.Data.Repository.Interfaces;
using EmployeeManagement.Models;
using EmployeeManagement.Models.Data;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.API.Controllers
{
	[ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase
	{
        private readonly IDepartmentRepository _departmentRepository;
        private string errorRetreivingDbDataMessage = "Error retreiving data from DB :";

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Department>> GetDepartment(int id)
        {
            try
            {
                var dept = await _departmentRepository.GetDepartmentById(id);
                if (dept != null)
                {
                    return Ok(dept);
                }
                return NotFound(dept);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, string.Format("{0} : {1}", errorRetreivingDbDataMessage, ex));
            }
        }
    }
}

