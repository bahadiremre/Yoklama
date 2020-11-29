using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Restopos.Yoklama.Web.CustomValidators
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    sealed public class DateTimeLessThan : ValidationAttribute
    {
        private readonly string ExceptionMessage = "Başlangıç zamanı bitiş zamanında sonra olamaz.";
        private readonly string endDatePropertyName;
        public DateTimeLessThan(string EndDatePropertyName)
        {
            this.endDatePropertyName = EndDatePropertyName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime startDate = (DateTime)value;

            var endDateProperty = validationContext.ObjectType.GetProperty(endDatePropertyName);

            if (endDateProperty == null)
                throw new ArgumentException("Bu isimde bir nesne bulunamadı.");

            var endDateValue = (DateTime)endDateProperty.GetValue(validationContext.ObjectInstance);

            if (startDate > endDateValue)
                return new ValidationResult(FormatErrorMessage(ExceptionMessage));

            return ValidationResult.Success;
        }

        public override string FormatErrorMessage(string message)
        {
            return message;
        }

    }
}
