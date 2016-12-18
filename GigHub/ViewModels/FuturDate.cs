using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace GigHub.ViewModels
{
    public class FuturDate : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dateTime;
            var enUs = new CultureInfo("en-US");

            var isValid = DateTime.TryParseExact(Convert.ToString(value),
                "d MMM yyyy",
                enUs,
                DateTimeStyles.None,
                out dateTime);
            return (isValid && dateTime > DateTime.Now);
        }
    }
}