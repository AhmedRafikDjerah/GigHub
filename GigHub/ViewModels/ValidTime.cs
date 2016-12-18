using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace GigHub.ViewModels
{
    public class ValidTime : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dateTime;

            var enUs = new CultureInfo("en-US");

            var isValid = DateTime.TryParseExact(Convert.ToString(value),
                "Hh:mm",
                enUs,
                DateTimeStyles.None,
                out dateTime);

            return (isValid);
        }
    }
}