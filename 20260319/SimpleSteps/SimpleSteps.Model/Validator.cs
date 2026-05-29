using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SimpleSteps.Model
{
    public class FutureDateValidatonAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value == null)
            {
                return false;
            }
            
            if (value is DateTime date)
            {
                return date.Date <= DateTime.Today; //wenn wert(datum) nicht in zukunft ist, dann ist er true, ansonsten false
            }
            return false;
        }
    }

}
