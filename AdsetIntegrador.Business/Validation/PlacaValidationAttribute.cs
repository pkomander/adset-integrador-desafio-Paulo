using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdsetIntegrador.Business.Validation
{
    public class PlacaValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var placa = value as string;
            if (string.IsNullOrEmpty(placa))
            {
                return new ValidationResult("A placa é obrigatória.");
            }

            // Regular expression to match old and new Brazilian license plate formats
            var regex = new Regex(@"^[A-Z]{3}[0-9]{4}$|^[A-Z]{3}[0-9][A-Z][0-9]{2}$");
            if (!regex.IsMatch(placa))
            {
                return new ValidationResult("Placa inválida. Deve seguir o formato 'ABC1234' ou 'ABC1D23'.");
            }

            return ValidationResult.Success;
        }
    }
}
