﻿using System.ComponentModel.DataAnnotations;
using EmployeeManagement.Models.CustomValidators;
using EmployeeManagement.Models.Data;

namespace EmployeeManagement.Models;

public class Employee
{
    public int EmployeeId { get; set; }
    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string FirstName { get; set; }
    [Required(ErrorMessage = "LastName should be given")]
    public string LastName { get; set; }
    [Required]
    [EmailAddress]
    [EmailDomainValidator(ErrorMessage = $"Domain should contain Google.com", DomainName = "Google.com")]
    public string Email { get; set; }
    public DateTime DateOfBrith { get; set; }
    public Gender Gender { get; set; }
    public int DepartmentId { get; set; }
    public string PhotoPath { get; set; }
}
