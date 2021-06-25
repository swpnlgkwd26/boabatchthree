using sample_app.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace sample_app.Infrastructure
{
    // Check That date Entered in the MfgDate Textbox ,year should not be less
    // than current year.
    public class ValidMfgDate : ValidationAttribute
    {
        public int Year { get; set; }
        public string GetErrorMessage() =>
            $"Mfg Date Should not be less than current Year";
        //public string  ErrorMessageCustom { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // Contain  the logic that Reads Date and Compare it with the Current Year
            var data = value;
            // Get the infromation about the validation 
            var product =(ProductEditModel) validationContext.ObjectInstance;
            // Get the current Year
            var currentYear = DateTime.Now.Year;
            if (product.MfgDate.Year < currentYear)
            {
                return new ValidationResult(GetErrorMessage());
            }
            return ValidationResult.Success;
        }

    }
}
