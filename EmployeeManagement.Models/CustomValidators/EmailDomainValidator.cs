using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models.CustomValidators
{
	public class EmailDomainValidator : ValidationAttribute
	{
        public string DomainName { get; set; }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var input = (value as string).Split("@");
            if (input[1].Equals(DomainName, StringComparison.OrdinalIgnoreCase))
            {
                return null;
            }
            return new ValidationResult(ErrorMessage);
        }
    }
}

