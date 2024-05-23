using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace tMovies.API.Utilities
{
    public class DateFormatAttribute : ValidationAttribute
    {
        private readonly string _dateFormat;

        public DateFormatAttribute(string dateFormat)
        {
            _dateFormat = dateFormat;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("Data de nascimento é obrigatória.");
            }

            var dateString = value.ToString();
            if (DateTime.TryParseExact(dateString, _dateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult($"A data deve estar nesse formato {_dateFormat}.");
        }
    }
}
